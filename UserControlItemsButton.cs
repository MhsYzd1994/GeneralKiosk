using GeneralKiosk.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneralKiosk
{
    public partial class UserControlItemsButton : PatientControlBase
    {
        public override string PatientName
        {
            get { return buttonName.Text; }
            set { buttonName.Text = value; }
        }

        public override string PatientPaziresh
        {
            get { return buttonPaziresh.Text; }
            set { buttonPaziresh.Text = value; }
        }

        public UserControlItemsButton()
        {
            InitializeComponent();
            WireAllControls(this);

        }

        private void WireAllControls(Control cont)
        {
            foreach (Control ctl in cont.Controls)
            {
                ctl.Click += ctl_Click;
                if (ctl.HasChildren)
                {
                    WireAllControls(ctl);
                }
            }
        }

        private void ctl_Click(object sender, EventArgs e)
        {
            this.InvokeOnClick(this, EventArgs.Empty);
        }


        public event EventHandler PanelCick;


        protected virtual void OnClick(EventArgs e)
        {
            EventHandler handler = this.PanelCick;
            if (handler != null)
            {
                handler(this, e);
            }
        }


    }
}
