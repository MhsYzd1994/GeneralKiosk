namespace RasisSolutionsManagement.GUI.Template
{
    partial class FrmTemplateOKCancelExit
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
            this.PanelMain = new System.Windows.Forms.Panel();
            this.UiGroupBoxMainData = new Janus.Windows.EditControls.UIGroupBox();
            this.UiGroupBoxButtom = new Janus.Windows.EditControls.UIGroupBox();
            this.PanelButton = new System.Windows.Forms.Panel();
            this.UiButtonSave = new Janus.Windows.EditControls.UIButton();
            this.UiButtonExit = new Janus.Windows.EditControls.UIButton();
            this.UiButtonSaveExit = new Janus.Windows.EditControls.UIButton();
            this.PanelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UiGroupBoxMainData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiGroupBoxButtom)).BeginInit();
            this.UiGroupBoxButtom.SuspendLayout();
            this.PanelButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelMain
            // 
            this.PanelMain.Controls.Add(this.UiGroupBoxMainData);
            this.PanelMain.Controls.Add(this.UiGroupBoxButtom);
            this.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelMain.Location = new System.Drawing.Point(0, 0);
            this.PanelMain.Name = "PanelMain";
            this.PanelMain.Size = new System.Drawing.Size(584, 362);
            this.PanelMain.TabIndex = 2;
            // 
            // UiGroupBoxMainData
            // 
            this.UiGroupBoxMainData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UiGroupBoxMainData.Location = new System.Drawing.Point(0, 0);
            this.UiGroupBoxMainData.Name = "UiGroupBoxMainData";
            this.UiGroupBoxMainData.Size = new System.Drawing.Size(584, 306);
            this.UiGroupBoxMainData.TabIndex = 0;
            this.UiGroupBoxMainData.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007;
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
            this.PanelButton.Controls.Add(this.UiButtonSaveExit);
            this.PanelButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.PanelButton.Location = new System.Drawing.Point(202, 8);
            this.PanelButton.Name = "PanelButton";
            this.PanelButton.Size = new System.Drawing.Size(379, 45);
            this.PanelButton.TabIndex = 0;
            // 
            // UiButtonSave
            // 
            this.UiButtonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UiButtonSave.Image = global::RasisSolutionsManagement.GUI.Properties.Resources.RasisSave;
            this.UiButtonSave.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Far;
            this.UiButtonSave.ImageSize = new System.Drawing.Size(32, 32);
            this.UiButtonSave.Location = new System.Drawing.Point(255, 3);
            this.UiButtonSave.Name = "UiButtonSave";
            this.UiButtonSave.Size = new System.Drawing.Size(120, 40);
            this.UiButtonSave.TabIndex = 0;
            this.UiButtonSave.Text = "ثبت";
            this.UiButtonSave.ToolTipText = "دکمه میانبر Ctrl+N";
            // 
            // UiButtonExit
            // 
            this.UiButtonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UiButtonExit.Image = global::RasisSolutionsManagement.GUI.Properties.Resources.RasisExit;
            this.UiButtonExit.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Far;
            this.UiButtonExit.ImageSize = new System.Drawing.Size(32, 32);
            this.UiButtonExit.Location = new System.Drawing.Point(5, 3);
            this.UiButtonExit.Name = "UiButtonExit";
            this.UiButtonExit.Size = new System.Drawing.Size(120, 40);
            this.UiButtonExit.TabIndex = 2;
            this.UiButtonExit.TabStop = false;
            this.UiButtonExit.Text = "خروج";
            this.UiButtonExit.ToolTipText = "دکمه میانبر Ctrl+X";
            // 
            // UiButtonSaveExit
            // 
            this.UiButtonSaveExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UiButtonSaveExit.Image = global::RasisSolutionsManagement.GUI.Properties.Resources.RasisSaveExit;
            this.UiButtonSaveExit.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Far;
            this.UiButtonSaveExit.ImageSize = new System.Drawing.Size(32, 32);
            this.UiButtonSaveExit.Location = new System.Drawing.Point(130, 3);
            this.UiButtonSaveExit.Name = "UiButtonSaveExit";
            this.UiButtonSaveExit.Size = new System.Drawing.Size(120, 40);
            this.UiButtonSaveExit.TabIndex = 1;
            this.UiButtonSaveExit.Text = "ثبت و خروج";
            this.UiButtonSaveExit.ToolTipText = "دکمه میانبر Ctrl+S";
            // 
            // FrmTemplateOKCancelExit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.PanelMain);
            this.Name = "FrmTemplateOKCancelExit";
            this.Text = "FrmTemplateOK";
            this.PanelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UiGroupBoxMainData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiGroupBoxButtom)).EndInit();
            this.UiGroupBoxButtom.ResumeLayout(false);
            this.PanelButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel PanelMain;
        protected Janus.Windows.EditControls.UIGroupBox UiGroupBoxButtom;
        protected Janus.Windows.EditControls.UIGroupBox UiGroupBoxMainData;
        protected System.Windows.Forms.Panel PanelButton;
        protected Janus.Windows.EditControls.UIButton UiButtonSave;
        protected Janus.Windows.EditControls.UIButton UiButtonExit;
        protected Janus.Windows.EditControls.UIButton UiButtonSaveExit;
    }
}