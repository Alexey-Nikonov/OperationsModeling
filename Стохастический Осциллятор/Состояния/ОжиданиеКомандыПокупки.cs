using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Стохастический_Осциллятор
{
    public class ОжиданиеКомандыПокупки : IСостояние
    {
        private readonly Осциллятор осциллятор;

        public ОжиданиеКомандыПокупки(Осциллятор осциллятор)
        {
            this.осциллятор = осциллятор;
        }

        public void ПерейтиКСледующему()
        {
            if ((осциллятор.Kt >= 20) && (осциллятор.Kt <= 80))
            {
                this.осциллятор.ДобавитьЗаписьВТаблицуПокупок(this.осциллятор.Запись);
                //MessageBox.Show("Покупать");
                this.осциллятор.УстановитьСостояние(this.осциллятор.ОжиданиеКоманды);
            }
            else if (this.осциллятор.Kt > 80)
            {
                this.осциллятор.УстановитьСостояние(this.осциллятор.ОжиданиеИнтерпретации);
            }
        }
    }
}
