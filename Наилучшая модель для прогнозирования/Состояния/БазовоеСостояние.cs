using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Наилучшая_модель_для_прогнозирования
{
    public abstract class БазовоеСостояние
    {
        protected bool Check(decimal R1, decimal R2, decimal R3)
        {
            return R1 > R2 && R2 > R3;
        }
    }
}
