using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Csv;
using System.Globalization;

namespace Стохастический_Осциллятор
{
    public class Запись
    {
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public int Volume { get; set; }

        public Запись(string date, string time, string open, string high, string low, string close, string volume)
        {
            this.Date = DateTime.Parse(date);
            this.Time = TimeSpan.Parse(time);
            this.Open = Decimal.Parse(open, new CultureInfo("en-US"));
            this.High = Decimal.Parse(high, new CultureInfo("en-US"));
            this.Low = Decimal.Parse(low, new CultureInfo("en-US"));
            this.Close = Decimal.Parse(close, new CultureInfo("en-US"));
            this.Volume = Int32.Parse(volume);
        }

        public static List<Запись> ЗагрузитьВсеЗаписи(string filePath)
        {
            List<Запись> результат = new List<Запись>();

            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
            {
                var rowList = CsvReader.ReadFromStream(fileStream, new CsvOptions { HeaderMode = HeaderMode.HeaderPresent });

                foreach (var row in rowList)
                {
                    результат.Add(new Запись(row["<DATE>"], row["<TIME>"], row["<OPEN>"], row["<HIGH>"], row["<LOW>"], row["<CLOSE>"], row["<VOL>"]));
                }
            }

            return результат;
        }
    }
}
