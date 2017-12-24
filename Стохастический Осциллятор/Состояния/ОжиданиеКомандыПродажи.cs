using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Стохастический_Осциллятор
{
    public class ОжиданиеКомандыПродажи : IСостояние
    {
        private readonly Осциллятор осциллятор;

        public ОжиданиеКомандыПродажи(Осциллятор осциллятор)
        {
            this.осциллятор = осциллятор;
        }

        public void ПерейтиКСледующему()
        {
            if ((осциллятор.Kt >= 20) && (осциллятор.Kt <= 80))
            {
                //MessageBox.Show("Продавать");
                this.осциллятор.ДобавитьЗаписьВТаблицуПродаж(this.осциллятор.Запись);
                this.осциллятор.УстановитьСостояние(this.осциллятор.ОжиданиеКомандыПокупки);
            }

            if (this.осциллятор.Kt > 80)
            {
                this.осциллятор.ДобавитьЗаписьВТаблицуПродаж(this.осциллятор.Запись);
                //MessageBox.Show("Продавать");
            }

            if (this.осциллятор.Kt < 20)
            {
                this.осциллятор.УстановитьСостояние(this.осциллятор.ОжиданиеИнтерпретации);
            }
        }
    }
}
