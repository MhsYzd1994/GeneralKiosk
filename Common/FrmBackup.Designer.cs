namespace GeneralKiosk
{
    partial class FrmBackup
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
            this.UiGroupBoxMain = new Janus.Windows.EditControls.UIGroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.UiGroupBoxButton = new Janus.Windows.EditControls.UIGroupBox();
            this.UiButtonBackup = new Janus.Windows.EditControls.UIButton();
            this.UiButtonExit = new Janus.Windows.EditControls.UIButton();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.GridEXTran = new Janus.Windows.GridEX.GridEX();
            this.label4 = new System.Windows.Forms.Label();
            this.UiGroupBoxTop = new Janus.Windows.EditControls.UIGroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.UiButtonLoadPath = new Janus.Windows.EditControls.UIButton();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.TxtPath = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.UiGroupBoxMain)).BeginInit();
            this.UiGroupBoxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UiGroupBoxButton)).BeginInit();
            this.UiGroupBoxButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridEXTran)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiGroupBoxTop)).BeginInit();
            this.UiGroupBoxTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // UiGroupBoxMain
            // 
            this.UiGroupBoxMain.BackgroundImage = global::GeneralKiosk.Properties.Resources.RasisBackgroundBackup;
            this.UiGroupBoxMain.Controls.Add(this.UiGroupBoxTop);
            this.UiGroupBoxMain.Controls.Add(this.label3);
            this.UiGroupBoxMain.Controls.Add(this.UiGroupBoxButton);
            this.UiGroupBoxMain.Controls.Add(this.ProgressBar);
            this.UiGroupBoxMain.Controls.Add(this.GridEXTran);
            this.UiGroupBoxMain.Controls.Add(this.label4);
            this.UiGroupBoxMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UiGroupBoxMain.Location = new System.Drawing.Point(0, 0);
            this.UiGroupBoxMain.Name = "UiGroupBoxMain";
            this.UiGroupBoxMain.Size = new System.Drawing.Size(787, 507);
            this.UiGroupBoxMain.TabIndex = 90;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(11, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(765, 28);
            this.label3.TabIndex = 91;
            this.label3.Text = "لطفا بعد از تهیه فایل پشتیبان،آن را از سیستم خارج نمایید، در غیر اینصورت عواقب از" +
    " دست رفتن اطلاعات با رسیس نمی باشد";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UiGroupBoxButton
            // 
            this.UiGroupBoxButton.Controls.Add(this.UiButtonBackup);
            this.UiGroupBoxButton.Controls.Add(this.UiButtonExit);
            this.UiGroupBoxButton.Location = new System.Drawing.Point(10, 415);
            this.UiGroupBoxButton.Name = "UiGroupBoxButton";
            this.UiGroupBoxButton.Size = new System.Drawing.Size(767, 81);
            this.UiGroupBoxButton.TabIndex = 90;
            // 
            // UiButtonBackup
            // 
            this.UiButtonBackup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UiButtonBackup.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UiButtonBackup.Image = global::GeneralKiosk.Properties.Resources.RasisBackup;
            this.UiButtonBackup.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Far;
            this.UiButtonBackup.ImageSize = new System.Drawing.Size(50, 50);
            this.UiButtonBackup.Location = new System.Drawing.Point(472, 11);
            this.UiButtonBackup.Name = "UiButtonBackup";
            this.UiButtonBackup.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.UiButtonBackup.Size = new System.Drawing.Size(289, 60);
            this.UiButtonBackup.TabIndex = 0;
            this.UiButtonBackup.TabStop = false;
            this.UiButtonBackup.Text = "پشتیبان گیری";
            this.UiButtonBackup.ToolTipText = "دکمه میانبر Ctrl+B";
            this.UiButtonBackup.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.UiButtonBackup.Click += new System.EventHandler(this.UiButtonBackup_Click);
            // 
            // UiButtonExit
            // 
            this.UiButtonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UiButtonExit.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UiButtonExit.Image = global::GeneralKiosk.Properties.Resources.icons8_exit_60__blue;
            this.UiButtonExit.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Far;
            this.UiButtonExit.ImageSize = new System.Drawing.Size(50, 50);
            this.UiButtonExit.Location = new System.Drawing.Point(259, 11);
            this.UiButtonExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UiButtonExit.Name = "UiButtonExit";
            this.UiButtonExit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.UiButtonExit.Size = new System.Drawing.Size(207, 60);
            this.UiButtonExit.TabIndex = 1;
            this.UiButtonExit.TabStop = false;
            this.UiButtonExit.Text = "خروج";
            this.UiButtonExit.ToolTipText = "دکمه میانبر Ctrl+X";
            this.UiButtonExit.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.UiButtonExit.Click += new System.EventHandler(this.UiButtonExit_Click);
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(9, 386);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(767, 23);
            this.ProgressBar.TabIndex = 88;
            // 
            // GridEXTran
            // 
            this.GridEXTran.AllowCardSizing = false;
            this.GridEXTran.AllowColumnDrag = false;
            this.GridEXTran.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.GridEXTran.AlternatingColors = true;
            this.GridEXTran.DefaultFilterRowComparison = Janus.Windows.GridEX.FilterConditionOperator.Contains;
            this.GridEXTran.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.GridEXTran.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.GridEXTran.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.GridEXTran.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.GridEXTran.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.GridEXTran.GroupByBoxVisible = false;
            this.GridEXTran.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.GridEXTran.KeepRowSettings = true;
            this.GridEXTran.Location = new System.Drawing.Point(10, 171);
            this.GridEXTran.Name = "GridEXTran";
            this.GridEXTran.Size = new System.Drawing.Size(766, 209);
            this.GridEXTran.TabIndex = 85;
            this.GridEXTran.TabStop = false;
            this.GridEXTran.VisualStyle = Janus.Windows.GridEX.VisualStyle.VS2010;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(572, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(206, 16);
            this.label4.TabIndex = 89;
            this.label4.Text = "تاریخچه بک آپ قبلی (10 گردش آخر)";
            // 
            // UiGroupBoxTop
            // 
            this.UiGroupBoxTop.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.UiGroupBoxTop.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.UiGroupBoxTop.Controls.Add(this.label19);
            this.UiGroupBoxTop.Controls.Add(this.UiButtonLoadPath);
            this.UiGroupBoxTop.Controls.Add(this.label17);
            this.UiGroupBoxTop.Controls.Add(this.label18);
            this.UiGroupBoxTop.Controls.Add(this.TxtPath);
            this.UiGroupBoxTop.Location = new System.Drawing.Point(9, 42);
            this.UiGroupBoxTop.Name = "UiGroupBoxTop";
            this.UiGroupBoxTop.Size = new System.Drawing.Size(767, 102);
            this.UiGroupBoxTop.TabIndex = 93;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.label19.ForeColor = System.Drawing.Color.Red;
            this.label19.Location = new System.Drawing.Point(460, 40);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(178, 16);
            this.label19.TabIndex = 4;
            this.label19.Text = "مسیر حتما باید در سرور باشد .";
            // 
            // UiButtonLoadPath
            // 
            this.UiButtonLoadPath.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.UiButtonLoadPath.Location = new System.Drawing.Point(25, 49);
            this.UiButtonLoadPath.Name = "UiButtonLoadPath";
            this.UiButtonLoadPath.Size = new System.Drawing.Size(50, 50);
            this.UiButtonLoadPath.TabIndex = 3;
            this.UiButtonLoadPath.TabStop = false;
            this.UiButtonLoadPath.Text = "...";
            this.UiButtonLoadPath.ToolTipText = "انتخاب";
            this.UiButtonLoadPath.UseThemes = false;
            this.UiButtonLoadPath.Click += new System.EventHandler(this.UiButtonLoadPath_Click_1);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(160, 15);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(478, 16);
            this.label17.TabIndex = 2;
            this.label17.Text = "لطفا از گذاشتن نام فارسی خودداری کنید. مسیر پشتیبان گیری بهتر است در :C نباشد";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(641, 70);
            this.label18.Name = "label18";
            this.label18.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label18.Size = new System.Drawing.Size(106, 16);
            this.label18.TabIndex = 1;
            this.label18.Text = "مسیر در سرور :";
            // 
            // TxtPath
            // 
            this.TxtPath.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.TxtPath.Location = new System.Drawing.Point(81, 67);
            this.TxtPath.Name = "TxtPath";
            this.TxtPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TxtPath.Size = new System.Drawing.Size(554, 23);
            this.TxtPath.TabIndex = 0;
            this.TxtPath.TabStop = false;
            // 
            // FrmBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(787, 507);
            this.Controls.Add(this.UiGroupBoxMain);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmBackup";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تهیه فایل پشتیبان از نرم افزار رَسیس";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmBackup_FormClosing);
            this.Load += new System.EventHandler(this.FrmBackup_Load);
            this.Shown += new System.EventHandler(this.FrmBackup_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmBackup_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.UiGroupBoxMain)).EndInit();
            this.UiGroupBoxMain.ResumeLayout(false);
            this.UiGroupBoxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UiGroupBoxButton)).EndInit();
            this.UiGroupBoxButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridEXTran)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiGroupBoxTop)).EndInit();
            this.UiGroupBoxTop.ResumeLayout(false);
            this.UiGroupBoxTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Janus.Windows.GridEX.GridEX GridEXTran;
        private Janus.Windows.EditControls.UIButton UiButtonBackup;
        private Janus.Windows.EditControls.UIButton UiButtonExit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private Janus.Windows.EditControls.UIGroupBox UiGroupBoxMain;
        private Janus.Windows.EditControls.UIGroupBox UiGroupBoxButton;
        private System.Windows.Forms.Label label3;
        private Janus.Windows.EditControls.UIGroupBox UiGroupBoxTop;
        private System.Windows.Forms.Label label19;
        private Janus.Windows.EditControls.UIButton UiButtonLoadPath;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox TxtPath;
    }
}