using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneralKiosk.Common
{
    public partial class FormWaiting : Form
    {
        int cnt = 1;
        public FormWaiting()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (cnt == 0)
                this.Close();
            else
                cnt--;
        }
    }
}
