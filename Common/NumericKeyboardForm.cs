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
    public partial class NumericKeyboardForm : Form
    {
        private TextBox targetTextBox;
        System.Media.SoundPlayer playerEnter = new System.Media.SoundPlayer(@"Sounds/00.wav");

        public NumericKeyboardForm(TextBox textBox)
        {
            InitializeComponent();
            targetTextBox = textBox;
        }

        private void NumericButton_Click(object sender, EventArgs e)
                    {
            if (!Program.MuteSound)
            {
                playerEnter.Play();
            }
            Button btn = sender as Button;
            targetTextBox.Text += btn.Text;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            targetTextBox.Text = string.Empty;
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            if (targetTextBox.Text.Length > 0)
            {
                targetTextBox.Text = targetTextBox.Text.Substring(0, targetTextBox.Text.Length - 1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NumericKeyboardForm_Load(object sender, EventArgs e)
        {
            buttonCloseNumForm.Visible = Program.CanCloseNumForm;
        }
    }

}
