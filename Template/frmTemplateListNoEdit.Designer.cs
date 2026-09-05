namespace RasisSolutionsManagement.GUI.Template
{
    partial class FrmTemplateListNoEdit
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
            this.UiGroupBoxBottom = new Janus.Windows.EditControls.UIGroupBox();
            this.PanelButton = new System.Windows.Forms.Panel();
            this.UiButtonDelete = new Janus.Windows.EditControls.UIButton();
            this.UiButtonNew = new Janus.Windows.EditControls.UIButton();
            this.UiButtonExit = new Janus.Windows.EditControls.UIButton();
            this.PanelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UiGroupBoxMainData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiGroupBoxBottom)).BeginInit();
            this.UiGroupBoxBottom.SuspendLayout();
            this.PanelButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelMain
            // 
            this.PanelMain.Controls.Add(this.UiGroupBoxMainData);
            this.PanelMain.Controls.Add(this.UiGroupBoxBottom);
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
            // UiGroupBoxBottom
            // 
            this.UiGroupBoxBottom.Controls.Add(this.PanelButton);
            this.UiGroupBoxBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.UiGroupBoxBottom.Location = new System.Drawing.Point(0, 306);
            this.UiGroupBoxBottom.Name = "UiGroupBoxBottom";
            this.UiGroupBoxBottom.Size = new System.Drawing.Size(584, 56);
            this.UiGroupBoxBottom.TabIndex = 1;
            this.UiGroupBoxBottom.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007;
            // 
            // PanelButton
            // 
            this.PanelButton.Controls.Add(this.UiButtonDelete);
            this.PanelButton.Controls.Add(this.UiButtonNew);
            this.PanelButton.Controls.Add(this.UiButtonExit);
            this.PanelButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.PanelButton.Location = new System.Drawing.Point(201, 8);
            this.PanelButton.Name = "PanelButton";
            this.PanelButton.Size = new System.Drawing.Size(380, 45);
            this.PanelButton.TabIndex = 0;
            // 
            // UiButtonDelete
            // 
            this.UiButtonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UiButtonDelete.Image = global::RasisSolutionsManagement.GUI.Properties.Resources.RasisDelete;
            this.UiButtonDelete.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Far;
            this.UiButtonDelete.ImageSize = new System.Drawing.Size(32, 32);
            this.UiButtonDelete.Location = new System.Drawing.Point(130, 3);
            this.UiButtonDelete.Name = "UiButtonDelete";
            this.UiButtonDelete.Size = new System.Drawing.Size(120, 40);
            this.UiButtonDelete.TabIndex = 1;
            this.UiButtonDelete.TabStop = false;
            this.UiButtonDelete.Text = "حذف";
            this.UiButtonDelete.ToolTipText = "دکمه میانبر Ctrl+X";
            // 
            // UiButtonNew
            // 
            this.UiButtonNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UiButtonNew.Image = global::RasisSolutionsManagement.GUI.Properties.Resources.RasisItemNew;
            this.UiButtonNew.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Far;
            this.UiButtonNew.ImageSize = new System.Drawing.Size(32, 32);
            this.UiButtonNew.Location = new System.Drawing.Point(255, 3);
            this.UiButtonNew.Name = "UiButtonNew";
            this.UiButtonNew.Size = new System.Drawing.Size(120, 40);
            this.UiButtonNew.TabIndex = 0;
            this.UiButtonNew.Text = "آیتم جدید";
            this.UiButtonNew.ToolTipText = "دکمه میانبر Ctrl+N";
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
            // FrmTemplateListNoEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.PanelMain);
            this.Name = "FrmTemplateListNoEdit";
            this.Text = "FrmTemplateListNoDel";
            this.PanelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UiGroupBoxMainData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiGroupBoxBottom)).EndInit();
            this.UiGroupBoxBottom.ResumeLayout(false);
            this.PanelButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel PanelMain;
        protected Janus.Windows.EditControls.UIGroupBox UiGroupBoxBottom;
        protected Janus.Windows.EditControls.UIGroupBox UiGroupBoxMainData;
        protected System.Windows.Forms.Panel PanelButton;
        protected Janus.Windows.EditControls.UIButton UiButtonDelete;
        protected Janus.Windows.EditControls.UIButton UiButtonNew;
        protected Janus.Windows.EditControls.UIButton UiButtonExit;
    }
}