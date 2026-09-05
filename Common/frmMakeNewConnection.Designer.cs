namespace GeneralKiosk
{
    partial class FrmMakeNewConnection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMakeNewConnection));
            this.TextBoxDataSource = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TextBoxInitialCatalog = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TextBoxUserID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TextBoxPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TextBoxConnectionTimeout = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.TextBoxResult = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TextBoxID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TextBoxDataSource
            // 
            this.TextBoxDataSource.Location = new System.Drawing.Point(219, 14);
            this.TextBoxDataSource.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TextBoxDataSource.MaxLength = 50;
            this.TextBoxDataSource.Name = "TextBoxDataSource";
            this.TextBoxDataSource.Size = new System.Drawing.Size(354, 31);
            this.TextBoxDataSource.TabIndex = 0;
            this.TextBoxDataSource.Text = "SERVER\\SQLE2014";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Data Source";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 62);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Initial Catalog";
            // 
            // TextBoxInitialCatalog
            // 
            this.TextBoxInitialCatalog.Location = new System.Drawing.Point(219, 58);
            this.TextBoxInitialCatalog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TextBoxInitialCatalog.MaxLength = 50;
            this.TextBoxInitialCatalog.Name = "TextBoxInitialCatalog";
            this.TextBoxInitialCatalog.Size = new System.Drawing.Size(354, 31);
            this.TextBoxInitialCatalog.TabIndex = 2;
            this.TextBoxInitialCatalog.Text = "SepPay";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 106);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "User ID";
            // 
            // TextBoxUserID
            // 
            this.TextBoxUserID.Location = new System.Drawing.Point(219, 102);
            this.TextBoxUserID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TextBoxUserID.MaxLength = 50;
            this.TextBoxUserID.Name = "TextBoxUserID";
            this.TextBoxUserID.Size = new System.Drawing.Size(354, 31);
            this.TextBoxUserID.TabIndex = 4;
            this.TextBoxUserID.Text = "SepPay";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 150);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Password";
            // 
            // TextBoxPassword
            // 
            this.TextBoxPassword.Location = new System.Drawing.Point(219, 145);
            this.TextBoxPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TextBoxPassword.MaxLength = 50;
            this.TextBoxPassword.Name = "TextBoxPassword";
            this.TextBoxPassword.PasswordChar = '*';
            this.TextBoxPassword.Size = new System.Drawing.Size(354, 31);
            this.TextBoxPassword.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 194);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(204, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "Connection Timeout";
            // 
            // TextBoxConnectionTimeout
            // 
            this.TextBoxConnectionTimeout.Location = new System.Drawing.Point(219, 189);
            this.TextBoxConnectionTimeout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TextBoxConnectionTimeout.MaxLength = 3;
            this.TextBoxConnectionTimeout.Name = "TextBoxConnectionTimeout";
            this.TextBoxConnectionTimeout.Size = new System.Drawing.Size(74, 31);
            this.TextBoxConnectionTimeout.TabIndex = 8;
            this.TextBoxConnectionTimeout.Text = "60";
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(22, 444);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(112, 36);
            this.buttonOK.TabIndex = 10;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(144, 444);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(112, 36);
            this.buttonClose.TabIndex = 11;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // TextBoxResult
            // 
            this.TextBoxResult.Location = new System.Drawing.Point(22, 277);
            this.TextBoxResult.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TextBoxResult.MaxLength = 3;
            this.TextBoxResult.Multiline = true;
            this.TextBoxResult.Name = "TextBoxResult";
            this.TextBoxResult.ReadOnly = true;
            this.TextBoxResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextBoxResult.Size = new System.Drawing.Size(550, 156);
            this.TextBoxResult.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 238);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 25);
            this.label6.TabIndex = 14;
            this.label6.Text = "ID :";
            // 
            // TextBoxID
            // 
            this.TextBoxID.Location = new System.Drawing.Point(219, 233);
            this.TextBoxID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TextBoxID.MaxLength = 50;
            this.TextBoxID.Name = "TextBoxID";
            this.TextBoxID.ReadOnly = true;
            this.TextBoxID.Size = new System.Drawing.Size(354, 31);
            this.TextBoxID.TabIndex = 13;
            // 
            // FrmMakeNewConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 498);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TextBoxID);
            this.Controls.Add(this.TextBoxResult);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TextBoxConnectionTimeout);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TextBoxPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TextBoxUserID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TextBoxInitialCatalog);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextBoxDataSource);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MaximizeBox = false;
            this.Name = "FrmMakeNewConnection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Make New Connection";
            this.Load += new System.EventHandler(this.FrmMakeNewConnection_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBoxDataSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextBoxInitialCatalog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TextBoxUserID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TextBoxPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TextBoxConnectionTimeout;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.TextBox TextBoxResult;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TextBoxID;
    }
}