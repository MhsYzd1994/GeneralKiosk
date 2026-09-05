using GeneralKiosk.Common;
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
    public partial class prompt : Form
    {
        public string MyPass { get; set; }

        public prompt()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "") return;

            MyPass = textBox1.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private async void prompt_Load(object sender, EventArgs e)
        {
            Shared.KeyboardEnglish();
            await ShowKeyBoardAsync();


        }

        private void  textBox1_ClickAsync(object sender, EventArgs e)
        {
             ShowKeyBoardAsync();
        }


        private void CloseFormsKeyBoard()
        {
            try
            {
                foreach (Form form in Application.OpenForms.OfType<Form>())
                {

                    if (form.Name == "NumericKeyboardForm")
                    {
                        form.Close(); // بستن فرم
                    }
                }
            }
            catch
            {

            }
            // استفاده از Application.OpenForms برای دریافت لیست فرم‌های باز

        }

        private async Task ShowKeyBoardAsync()
        {
            try
            {
                CloseFormsKeyBoard();
                if (Program.ActiveKeyPad)
                {
                    NumericKeyboardForm keyboardForm = new NumericKeyboardForm(textBox1);

                    if (keyboardForm == null || keyboardForm.IsDisposed)
                    {
                        keyboardForm = new NumericKeyboardForm(this.textBox1);
                    }

                    // تنظیم مکان و اندازه کیبورد
                    var textBoxPosition = this.textBox1.PointToScreen(Point.Empty);
                    var textBoxCenterX = textBoxPosition.X + this.textBox1.Width / 2;

                    // محاسبه موقعیت فرم برای قرارگیری زیر تکس باکس و هم‌راستایی عرض
                    var formWidth = keyboardForm.Width;
                    var formPositionX = (textBoxCenterX - formWidth / 2) - 100;
                    var formPositionY = textBoxPosition.Y + this.textBox1.Height;

                    keyboardForm.StartPosition = FormStartPosition.Manual;
                    keyboardForm.Location = new Point(formPositionX, formPositionY);

                    // تنظیم فرم اصلی به عنوان Owner فرم کیبورد
                    keyboardForm.Owner = this;

                    // نمایش فرم کیبورد به عنوان TopMost و فوکوس روی TextBox
                    keyboardForm.TopMost = true;
                    keyboardForm.Show();
                    textBox1.Focus();
                }
            }
            catch
            {
                // مدیریت استثناها
            }



            //try
            //{
            //    if(Program.ActiveKeyPad)
            //    Process.Start("C:\\Program Files\\Common Files\\microsoft shared\\ink\\tabtip.exe");
            //}
            //catch
            //{

            //}
        }
    }
}
