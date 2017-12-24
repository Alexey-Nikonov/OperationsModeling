using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Стохастический_Осциллятор
{
    public class КомандаНаПродажуСтоп : IСостояние
    {
        private readonly Осциллятор осциллятор;

        public КомандаНаПродажуСтоп(Осциллятор осциллятор)
        {
            this.осциллятор = осциллятор;
        }

        public void ПерейтиКСледующему()
        {
            if ((осциллятор.Kt >= 20) && (осциллятор.Kt <= 80))
            {
                //MessageBox.Show("Покупать");
                this.осциллятор.ДобавитьЗаписьВТаблицуПокупок(this.осциллятор.Запись);
                this.осциллятор.УстановитьСостояние(this.осциллятор.КомандаНаПокупкуСтоп);
            }

            if (this.осциллятор.Kt > 80)
            {
                this.осциллятор.УстановитьСостояние(this.осциллятор.ОжиданиеИнтерпретации);
            }

            if (this.осциллятор.Kt < 20)
            {
                
            }
        }
    }
}
