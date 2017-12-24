using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Наилучшая_модель_для_прогнозирования
{
    public class МодельПрогнозирования
    {
        public УравнениеПрямой УравнениеПрямой { get; set; }

        public List<decimal> ТеоритическиеЗначенияY { get; set; }

        public decimal КоэффициентДетерминации { get; set; }
    }
}
