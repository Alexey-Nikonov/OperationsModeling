using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Наилучшая_модель_для_прогнозирования
{
    public class АвтоматПрогнозирования
    {
        private IСостояние текущееСостояние;

        public НачальноеСостояние НачальноеСостояние { get; set; }
        public ABСостояние ABСостояние { get; set; }
        public BAСостояние BAСостояние { get; set; }
        public ACСостояние ACСостояние { get; set; }
        public CAСостояние CAСостояние { get; set; }
        public BCСостояние BCСостояние { get; set; }
        public CBСостояние CBСостояние { get; set; }

        public decimal Ra2 { get; set; }
        public decimal Rb2 { get; set; }
        public decimal Rc2 { get; set; }

        public Action<string> ОбновитьСтатусСостояния;

        public АвтоматПрогнозирования()
        {
            this.НачальноеСостояние = new НачальноеСостояние(this);
            this.ABСостояние = new ABСостояние(this);
            this.BAСостояние = new BAСостояние(this);
            this.ACСостояние = new ACСостояние(this);
            this.CAСостояние = new CAСостояние(this);
            this.BCСостояние = new BCСостояние(this);
            this.CBСостояние = new CBСостояние(this);

            this.текущееСостояние = this.НачальноеСостояние;
        }

        public void Обработать()
        {
            this.текущееСостояние.ПерейтиКСледующему();
        }

        public void УстановитьСостояние(IСостояние состояние)
        {
            this.текущееСостояние = состояние;
        }
    }
}
