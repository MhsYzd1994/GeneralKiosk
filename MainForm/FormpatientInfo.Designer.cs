
namespace GeneralKiosk
{
    partial class FormpatientInfo
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
            this.contextMenuStripFiles = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.تنظیماتToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.دربارهیماToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.خروجToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelRasisInfo = new System.Windows.Forms.Panel();
            this.textBoxName = new System.Windows.Forms.Label();
            this.tableLayoutPanelPayMentInfo = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPatientName = new System.Windows.Forms.Label();
            this.textBoxReceptionCode = new System.Windows.Forms.Label();
            this.textBoxServiceDescription = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxEndRate = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.uiButtonPay = new Janus.Windows.EditControls.UIButton();
            this.pictureBoxCancelFactor = new System.Windows.Forms.PictureBox();
            this.textBoxPayTime = new System.Windows.Forms.TextBox();
            this.timerPayTime = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStripFiles.SuspendLayout();
            this.TableLayoutPanelMain.SuspendLayout();
            this.tableLayoutPanelPayMentInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCancelFactor)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStripFiles
            // 
            this.contextMenuStripFiles.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStripFiles.ImageScalingSize = new System.Drawing.Size(64, 64);
            this.contextMenuStripFiles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.تنظیماتToolStripMenuItem,
            this.دربارهیماToolStripMenuItem,
            this.خروجToolStripMenuItem});
            this.contextMenuStripFiles.Name = "contextMenuStripFiles";
            this.contextMenuStripFiles.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStripFiles.Size = new System.Drawing.Size(241, 214);
            this.contextMenuStripFiles.Text = "تنظیمات";
            // 
            // تنظیماتToolStripMenuItem
            // 
            this.تنظیماتToolStripMenuItem.Image = global::GeneralKiosk.Properties.Resources.icons8_tooth_gear_setting_logo_in_computer_operating_system_60__1_1;
            this.تنظیماتToolStripMenuItem.Name = "تنظیماتToolStripMenuItem";
            this.تنظیماتToolStripMenuItem.Size = new System.Drawing.Size(240, 70);
            this.تنظیماتToolStripMenuItem.Text = "تنظیمات";
            this.تنظیماتToolStripMenuItem.Click += new System.EventHandler(this.تنظیماتToolStripMenuItem_Click);
            // 
            // دربارهیماToolStripMenuItem
            // 
            this.دربارهیماToolStripMenuItem.Image = global::GeneralKiosk.Properties.Resources.icons8_about_blue;
            this.دربارهیماToolStripMenuItem.Name = "دربارهیماToolStripMenuItem";
            this.دربارهیماToolStripMenuItem.Size = new System.Drawing.Size(240, 70);
            this.دربارهیماToolStripMenuItem.Text = "درباره ی ما";
            this.دربارهیماToolStripMenuItem.Click += new System.EventHandler(this.دربارهیماToolStripMenuItem_Click);
            // 
            // خروجToolStripMenuItem
            // 
            this.خروجToolStripMenuItem.Image = global::GeneralKiosk.Properties.Resources.icons8_exit_60__blue;
            this.خروجToolStripMenuItem.Name = "خروجToolStripMenuItem";
            this.خروجToolStripMenuItem.Size = new System.Drawing.Size(240, 70);
            this.خروجToolStripMenuItem.Text = "خروج";
            this.خروجToolStripMenuItem.Click += new System.EventHandler(this.خروجToolStripMenuItem_Click);
            // 
            // TableLayoutPanelMain
            // 
            this.TableLayoutPanelMain.BackColor = System.Drawing.SystemColors.Control;
            this.TableLayoutPanelMain.ColumnCount = 5;
            this.TableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.TableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.TableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.TableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.TableLayoutPanelMain.Controls.Add(this.panelRasisInfo, 2, 4);
            this.TableLayoutPanelMain.Controls.Add(this.textBoxName, 2, 1);
            this.TableLayoutPanelMain.Controls.Add(this.tableLayoutPanelPayMentInfo, 2, 2);
            this.TableLayoutPanelMain.Controls.Add(this.uiButtonPay, 2, 3);
            this.TableLayoutPanelMain.Controls.Add(this.pictureBoxCancelFactor, 3, 1);
            this.TableLayoutPanelMain.Controls.Add(this.textBoxPayTime, 1, 1);
            this.TableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TableLayoutPanelMain.Name = "TableLayoutPanelMain";
            this.TableLayoutPanelMain.RowCount = 5;
            this.TableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.TableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.TableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.57839F));
            this.TableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.TableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.42161F));
            this.TableLayoutPanelMain.Size = new System.Drawing.Size(984, 661);
            this.TableLayoutPanelMain.TabIndex = 0;
            // 
            // panelRasisInfo
            // 
            this.panelRasisInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRasisInfo.Location = new System.Drawing.Point(83, 606);
            this.panelRasisInfo.Name = "panelRasisInfo";
            this.panelRasisInfo.Size = new System.Drawing.Size(818, 52);
            this.panelRasisInfo.TabIndex = 39;
            // 
            // textBoxName
            // 
            this.textBoxName.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBoxName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxName.Font = new System.Drawing.Font("B Yekan", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.textBoxName.Location = new System.Drawing.Point(83, 30);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(818, 100);
            this.textBoxName.TabIndex = 41;
            this.textBoxName.Text = "شرکت ارتباطات پیوسته ایرانیان";
            this.textBoxName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanelPayMentInfo
            // 
            this.tableLayoutPanelPayMentInfo.ColumnCount = 2;
            this.tableLayoutPanelPayMentInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanelPayMentInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelPayMentInfo.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanelPayMentInfo.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanelPayMentInfo.Controls.Add(this.textBoxPatientName, 1, 0);
            this.tableLayoutPanelPayMentInfo.Controls.Add(this.textBoxReceptionCode, 1, 1);
            this.tableLayoutPanelPayMentInfo.Controls.Add(this.textBoxServiceDescription, 1, 2);
            this.tableLayoutPanelPayMentInfo.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanelPayMentInfo.Controls.Add(this.textBoxEndRate, 1, 3);
            this.tableLayoutPanelPayMentInfo.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanelPayMentInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelPayMentInfo.Location = new System.Drawing.Point(83, 133);
            this.tableLayoutPanelPayMentInfo.Name = "tableLayoutPanelPayMentInfo";
            this.tableLayoutPanelPayMentInfo.RowCount = 4;
            this.tableLayoutPanelPayMentInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.49193F));
            this.tableLayoutPanelPayMentInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.49194F));
            this.tableLayoutPanelPayMentInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.79607F));
            this.tableLayoutPanelPayMentInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.22005F));
            this.tableLayoutPanelPayMentInfo.Size = new System.Drawing.Size(818, 267);
            this.tableLayoutPanelPayMentInfo.TabIndex = 42;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("B Yekan", 27.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.DarkMagenta;
            this.label3.Location = new System.Drawing.Point(571, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(244, 87);
            this.label3.TabIndex = 58;
            this.label3.Text = "شرح خدمت :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("B Yekan", 27.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.DarkMagenta;
            this.label2.Location = new System.Drawing.Point(571, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(244, 65);
            this.label2.TabIndex = 57;
            this.label2.Text = "شماره رسید :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBoxPatientName
            // 
            this.textBoxPatientName.AutoSize = true;
            this.textBoxPatientName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxPatientName.Font = new System.Drawing.Font("B Yekan", 27.75F, System.Drawing.FontStyle.Bold);
            this.textBoxPatientName.ForeColor = System.Drawing.Color.Blue;
            this.textBoxPatientName.Location = new System.Drawing.Point(3, 0);
            this.textBoxPatientName.Name = "textBoxPatientName";
            this.textBoxPatientName.Size = new System.Drawing.Size(562, 65);
            this.textBoxPatientName.TabIndex = 55;
            this.textBoxPatientName.Text = "PatientName";
            // 
            // textBoxReceptionCode
            // 
            this.textBoxReceptionCode.AutoSize = true;
            this.textBoxReceptionCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxReceptionCode.Font = new System.Drawing.Font("B Yekan", 27.75F, System.Drawing.FontStyle.Bold);
            this.textBoxReceptionCode.ForeColor = System.Drawing.Color.Blue;
            this.textBoxReceptionCode.Location = new System.Drawing.Point(3, 65);
            this.textBoxReceptionCode.Name = "textBoxReceptionCode";
            this.textBoxReceptionCode.Size = new System.Drawing.Size(562, 65);
            this.textBoxReceptionCode.TabIndex = 54;
            this.textBoxReceptionCode.Text = "ReceptionCode";
            // 
            // textBoxServiceDescription
            // 
            this.textBoxServiceDescription.AutoSize = true;
            this.textBoxServiceDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxServiceDescription.Font = new System.Drawing.Font("B Yekan", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.textBoxServiceDescription.ForeColor = System.Drawing.Color.Blue;
            this.textBoxServiceDescription.Location = new System.Drawing.Point(3, 130);
            this.textBoxServiceDescription.Name = "textBoxServiceDescription";
            this.textBoxServiceDescription.Size = new System.Drawing.Size(562, 87);
            this.textBoxServiceDescription.TabIndex = 53;
            this.textBoxServiceDescription.Text = "ServiceDescription";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("B Yekan", 27.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.DarkMagenta;
            this.label1.Location = new System.Drawing.Point(571, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 65);
            this.label1.TabIndex = 56;
            this.label1.Text = "نام بیمار :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBoxEndRate
            // 
            this.textBoxEndRate.AutoSize = true;
            this.textBoxEndRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxEndRate.Font = new System.Drawing.Font("B Yekan", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.textBoxEndRate.ForeColor = System.Drawing.Color.Red;
            this.textBoxEndRate.Location = new System.Drawing.Point(3, 217);
            this.textBoxEndRate.Name = "textBoxEndRate";
            this.textBoxEndRate.Size = new System.Drawing.Size(562, 50);
            this.textBoxEndRate.TabIndex = 59;
            this.textBoxEndRate.Text = "1,000,000,000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("B Yekan", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.ForeColor = System.Drawing.Color.DarkMagenta;
            this.label4.Location = new System.Drawing.Point(571, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(244, 50);
            this.label4.TabIndex = 60;
            this.label4.Text = "مبلغ :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // uiButtonPay
            // 
            this.uiButtonPay.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.uiButtonPay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiButtonPay.Font = new System.Drawing.Font("B Yekan", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.uiButtonPay.Location = new System.Drawing.Point(83, 406);
            this.uiButtonPay.Name = "uiButtonPay";
            this.uiButtonPay.Size = new System.Drawing.Size(818, 194);
            this.uiButtonPay.StateStyles.FormatStyle.BackColor = System.Drawing.Color.Brown;
            this.uiButtonPay.StateStyles.FormatStyle.ForeColor = System.Drawing.Color.White;
            this.uiButtonPay.TabIndex = 44;
            this.uiButtonPay.TabStop = false;
            this.uiButtonPay.Text = "پرداخت";
            this.uiButtonPay.UseCompatibleTextRendering = false;
            this.uiButtonPay.UseThemes = false;
            this.uiButtonPay.Click += new System.EventHandler(this.uiButtonPay_Click);
            this.uiButtonPay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uiButtonPay_KeyDown);
            this.uiButtonPay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.uiButtonPay_KeyPress);
            // 
            // pictureBoxCancelFactor
            // 
            this.pictureBoxCancelFactor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxCancelFactor.Image = global::GeneralKiosk.Properties.Resources.icons8_cancel_480;
            this.pictureBoxCancelFactor.Location = new System.Drawing.Point(13, 33);
            this.pictureBoxCancelFactor.Name = "pictureBoxCancelFactor";
            this.pictureBoxCancelFactor.Size = new System.Drawing.Size(64, 94);
            this.pictureBoxCancelFactor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxCancelFactor.TabIndex = 45;
            this.pictureBoxCancelFactor.TabStop = false;
            this.pictureBoxCancelFactor.Click += new System.EventHandler(this.pictureBoxCancelFactor_Click);
            // 
            // textBoxPayTime
            // 
            this.textBoxPayTime.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBoxPayTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPayTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxPayTime.Font = new System.Drawing.Font("B Yekan", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.textBoxPayTime.ForeColor = System.Drawing.Color.Red;
            this.textBoxPayTime.Location = new System.Drawing.Point(907, 33);
            this.textBoxPayTime.Multiline = true;
            this.textBoxPayTime.Name = "textBoxPayTime";
            this.textBoxPayTime.Size = new System.Drawing.Size(64, 94);
            this.textBoxPayTime.TabIndex = 46;
            this.textBoxPayTime.TabStop = false;
            this.textBoxPayTime.Text = "30";
            this.textBoxPayTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timerPayTime
            // 
            this.timerPayTime.Enabled = true;
            this.timerPayTime.Interval = 1000;
            this.timerPayTime.Tick += new System.EventHandler(this.timerPayTime_Tick);
            // 
            // FormpatientInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.ControlBox = false;
            this.Controls.Add(this.TableLayoutPanelMain);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormpatientInfo";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "راهکار های نرم افزاری رسیس - کیوسک";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form23_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMainUI_KeyDown);
            this.contextMenuStripFiles.ResumeLayout(false);
            this.TableLayoutPanelMain.ResumeLayout(false);
            this.TableLayoutPanelMain.PerformLayout();
            this.tableLayoutPanelPayMentInfo.ResumeLayout(false);
            this.tableLayoutPanelPayMentInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCancelFactor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel TableLayoutPanelMain;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripFiles;
        private System.Windows.Forms.ToolStripMenuItem تنظیماتToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem دربارهیماToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem خروجToolStripMenuItem;
        private System.Windows.Forms.Panel panelRasisInfo;
        private System.Windows.Forms.Label textBoxName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelPayMentInfo;
        private Janus.Windows.EditControls.UIButton uiButtonPay;
        private System.Windows.Forms.PictureBox pictureBoxCancelFactor;
        private System.Windows.Forms.Timer timerPayTime;
        private System.Windows.Forms.TextBox textBoxPayTime;
        private System.Windows.Forms.Label textBoxServiceDescription;
        private System.Windows.Forms.Label textBoxPatientName;
        private System.Windows.Forms.Label textBoxReceptionCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label textBoxEndRate;
        private System.Windows.Forms.Label label4;
    }
}