using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Стохастический_Осциллятор
{
    public static class Формулы
    {
        public static decimal Kt(decimal Ct, decimal Lt, decimal Ht)
        {
            return ((Ct - Lt) / (Ht - Lt)) * 100;
        }

        public static decimal МинимальныйМинимум(IList<Запись> записи)
        {
            return записи.Min(запись => запись.Low);
        }

        public static decimal МаксимальныйМаксимум(IList<Запись> записи)
        {
            return записи.Max(запись => запись.High);
        }
    }
}
