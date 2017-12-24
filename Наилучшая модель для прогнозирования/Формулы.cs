using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Наилучшая_модель_для_прогнозирования
{
    public static class Формулы
    {
        public static decimal ПолучитьКоэффициентДетерминации(IList<decimal> теоритическиеY, IList<decimal> статическиеY)
        {
            int n = теоритическиеY.Count;

            decimal числитель = 0.0m;
            for (int i = 0; i < n; i++)
            {
                числитель += (статическиеY[i] - теоритическиеY[i]) * (статическиеY[i] - теоритическиеY[i]);
            }

            decimal знаменатель = 0.0m;
            decimal игрек_с_чертой = статическиеY.Sum() / n;
            for (int i = 0; i < n; i++)
            {
                знаменатель += (статическиеY[i] - игрек_с_чертой) * (статическиеY[i] - игрек_с_чертой);
            }
            
            return 1 - числитель / знаменатель;
        }

        public static (decimal k, decimal b) МНК(IList<decimal> x, IList<decimal> y)
        {
            int n = x.Count;
            decimal k, b;

            decimal икс_игрек_с_чертой = 0.0m;
            for (int i = 0; i < n; i++)
            {
                икс_игрек_с_чертой += x[i] * y[i];
            }
            икс_игрек_с_чертой /= n;

            decimal икс_с_чертой = x.Sum() / n;

            decimal игрек_с_чертой = y.Sum() / n;

            decimal икс_в_квадрате_с_чертой = x.Sum(икс => икс * икс) / n;

            b = (икс_игрек_с_чертой - икс_с_чертой * игрек_с_чертой) / ((икс_в_квадрате_с_чертой) - икс_с_чертой * икс_с_чертой);
            k = игрек_с_чертой - b * икс_с_чертой;

            return (k, b);
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
