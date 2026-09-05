using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneralKiosk.Class
{
    public class PatientControlBase : UserControl
    {
        public virtual string PatientName { get; set; }
        public virtual string PatientPaziresh { get; set; }
    }
}
