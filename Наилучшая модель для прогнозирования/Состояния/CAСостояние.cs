using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Наилучшая_модель_для_прогнозирования
{
    public class CAСостояние : IСостояние
    {
        private readonly АвтоматПрогнозирования автомат;

        public CAСостояние(АвтоматПрогнозирования автоматПрогнозирования)
        {
            this.автомат = автоматПрогнозирования;
        }

        public void ПерейтиКСледующему()
        {
            автомат.ОбновитьСтатусСостояния("СA");
        }
    }
}
