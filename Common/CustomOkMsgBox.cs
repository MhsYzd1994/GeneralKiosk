using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneralKiosk
{
    public partial class CustomOkMsgBox : Form
    {
        private int timerCount;

        public SoundPlayer CustomPlayer { get; }= new System.Media.SoundPlayer();

        System.Media.SoundPlayer player = new System.Media.SoundPlayer();

        public bool YsNo { get; }
        public int TimerCount { get; }

        public CustomOkMsgBox(string MessageTxt, Image MessagePic, bool YesNo = false, int TimerCount = 10, SoundPlayer Player = null)
        {
            InitializeComponent();
            labelMessageTxt.Text = MessageTxt;
            pictureBoxMessagePic.Image = MessagePic;
            YsNo = YesNo;
            timerCount = TimerCount;
            CustomPlayer = Player;
        }


        private void CustomOkMsgBox_Load(object sender, EventArgs e)
        {
            try
            {
                
                timerCloseForm.Enabled = true;
                if (!YsNo)
                {
                    uiButtonOk.Dock = DockStyle.Fill;

                }

                this.BringToFront();
                player = new System.Media.SoundPlayer();
                player.SoundLocation = "Sounds/ShowMsgBox.wav";
                if(!Program.MuteSound)
                {
                    player.Play();
                }

                if (!(CustomPlayer is null))
                {
                    if (!Program.MuteSound)
                    {
                        CustomPlayer.Play();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.OK;
            this.Close();
            player.Stop();


        }

        private void timerCloseForm_Tick(object sender, EventArgs e)
        {
            if (timerCount == 0)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                timerCount = timerCount - 1;
                labelCloseTime.Text = timerCount.ToString();
            }


        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            player.Stop();
            this.Close();
        }
    }
}
