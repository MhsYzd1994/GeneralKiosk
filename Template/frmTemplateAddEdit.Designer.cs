namespace GeneralKiosk.Template
{
    partial class FrmTemplateAddEdit
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
            this.UiGroupBoxMainData = new Janus.Windows.EditControls.UIGroupBox();
            this.UiGroupBoxButton = new Janus.Windows.EditControls.UIGroupBox();
            this.PanelButton = new System.Windows.Forms.Panel();
            this.UiButtonSaveNew = new Janus.Windows.EditControls.UIButton();
            this.UiButtonExit = new Janus.Windows.EditControls.UIButton();
            this.UiButtonSaveExit = new Janus.Windows.EditControls.UIButton();
            ((System.ComponentModel.ISupportInitialize)(this.UiGroupBoxMainData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiGroupBoxButton)).BeginInit();
            this.UiGroupBoxButton.SuspendLayout();
            this.PanelButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // UiGroupBoxMainData
            // 
            this.UiGroupBoxMainData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UiGroupBoxMainData.Location = new System.Drawing.Point(0, 0);
            this.UiGroupBoxMainData.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.UiGroupBoxMainData.Name = "UiGroupBoxMainData";
            this.UiGroupBoxMainData.Size = new System.Drawing.Size(584, 306);
            this.UiGroupBoxMainData.TabIndex = 0;
            this.UiGroupBoxMainData.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007;
            // 
            // UiGroupBoxButton
            // 
            this.UiGroupBoxButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UiGroupBoxButton.Controls.Add(this.PanelButton);
            this.UiGroupBoxButton.Location = new System.Drawing.Point(0, 306);
            this.UiGroupBoxButton.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.UiGroupBoxButton.Name = "UiGroupBoxButton";
            this.UiGroupBoxButton.Size = new System.Drawing.Size(584, 57);
            this.UiGroupBoxButton.TabIndex = 1;
            this.UiGroupBoxButton.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007;
            // 
            // PanelButton
            // 
            this.PanelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelButton.Controls.Add(this.UiButtonSaveNew);
            this.PanelButton.Controls.Add(this.UiButtonExit);
            this.PanelButton.Controls.Add(this.UiButtonSaveExit);
            this.PanelButton.Location = new System.Drawing.Point(201, 7);
            this.PanelButton.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.PanelButton.Name = "PanelButton";
            this.PanelButton.Size = new System.Drawing.Size(380, 46);
            this.PanelButton.TabIndex = 0;
            // 
            // UiButtonSaveNew
            // 
            this.UiButtonSaveNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UiButtonSaveNew.Image = global::GeneralKiosk.Properties.Resources.Save2;
            this.UiButtonSaveNew.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Far;
            this.UiButtonSaveNew.ImageSize = new System.Drawing.Size(32, 32);
            this.UiButtonSaveNew.Location = new System.Drawing.Point(255, 2);
            this.UiButtonSaveNew.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.UiButtonSaveNew.Name = "UiButtonSaveNew";
            this.UiButtonSaveNew.Size = new System.Drawing.Size(120, 39);
            this.UiButtonSaveNew.TabIndex = 0;
            this.UiButtonSaveNew.Text = "ثبت و جدید";
            this.UiButtonSaveNew.ToolTipText = "دکمه میانبر Ctrl+N";
            // 
            // UiButtonExit
            // 
            this.UiButtonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UiButtonExit.Image = global::GeneralKiosk.Properties.Resources.exit1;
            this.UiButtonExit.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Far;
            this.UiButtonExit.ImageSize = new System.Drawing.Size(32, 32);
            this.UiButtonExit.Location = new System.Drawing.Point(5, 2);
            this.UiButtonExit.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.UiButtonExit.Name = "UiButtonExit";
            this.UiButtonExit.Size = new System.Drawing.Size(120, 39);
            this.UiButtonExit.TabIndex = 2;
            this.UiButtonExit.TabStop = false;
            this.UiButtonExit.Text = "خروج";
            this.UiButtonExit.ToolTipText = "دکمه میانبر Ctrl+X";
            // 
            // UiButtonSaveExit
            // 
            this.UiButtonSaveExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UiButtonSaveExit.Image = global::GeneralKiosk.Properties.Resources.Save2;
            this.UiButtonSaveExit.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Far;
            this.UiButtonSaveExit.ImageSize = new System.Drawing.Size(32, 32);
            this.UiButtonSaveExit.Location = new System.Drawing.Point(130, 2);
            this.UiButtonSaveExit.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.UiButtonSaveExit.Name = "UiButtonSaveExit";
            this.UiButtonSaveExit.Size = new System.Drawing.Size(120, 39);
            this.UiButtonSaveExit.TabIndex = 1;
            this.UiButtonSaveExit.Text = "ثبت و خروج";
            this.UiButtonSaveExit.ToolTipText = "دکمه میانبر Ctrl+S";
            // 
            // FrmTemplateAddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.UiGroupBoxButton);
            this.Controls.Add(this.UiGroupBoxMainData);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "FrmTemplateAddEdit";
            this.Text = "FrmTemplateAddEdit";
            ((System.ComponentModel.ISupportInitialize)(this.UiGroupBoxMainData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiGroupBoxButton)).EndInit();
            this.UiGroupBoxButton.ResumeLayout(false);
            this.PanelButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected Janus.Windows.EditControls.UIGroupBox UiGroupBoxButton;
        protected Janus.Windows.EditControls.UIButton UiButtonExit;
        protected Janus.Windows.EditControls.UIGroupBox UiGroupBoxMainData;
        public Janus.Windows.EditControls.UIButton UiButtonSaveExit;
        public Janus.Windows.EditControls.UIButton UiButtonSaveNew;
        public System.Windows.Forms.Panel PanelButton;
    }
}