namespace GeneralKiosk.Template
{ 
    partial class FrmTemplateOKCancel
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
            this.UiGroupBoxButtom = new Janus.Windows.EditControls.UIGroupBox();
            this.PanelButton = new System.Windows.Forms.Panel();
            this.UiButtonSave = new Janus.Windows.EditControls.UIButton();
            this.UiButtonExit = new Janus.Windows.EditControls.UIButton();
            this.UiGroupBoxMainData = new Janus.Windows.EditControls.UIGroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.UiGroupBoxButtom)).BeginInit();
            this.UiGroupBoxButtom.SuspendLayout();
            this.PanelButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UiGroupBoxMainData)).BeginInit();
            this.SuspendLayout();
            // 
            // UiGroupBoxButtom
            // 
            this.UiGroupBoxButtom.Controls.Add(this.PanelButton);
            this.UiGroupBoxButtom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.UiGroupBoxButtom.Location = new System.Drawing.Point(0, 306);
            this.UiGroupBoxButtom.Name = "UiGroupBoxButtom";
            this.UiGroupBoxButtom.Size = new System.Drawing.Size(584, 56);
            this.UiGroupBoxButtom.TabIndex = 1;
            this.UiGroupBoxButtom.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007;
            // 
            // PanelButton
            // 
            this.PanelButton.Controls.Add(this.UiButtonSave);
            this.PanelButton.Controls.Add(this.UiButtonExit);
            this.PanelButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.PanelButton.Location = new System.Drawing.Point(326, 8);
            this.PanelButton.Name = "PanelButton";
            this.PanelButton.Size = new System.Drawing.Size(255, 45);
            this.PanelButton.TabIndex = 0;
            // 
            // UiButtonSave
            // 
            this.UiButtonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            //this.UiButtonSave.Image = global::GeneralKiosk.r.re;
            this.UiButtonSave.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Far;
            this.UiButtonSave.ImageSize = new System.Drawing.Size(32, 32);
            this.UiButtonSave.Location = new System.Drawing.Point(130, 3);
            this.UiButtonSave.Name = "UiButtonSave";
            this.UiButtonSave.Size = new System.Drawing.Size(120, 40);
            this.UiButtonSave.TabIndex = 0;
            this.UiButtonSave.Text = "ثبت";
            this.UiButtonSave.ToolTipText = "دکمه میانبر Ctrl+S";
            // 
            // UiButtonExit
            // 
            this.UiButtonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            //this.UiButtonExit.Image = global::RasisSolutionsManagement.GUI.Properties.Resources.RasisExit;
            this.UiButtonExit.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Far;
            this.UiButtonExit.ImageSize = new System.Drawing.Size(32, 32);
            this.UiButtonExit.Location = new System.Drawing.Point(5, 3);
            this.UiButtonExit.Name = "UiButtonExit";
            this.UiButtonExit.Size = new System.Drawing.Size(120, 40);
            this.UiButtonExit.TabIndex = 1;
            this.UiButtonExit.TabStop = false;
            this.UiButtonExit.Text = "خروج";
            this.UiButtonExit.ToolTipText = "دکمه میانبر Ctrl+X";
            // 
            // UiGroupBoxMainData
            // 
            this.UiGroupBoxMainData.Location = new System.Drawing.Point(0, 0);
            this.UiGroupBoxMainData.Name = "UiGroupBoxMainData";
            this.UiGroupBoxMainData.Size = new System.Drawing.Size(584, 306);
            this.UiGroupBoxMainData.TabIndex = 2;
            this.UiGroupBoxMainData.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007;
            // 
            // FrmTemplateOKCancel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.UiGroupBoxMainData);
            this.Controls.Add(this.UiGroupBoxButtom);
            this.Name = "FrmTemplateOKCancel";
            this.Text = "FrmTemplateOKCancel";
            ((System.ComponentModel.ISupportInitialize)(this.UiGroupBoxButtom)).EndInit();
            this.UiGroupBoxButtom.ResumeLayout(false);
            this.PanelButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UiGroupBoxMainData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        protected Janus.Windows.EditControls.UIGroupBox UiGroupBoxButtom;
        protected Janus.Windows.EditControls.UIButton UiButtonExit;
        protected System.Windows.Forms.Panel PanelButton;
        protected Janus.Windows.EditControls.UIGroupBox UiGroupBoxMainData;
        public Janus.Windows.EditControls.UIButton UiButtonSave;
    }
}