using FarsiLibrary.Utils;
using System;
using System.Windows.Forms;

namespace GeneralKiosk
{
    public partial class UserDate : UserControl
    {
        private DateTime? selectedDateTime;
        public DateTime? SelectedDateTime
        {
            get => selectedDateTime;
            set => selectedDateTime = value;
        }
        public override string Text { get => textBoxDate.Text; set => textBoxDate.Text = value; }
        
        public UserDate()
        {
            InitializeComponent();
        }

        private void TextBoxDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void TextBoxDate_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab) return;

            if (((TextBox)sender).Text.Length >= 6)
            {
                TextBox temtxt = (TextBox)sender;
                if (Shared.FormatAndCheckDate(temtxt.Text, temtxt) == false)
                {
                    Shared.ShowMessage(EnumSendMessage.FormatTarikhDorostNist, "");
                    temtxt.Text = "";
                    temtxt.Focus();
                    return;
                }
                SendKeys.Send("{tab}");
                
            }
        }

        private void TextBoxDate_Leave(object sender, EventArgs e)
        {
            TextBox temtxt = textBoxDate;

            if (!string.IsNullOrEmpty(temtxt.Text))
            {
                if (((TextBox)sender).Text.Trim().Length < 6)
                {
                    ((TextBox)sender).Text = "";
                    return;
                }

                DateTime tem = DateTime.Parse(temtxt.Text);
                DateTime Mabna = DateTime.Parse("1250/01/01");

                if (tem.CompareTo(Mabna.Date) < 0)
                {
                    Shared.ShowMessage(EnumSendMessage.PeyghamAzadBaIconError, "سال ورودی باید از 1250 بیشتر باشد");
                    temtxt.Text = "1250/01/01";

                }

                FaDatePickerMain.SelectedDateTime = (DateTime)(DateTime.Parse(temtxt.Text));
                OnLeave(new EventArgs());
            }

            SendKeys.Send("{tab}");
        }

        private void UiButton1_Click(object sender, EventArgs e)
        {
            FaDatePickerMain.Focus();
            FaDatePicker1_Click(sender, e);
        }

        private void FaDatePicker1_SelectedDateTimeChanged(object sender, EventArgs e)
        {
            if (FaDatePickerMain.SelectedDateTime == null)
            {
                if (textBoxDate.Text.Length < 6)
                {
                    textBoxDate.Text = "";
                    selectedDateTime = null;
                }
            }
            else
            {
                textBoxDate.Text = new PersianDate((DateTime)FaDatePickerMain.SelectedDateTime).ToString("d");
                selectedDateTime = FaDatePickerMain.SelectedDateTime;
            }
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
        }

        private void FaDatePicker1_Click(object sender, EventArgs e)
        {
            FaDatePickerMain.ShowDropDown();
        }
        
        private void TextBoxDate_Click(object sender, EventArgs e)
        {
            textBoxDate.SelectAll();
        }

        private void TextBoxDate_Enter(object sender, EventArgs e)
        {
            textBoxDate.SelectAll();
        }

        private void UserDate_Enter(object sender, EventArgs e)
        {
            this.ActiveControl = textBoxDate;
            textBoxDate.Focus();
            textBoxDate.SelectAll();
        }
    }
}
