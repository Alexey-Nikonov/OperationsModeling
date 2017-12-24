using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Стохастический_Осциллятор
{
    public class ОжиданиеКоманды : IСостояние
    {
        private readonly Осциллятор осциллятор;

        public ОжиданиеКоманды(Осциллятор осциллятор)
        {
            this.осциллятор = осциллятор;
        }

        public void ПерейтиКСледующему()
        {
            if ((осциллятор.Kt >= 20) && (осциллятор.Kt <= 80))
            {
                
            }

            if (this.осциллятор.Kt > 80)
            {
                this.осциллятор.УстановитьСостояние(this.осциллятор.ОжиданиеКомандыПродажи);
            }

            if (this.осциллятор.Kt < 20)
            {
                this.осциллятор.УстановитьСостояние(this.осциллятор.КомандаНаПродажуСтоп);
            }
        }
    }
}
