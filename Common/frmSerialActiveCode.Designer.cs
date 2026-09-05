namespace GeneralKiosk
{
    partial class FrmSerialActiveCode
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
            this.TextBoxSerial = new System.Windows.Forms.TextBox();
            this.BtnOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TextBoxActiveCode = new Janus.Windows.GridEX.EditControls.MaskedEditBox();
            this.SuspendLayout();
            // 
            // TextBoxSerial
            // 
            this.TextBoxSerial.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.TextBoxSerial.Location = new System.Drawing.Point(12, 13);
            this.TextBoxSerial.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TextBoxSerial.MaxLength = 20;
            this.TextBoxSerial.Name = "TextBoxSerial";
            this.TextBoxSerial.ReadOnly = true;
            this.TextBoxSerial.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TextBoxSerial.Size = new System.Drawing.Size(275, 23);
            this.TextBoxSerial.TabIndex = 0;
            this.TextBoxSerial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BtnOk
            // 
            this.BtnOk.Location = new System.Drawing.Point(12, 76);
            this.BtnOk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(361, 28);
            this.BtnOk.TabIndex = 2;
            this.BtnOk.Text = "فعال سازی  (حروف کوچک و بزرگ برابر هستند)";
            this.BtnOk.UseVisualStyleBackColor = true;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(293, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "سریال :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(293, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "کد فعال ساز :";
            // 
            // TextBoxActiveCode
            // 
            this.TextBoxActiveCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.TextBoxActiveCode.ForeColor = System.Drawing.Color.White;
            this.TextBoxActiveCode.Location = new System.Drawing.Point(12, 44);
            this.TextBoxActiveCode.Mask = "AAAA-AAAA-AAAA-AAAA";
            this.TextBoxActiveCode.Name = "TextBoxActiveCode";
            this.TextBoxActiveCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TextBoxActiveCode.Size = new System.Drawing.Size(275, 23);
            this.TextBoxActiveCode.TabIndex = 5;
            this.TextBoxActiveCode.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            // 
            // FrmSerialActiveCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(388, 114);
            this.Controls.Add(this.TextBoxActiveCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.TextBoxSerial);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSerialActiveCode";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فرم دریافت کد فعال سازی";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmSerialActiveCode_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBoxSerial;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Janus.Windows.GridEX.EditControls.MaskedEditBox TextBoxActiveCode;
    }
}