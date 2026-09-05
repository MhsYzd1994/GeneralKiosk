namespace GeneralKiosk.Template
{
    partial class FrmTemplateList
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
            this.UiGroupBoxBottom = new Janus.Windows.EditControls.UIGroupBox();
            this.PanelButton = new System.Windows.Forms.Panel();
            this.UiButtonExit = new Janus.Windows.EditControls.UIButton();
            this.UiButtonDelete = new Janus.Windows.EditControls.UIButton();
            this.UiButtonNew = new Janus.Windows.EditControls.UIButton();
            this.UiButtonEdit = new Janus.Windows.EditControls.UIButton();
            ((System.ComponentModel.ISupportInitialize)(this.UiGroupBoxMainData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiGroupBoxBottom)).BeginInit();
            this.UiGroupBoxBottom.SuspendLayout();
            this.PanelButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // UiGroupBoxMainData
            // 
            this.UiGroupBoxMainData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UiGroupBoxMainData.Location = new System.Drawing.Point(0, -1);
            this.UiGroupBoxMainData.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.UiGroupBoxMainData.Name = "UiGroupBoxMainData";
            this.UiGroupBoxMainData.Size = new System.Drawing.Size(696, 306);
            this.UiGroupBoxMainData.TabIndex = 0;
            this.UiGroupBoxMainData.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007;
            // 
            // UiGroupBoxBottom
            // 
            this.UiGroupBoxBottom.Controls.Add(this.PanelButton);
            this.UiGroupBoxBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.UiGroupBoxBottom.Location = new System.Drawing.Point(0, 305);
            this.UiGroupBoxBottom.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.UiGroupBoxBottom.Name = "UiGroupBoxBottom";
            this.UiGroupBoxBottom.Size = new System.Drawing.Size(697, 57);
            this.UiGroupBoxBottom.TabIndex = 1;
            this.UiGroupBoxBottom.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007;
            // 
            // PanelButton
            // 
            this.PanelButton.Controls.Add(this.UiButtonDelete);
            this.PanelButton.Controls.Add(this.UiButtonNew);
            this.PanelButton.Controls.Add(this.UiButtonExit);
            this.PanelButton.Controls.Add(this.UiButtonEdit);
            this.PanelButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.PanelButton.Location = new System.Drawing.Point(189, 8);
            this.PanelButton.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.PanelButton.Name = "PanelButton";
            this.PanelButton.Size = new System.Drawing.Size(505, 46);
            this.PanelButton.TabIndex = 0;
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
            this.UiButtonExit.TabIndex = 3;
            this.UiButtonExit.TabStop = false;
            this.UiButtonExit.Text = "خروج";
            this.UiButtonExit.ToolTipText = "دکمه میانبر Ctrl+X";
            // 
            // UiButtonDelete
            // 
            this.UiButtonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UiButtonDelete.Image = global::GeneralKiosk.Properties.Resources.delete1;
            this.UiButtonDelete.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Far;
            this.UiButtonDelete.ImageSize = new System.Drawing.Size(32, 32);
            this.UiButtonDelete.Location = new System.Drawing.Point(130, 2);
            this.UiButtonDelete.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.UiButtonDelete.Name = "UiButtonDelete";
            this.UiButtonDelete.Size = new System.Drawing.Size(120, 39);
            this.UiButtonDelete.TabIndex = 2;
            this.UiButtonDelete.TabStop = false;
            this.UiButtonDelete.Text = "حذف";
            this.UiButtonDelete.ToolTipText = "دکمه میانبر Ctrl+D";
            // 
            // UiButtonNew
            // 
            this.UiButtonNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UiButtonNew.Image = global::GeneralKiosk.Properties.Resources.Add;
            this.UiButtonNew.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Far;
            this.UiButtonNew.ImageSize = new System.Drawing.Size(32, 32);
            this.UiButtonNew.Location = new System.Drawing.Point(380, 2);
            this.UiButtonNew.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.UiButtonNew.Name = "UiButtonNew";
            this.UiButtonNew.Size = new System.Drawing.Size(120, 39);
            this.UiButtonNew.TabIndex = 0;
            this.UiButtonNew.Text = "آیتم جدید";
            this.UiButtonNew.ToolTipText = "دکمه میانبر Ctrl+A";
            // 
            // UiButtonEdit
            // 
            this.UiButtonEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UiButtonEdit.Image = global::GeneralKiosk.Properties.Resources.Edit3;
            this.UiButtonEdit.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Far;
            this.UiButtonEdit.ImageSize = new System.Drawing.Size(32, 32);
            this.UiButtonEdit.Location = new System.Drawing.Point(255, 2);
            this.UiButtonEdit.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.UiButtonEdit.Name = "UiButtonEdit";
            this.UiButtonEdit.Size = new System.Drawing.Size(120, 39);
            this.UiButtonEdit.TabIndex = 1;
            this.UiButtonEdit.Text = "ویرایش";
            this.UiButtonEdit.ToolTipText = "دکمه میانبر Ctrl+E";
            // 
            // FrmTemplateList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(697, 362);
            this.Controls.Add(this.UiGroupBoxMainData);
            this.Controls.Add(this.UiGroupBoxBottom);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "FrmTemplateList";
            this.Text = "FrmTemplateList";
            this.Load += new System.EventHandler(this.FrmTemplateList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UiGroupBoxMainData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiGroupBoxBottom)).EndInit();
            this.UiGroupBoxBottom.ResumeLayout(false);
            this.PanelButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel PanelButton;
        public Janus.Windows.EditControls.UIButton UiButtonNew;
        public Janus.Windows.EditControls.UIButton UiButtonEdit;
        public Janus.Windows.EditControls.UIButton UiButtonDelete;
        public Janus.Windows.EditControls.UIButton UiButtonExit;
        public Janus.Windows.EditControls.UIGroupBox UiGroupBoxMainData;
        public Janus.Windows.EditControls.UIGroupBox UiGroupBoxBottom;
    }
}