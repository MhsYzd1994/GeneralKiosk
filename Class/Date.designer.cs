namespace GeneralKiosk
{
    partial class UserDate
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxDate = new System.Windows.Forms.TextBox();
            this.FaDatePickerMain = new FarsiLibrary.Win.Controls.FADatePicker();
            this.ButtonDropDown = new Janus.Windows.EditControls.UIButton();
            this.SuspendLayout();
            // 
            // textBoxDate
            // 
            this.textBoxDate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxDate.Location = new System.Drawing.Point(20, 0);
            this.textBoxDate.MaximumSize = new System.Drawing.Size(250, 23);
            this.textBoxDate.MaxLength = 10;
            this.textBoxDate.MinimumSize = new System.Drawing.Size(75, 23);
            this.textBoxDate.Multiline = true;
            this.textBoxDate.Name = "textBoxDate";
            this.textBoxDate.Size = new System.Drawing.Size(80, 23);
            this.textBoxDate.TabIndex = 0;
            this.textBoxDate.Click += new System.EventHandler(this.TextBoxDate_Click);
            this.textBoxDate.Enter += new System.EventHandler(this.TextBoxDate_Enter);
            this.textBoxDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxDate_KeyPress);
            this.textBoxDate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBoxDate_KeyUp);
            this.textBoxDate.Leave += new System.EventHandler(this.TextBoxDate_Leave);
            // 
            // FaDatePickerMain
            // 
            this.FaDatePickerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FaDatePickerMain.Location = new System.Drawing.Point(0, 0);
            this.FaDatePickerMain.Name = "FaDatePickerMain";
            this.FaDatePickerMain.Size = new System.Drawing.Size(100, 23);
            this.FaDatePickerMain.TabIndex = 2;
            this.FaDatePickerMain.TabStop = false;
            this.FaDatePickerMain.SelectedDateTimeChanged += new System.EventHandler(this.FaDatePicker1_SelectedDateTimeChanged);
            this.FaDatePickerMain.Click += new System.EventHandler(this.FaDatePicker1_Click);
            // 
            // ButtonDropDown
            // 
            this.ButtonDropDown.Dock = System.Windows.Forms.DockStyle.Left;
            this.ButtonDropDown.Image = global::GeneralKiosk.Properties.Resources.arrow_down;
            this.ButtonDropDown.Location = new System.Drawing.Point(0, 0);
            this.ButtonDropDown.Name = "ButtonDropDown";
            this.ButtonDropDown.Size = new System.Drawing.Size(23, 23);
            this.ButtonDropDown.TabIndex = 1;
            this.ButtonDropDown.TabStop = false;
            this.ButtonDropDown.Click += new System.EventHandler(this.UiButton1_Click);
            // 
            // UserDate
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.ButtonDropDown);
            this.Controls.Add(this.textBoxDate);
            this.Controls.Add(this.FaDatePickerMain);
            this.MaximumSize = new System.Drawing.Size(250, 23);
            this.MinimumSize = new System.Drawing.Size(100, 23);
            this.Name = "UserDate";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(100, 23);
            this.Enter += new System.EventHandler(this.UserDate_Enter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxDate;
        private Janus.Windows.EditControls.UIButton ButtonDropDown;
        private FarsiLibrary.Win.Controls.FADatePicker FaDatePickerMain;
    }
}
