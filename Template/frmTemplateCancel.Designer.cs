namespace RasisSolutionsManagement.GUI.Template
{
    partial class FrmTemplateCancel
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
            this.PanelButtom = new System.Windows.Forms.Panel();
            this.UiButtonExit = new Janus.Windows.EditControls.UIButton();
            this.PanelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UiGroupBoxMainData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiGroupBoxButtom)).BeginInit();
            this.UiGroupBoxButtom.SuspendLayout();
            this.PanelButtom.SuspendLayout();
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
            this.UiGroupBoxButtom.Controls.Add(this.PanelButtom);
            this.UiGroupBoxButtom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.UiGroupBoxButtom.Location = new System.Drawing.Point(0, 306);
            this.UiGroupBoxButtom.Name = "UiGroupBoxButtom";
            this.UiGroupBoxButtom.Size = new System.Drawing.Size(584, 56);
            this.UiGroupBoxButtom.TabIndex = 1;
            this.UiGroupBoxButtom.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007;
            // 
            // PanelButtom
            // 
            this.PanelButtom.Controls.Add(this.UiButtonExit);
            this.PanelButtom.Dock = System.Windows.Forms.DockStyle.Right;
            this.PanelButtom.Location = new System.Drawing.Point(451, 8);
            this.PanelButtom.Name = "PanelButtom";
            this.PanelButtom.Size = new System.Drawing.Size(130, 45);
            this.PanelButtom.TabIndex = 0;
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
            this.UiButtonExit.TabIndex = 0;
            this.UiButtonExit.TabStop = false;
            this.UiButtonExit.Text = "خروج";
            this.UiButtonExit.ToolTipText = "دکمه میانبر Ctrl+X";
            // 
            // FrmTemplateCancel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.PanelMain);
            this.MaximizeBox = true;
            this.Name = "FrmTemplateCancel";
            this.Text = "FrmTemplateCancel";
            this.PanelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UiGroupBoxMainData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiGroupBoxButtom)).EndInit();
            this.UiGroupBoxButtom.ResumeLayout(false);
            this.PanelButtom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel PanelMain;
        protected Janus.Windows.EditControls.UIGroupBox UiGroupBoxButtom;
        protected Janus.Windows.EditControls.UIGroupBox UiGroupBoxMainData;
        protected Janus.Windows.EditControls.UIButton UiButtonExit;
        protected System.Windows.Forms.Panel PanelButtom;
    }
}