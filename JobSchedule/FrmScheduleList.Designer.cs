namespace GeneralKiosk
{
    partial class FrmScheduleList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmScheduleList));
            this.GridEXScheduleList = new Janus.Windows.GridEX.GridEX();
            ((System.ComponentModel.ISupportInitialize)(this.UiGroupBoxMainData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiGroupBoxBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridEXScheduleList)).BeginInit();
            this.SuspendLayout();
            // 
            // UiButtonNew
            // 
            this.UiButtonNew.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UiButtonNew.Location = new System.Drawing.Point(380, 2);
            this.UiButtonNew.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.UiButtonNew.Size = new System.Drawing.Size(120, 39);
            this.UiButtonNew.Click += new System.EventHandler(this.UiButtonNew_Click);
            // 
            // UiButtonEdit
            // 
            this.UiButtonEdit.Location = new System.Drawing.Point(255, 2);
            this.UiButtonEdit.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.UiButtonEdit.Size = new System.Drawing.Size(120, 39);
            this.UiButtonEdit.Click += new System.EventHandler(this.UiButtonEdit_Click);
            // 
            // UiButtonDelete
            // 
            this.UiButtonDelete.Location = new System.Drawing.Point(130, 2);
            this.UiButtonDelete.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.UiButtonDelete.Size = new System.Drawing.Size(120, 39);
            this.UiButtonDelete.Click += new System.EventHandler(this.UiButtonDelete_Click);
            // 
            // UiButtonExit
            // 
            this.UiButtonExit.Location = new System.Drawing.Point(5, 2);
            this.UiButtonExit.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.UiButtonExit.Size = new System.Drawing.Size(120, 39);
            this.UiButtonExit.Click += new System.EventHandler(this.UiButtonExit_Click);
            // 
            // UiGroupBoxMainData
            // 
            this.UiGroupBoxMainData.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.UiGroupBoxMainData.Size = new System.Drawing.Size(1077, 306);
            // 
            // UiGroupBoxBottom
            // 
            this.UiGroupBoxBottom.Location = new System.Drawing.Point(0, 305);
            this.UiGroupBoxBottom.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.UiGroupBoxBottom.Size = new System.Drawing.Size(1078, 57);
            // 
            // GridEXScheduleList
            // 
            this.GridEXScheduleList.AllowCardSizing = false;
            this.GridEXScheduleList.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.GridEXScheduleList.BlendColor = System.Drawing.Color.Transparent;
            this.GridEXScheduleList.BuiltInTextsData = resources.GetString("GridEXScheduleList.BuiltInTextsData");
            this.GridEXScheduleList.Cursor = System.Windows.Forms.Cursors.Default;
            this.GridEXScheduleList.DefaultFilterRowComparison = Janus.Windows.GridEX.FilterConditionOperator.Contains;
            this.GridEXScheduleList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridEXScheduleList.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.GridEXScheduleList.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.GridEXScheduleList.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.GridEXScheduleList.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.GridEXScheduleList.GroupByBoxVisible = false;
            this.GridEXScheduleList.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.GridEXScheduleList.KeepRowSettings = true;
            this.GridEXScheduleList.Location = new System.Drawing.Point(0, 0);
            this.GridEXScheduleList.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.GridEXScheduleList.Name = "GridEXScheduleList";
            this.GridEXScheduleList.RecordNavigator = true;
            this.GridEXScheduleList.SelectionMode = Janus.Windows.GridEX.SelectionMode.MultipleSelection;
            this.GridEXScheduleList.Size = new System.Drawing.Size(1078, 305);
            this.GridEXScheduleList.TabIndex = 1;
            this.GridEXScheduleList.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.GridEXScheduleList.DoubleClick += new System.EventHandler(this.UiButtonEdit_Click);
            // 
            // FrmScheduleList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1078, 362);
            this.Controls.Add(this.GridEXScheduleList);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "FrmScheduleList";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "لیست زمانبندی";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmScheduleList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmScheduleList_KeyDown);
            this.Controls.SetChildIndex(this.UiGroupBoxBottom, 0);
            this.Controls.SetChildIndex(this.UiGroupBoxMainData, 0);
            this.Controls.SetChildIndex(this.GridEXScheduleList, 0);
            ((System.ComponentModel.ISupportInitialize)(this.UiGroupBoxMainData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiGroupBoxBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridEXScheduleList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Janus.Windows.GridEX.GridEX GridEXScheduleList;
    }
}