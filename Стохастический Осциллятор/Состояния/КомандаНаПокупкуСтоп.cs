using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Стохастический_Осциллятор
{
    public class КомандаНаПокупкуСтоп : IСостояние
    {
        private readonly Осциллятор осциллятор;

        public КомандаНаПокупкуСтоп(Осциллятор осциллятор)
        {
            this.осциллятор = осциллятор;
        }

        public void ПерейтиКСледующему()
        {

        }
    }
}
