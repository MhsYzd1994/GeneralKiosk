namespace GeneralKiosk
{
    partial class CustomOkMsgBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelMessageTxt = new System.Windows.Forms.Label();
            this.timerCloseForm = new System.Windows.Forms.Timer(this.components);
            this.labelCloseTime = new System.Windows.Forms.Label();
            this.uiButtonOk = new Janus.Windows.EditControls.UIButton();
            this.uiButtonNo = new Janus.Windows.EditControls.UIButton();
            this.uiGroupBoxButtoms = new Janus.Windows.EditControls.UIGroupBox();
            this.pictureBoxMessagePic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBoxButtoms)).BeginInit();
            this.uiGroupBoxButtoms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMessagePic)).BeginInit();
            this.SuspendLayout();
            // 
            // labelMessageTxt
            // 
            this.labelMessageTxt.BackColor = System.Drawing.SystemColors.Control;
            this.labelMessageTxt.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMessageTxt.Location = new System.Drawing.Point(-1, 95);
            this.labelMessageTxt.Name = "labelMessageTxt";
            this.labelMessageTxt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelMessageTxt.Size = new System.Drawing.Size(683, 469);
            this.labelMessageTxt.TabIndex = 5;
            this.labelMessageTxt.Text = "پیغاااام !!!!!!!!!!!!!!!!!!";
            this.labelMessageTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerCloseForm
            // 
            this.timerCloseForm.Interval = 1000;
            this.timerCloseForm.Tick += new System.EventHandler(this.timerCloseForm_Tick);
            // 
            // labelCloseTime
            // 
            this.labelCloseTime.AutoSize = true;
            this.labelCloseTime.ForeColor = System.Drawing.Color.Red;
            this.labelCloseTime.Location = new System.Drawing.Point(648, 9);
            this.labelCloseTime.Name = "labelCloseTime";
            this.labelCloseTime.Size = new System.Drawing.Size(34, 23);
            this.labelCloseTime.TabIndex = 7;
            this.labelCloseTime.Text = "10";
            // 
            // uiButtonOk
            // 
            this.uiButtonOk.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.uiButtonOk.Location = new System.Drawing.Point(344, 17);
            this.uiButtonOk.Name = "uiButtonOk";
            this.uiButtonOk.Size = new System.Drawing.Size(331, 94);
            this.uiButtonOk.StateStyles.FormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(19)))), ((int)(((byte)(143)))));
            this.uiButtonOk.StateStyles.FormatStyle.ForeColor = System.Drawing.Color.White;
            this.uiButtonOk.TabIndex = 9;
            this.uiButtonOk.Text = "تایید";
            this.uiButtonOk.UseThemes = false;
            this.uiButtonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // uiButtonNo
            // 
            this.uiButtonNo.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.uiButtonNo.Location = new System.Drawing.Point(9, 17);
            this.uiButtonNo.Name = "uiButtonNo";
            this.uiButtonNo.Size = new System.Drawing.Size(331, 94);
            this.uiButtonNo.StateStyles.FormatStyle.BackColor = System.Drawing.Color.DarkRed;
            this.uiButtonNo.StateStyles.FormatStyle.ForeColor = System.Drawing.Color.White;
            this.uiButtonNo.TabIndex = 10;
            this.uiButtonNo.Text = "خیر";
            this.uiButtonNo.UseThemes = false;
            this.uiButtonNo.Click += new System.EventHandler(this.uiButton2_Click);
            // 
            // uiGroupBoxButtoms
            // 
            this.uiGroupBoxButtoms.Controls.Add(this.uiButtonOk);
            this.uiGroupBoxButtoms.Controls.Add(this.uiButtonNo);
            this.uiGroupBoxButtoms.Location = new System.Drawing.Point(4, 567);
            this.uiGroupBoxButtoms.Name = "uiGroupBoxButtoms";
            this.uiGroupBoxButtoms.Size = new System.Drawing.Size(687, 121);
            this.uiGroupBoxButtoms.TabIndex = 11;
            // 
            // pictureBoxMessagePic
            // 
            this.pictureBoxMessagePic.Image = global::GeneralKiosk.Properties.Resources.question_icon5940;
            this.pictureBoxMessagePic.Location = new System.Drawing.Point(83, 3);
            this.pictureBoxMessagePic.Name = "pictureBoxMessagePic";
            this.pictureBoxMessagePic.Size = new System.Drawing.Size(551, 89);
            this.pictureBoxMessagePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxMessagePic.TabIndex = 6;
            this.pictureBoxMessagePic.TabStop = false;
            // 
            // CustomOkMsgBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(714, 700);
            this.ControlBox = false;
            this.Controls.Add(this.uiGroupBoxButtoms);
            this.Controls.Add(this.labelCloseTime);
            this.Controls.Add(this.pictureBoxMessagePic);
            this.Controls.Add(this.labelMessageTxt);
            this.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomOkMsgBox";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.CustomOkMsgBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBoxButtoms)).EndInit();
            this.uiGroupBoxButtoms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMessagePic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelMessageTxt;
        private System.Windows.Forms.PictureBox pictureBoxMessagePic;
        private System.Windows.Forms.Timer timerCloseForm;
        private System.Windows.Forms.Label labelCloseTime;
        private Janus.Windows.EditControls.UIButton uiButtonOk;
        private Janus.Windows.EditControls.UIButton uiButtonNo;
        private Janus.Windows.EditControls.UIGroupBox uiGroupBoxButtoms;
    }
}