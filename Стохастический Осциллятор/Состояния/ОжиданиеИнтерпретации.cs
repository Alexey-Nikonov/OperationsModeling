using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Стохастический_Осциллятор
{
    public class ОжиданиеИнтерпретации : IСостояние
    {
        private readonly Осциллятор осциллятор;

        public ОжиданиеИнтерпретации(Осциллятор осциллятор)
        {
            this.осциллятор = осциллятор;
        }

        public void ПерейтиКСледующему()
        {
            if ((осциллятор.Kt >= 20) && (осциллятор.Kt <= 80))
            {
                this.осциллятор.УстановитьСостояние(this.осциллятор.ОжиданиеКоманды);
            }

            if (this.осциллятор.Kt > 80)
            {

            }

            if (this.осциллятор.Kt < 20)
            {

            }
        }
    }
}
