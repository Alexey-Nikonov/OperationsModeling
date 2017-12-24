using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Csv;

namespace Стохастический_Осциллятор
{
    public partial class Form1 : Form
    {
        private List<Запись> ВсеЗаписи;        
        private int period;
        private Осциллятор осциллятор;
        public EventHandler ПокупкаИлиПродажа;

        public Form1()
        {
            InitializeComponent();

            this.ВсеЗаписи = new List<Запись>();
            this.period = 12;
            this.осциллятор = new Осциллятор
            {
                ДобавитьЗаписьВТаблицуПокупок = (запись) => this.покупкиBindingSource1.Add(запись),
                ДобавитьЗаписьВТаблицуПродаж = (запись) => this.продажиBindingSource2.Add(запись)
            };

            OpenFile();
        }

        private void OpenFile()
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "CSV|*.csv", ValidateNames = true })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    this.ВсеЗаписи.AddRange(Запись.ЗагрузитьВсеЗаписи(ofd.FileName));
                    this.всеЗаписиBindingSource.DataSource = this.ВсеЗаписи;
                }
            }
        }

        private void processButton_Click(object sender, EventArgs e)
        {
            decimal minLow, maxHigh;
            List<Запись> ЗаписиПериода = this.ВсеЗаписи.Take(this.period).ToList();

            foreach(Запись запись in this.ВсеЗаписи.Skip(this.period - 1))
            {
                minLow = Формулы.МинимальныйМинимум(ЗаписиПериода);
                maxHigh = Формулы.МаксимальныйМаксимум(ЗаписиПериода);

                this.осциллятор.Kt = Формулы.Kt(запись.Close, minLow, maxHigh);
                this.осциллятор.Запись = запись;
                this.осциллятор.Обработать();

                ЗаписиПериода.RemoveAt(0);
                var nextIndex = this.ВсеЗаписи.IndexOf(запись) + 1 == this.ВсеЗаписи.Count ? 0 : this.ВсеЗаписи.IndexOf(запись) + 1;
                ЗаписиПериода.Add(this.ВсеЗаписи[nextIndex]);
            }
        }
    }
}

/*
 * 0 ожидание начала интерпретации k
 * 1 ожидание команды
 * 2 ожидание команды на продажу
 * 3 команда на продажу, остановить работу
 * 4 ожидание команды на покупку
 * 5 команда на покупку, остановить работу
 */