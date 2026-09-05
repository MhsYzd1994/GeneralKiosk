namespace GeneralKiosk
{
    partial class UserControlItemsButton
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
            this.panelMain = new System.Windows.Forms.Panel();
            this.buttonName = new System.Windows.Forms.Button();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.buttonName);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(982, 145);
            this.panelMain.TabIndex = 0;
            // 
            // buttonName
            // 
            this.buttonName.BackColor = System.Drawing.Color.White;
            this.buttonName.BackgroundImage = global::GeneralKiosk.Properties.Resources.RectangleHalf_Right;
            this.buttonName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonName.FlatAppearance.BorderSize = 0;
            this.buttonName.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonName.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonName.Location = new System.Drawing.Point(109, 3);
            this.buttonName.Name = "buttonName";
            this.buttonName.Size = new System.Drawing.Size(870, 139);
            this.buttonName.TabIndex = 0;
            this.buttonName.Text = "مهسا یزدی ";
            this.buttonName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonName.UseVisualStyleBackColor = false;
            // 
            // UserControlItemsButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panelMain);
            this.Name = "UserControlItemsButton";
            this.Size = new System.Drawing.Size(982, 145);
            this.panelMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Button buttonName;
    }
}
