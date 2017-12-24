using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Наилучшая_модель_для_прогнозирования
{
    public struct УравнениеПрямой
    {
        public decimal k { get; set; }
        public decimal x { get; set; }
        public decimal b { get; set; }

        public УравнениеПрямой(decimal k, decimal b) : this(k, 0, b) { }

        public УравнениеПрямой(decimal k, decimal x, decimal b)
        {
            this.k = k;
            this.x = x;
            this.b = b;
        }

        public decimal Решить()
        {
            return k * x + b;
        }

        public override string ToString()
        {
            return $"y = {k}{x} + {b}";
        }
    }
}
