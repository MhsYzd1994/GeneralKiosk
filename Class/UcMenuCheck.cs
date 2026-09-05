using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneralKiosk.Class
{
    public partial class UcMenuCheck : UserControl
    {
        public UcMenuCheck()
        {
            InitializeComponent();
        }

        public bool Checked
        {
            get { return checkBox1.Checked; }
            set { checkBox1.Checked = value; }
        }

        public event EventHandler CaptionClick
        {
            add { label1.Click += value; }
            remove { label1.Click -= value; }
        }

        public event EventHandler CheckChanged
        {
            add { checkBox1.CheckedChanged += value; }
            remove { checkBox1.CheckedChanged -= value; }
        }
        public string Caption
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }

        public CheckBox CheckBox
        {
            get { return checkBox1; }
        }

        //public Label Label
        //{
        //    get { return label1; }
        //}

        private void UcMenuCheck_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("fd");
        }
    }
}
