
namespace GeneralKiosk
{
    partial class FormFactorList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFactorList));
            Janus.Windows.GridEX.GridEXLayout gridEXFactors_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.Common.Layouts.JanusLayoutReference gridEXFactors_DesignTimeLayout_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column0.Image");
            Janus.Windows.Common.Layouts.JanusLayoutReference gridEXFactors_DesignTimeLayout_Reference_1 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column1.Image");
            Janus.Windows.Common.Layouts.JanusLayoutReference gridEXFactors_DesignTimeLayout_Reference_2 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column2.Image");
            this.TableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelRasisInfo = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.GridEXTPYNT = new Janus.Windows.GridEX.GridEX();
            this.gridEXFactors = new Janus.Windows.GridEX.GridEX();
            this.panelFilters = new System.Windows.Forms.Panel();
            this.uiRadioButtonAll = new Janus.Windows.EditControls.UIRadioButton();
            this.uiRadioButtonFail = new Janus.Windows.EditControls.UIRadioButton();
            this.uiRadioButtonSuccess = new Janus.Windows.EditControls.UIRadioButton();
            this.uiButtonLoadFactors = new Janus.Windows.EditControls.UIButton();
            this.userDateTarikhTa = new GeneralKiosk.UserDate();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.userDateTarikhAz = new GeneralKiosk.UserDate();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxName = new System.Windows.Forms.Label();
            this.pictureBoxCancelFactor = new System.Windows.Forms.PictureBox();
            this.TableLayoutPanelMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridEXTPYNT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEXFactors)).BeginInit();
            this.panelFilters.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCancelFactor)).BeginInit();
            this.SuspendLayout();
            // 
            // TableLayoutPanelMain
            // 
            this.TableLayoutPanelMain.BackColor = System.Drawing.SystemColors.Control;
            this.TableLayoutPanelMain.ColumnCount = 3;
            this.TableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.TableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.TableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanelMain.Controls.Add(this.panelRasisInfo, 1, 4);
            this.TableLayoutPanelMain.Controls.Add(this.panel1, 1, 3);
            this.TableLayoutPanelMain.Controls.Add(this.panelFilters, 1, 2);
            this.TableLayoutPanelMain.Controls.Add(this.tableLayoutPanel1, 1, 1);
            this.TableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.TableLayoutPanelMain.Name = "TableLayoutPanelMain";
            this.TableLayoutPanelMain.RowCount = 5;
            this.TableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.TableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.TableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.TableLayoutPanelMain.Size = new System.Drawing.Size(1125, 826);
            this.TableLayoutPanelMain.TabIndex = 0;
            // 
            // panelRasisInfo
            // 
            this.panelRasisInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRasisInfo.Location = new System.Drawing.Point(26, 780);
            this.panelRasisInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelRasisInfo.Name = "panelRasisInfo";
            this.panelRasisInfo.Size = new System.Drawing.Size(1073, 42);
            this.panelRasisInfo.TabIndex = 39;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelMain);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(26, 149);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1073, 623);
            this.panel1.TabIndex = 47;
            // 
            // panelMain
            // 
            this.panelMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelMain.Controls.Add(this.GridEXTPYNT);
            this.panelMain.Controls.Add(this.gridEXFactors);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1073, 623);
            this.panelMain.TabIndex = 77;
            // 
            // GridEXTPYNT
            // 
            this.GridEXTPYNT.AllowCardSizing = false;
            this.GridEXTPYNT.AllowColumnDrag = false;
            this.GridEXTPYNT.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.GridEXTPYNT.AlternatingColors = true;
            this.GridEXTPYNT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridEXTPYNT.BuiltInTextsData = resources.GetString("GridEXTPYNT.BuiltInTextsData");
            this.GridEXTPYNT.DefaultFilterRowComparison = Janus.Windows.GridEX.FilterConditionOperator.Contains;
            this.GridEXTPYNT.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.GridEXTPYNT.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.GridEXTPYNT.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.GridEXTPYNT.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.GridEXTPYNT.GroupByBoxVisible = false;
            this.GridEXTPYNT.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.GridEXTPYNT.Location = new System.Drawing.Point(0, 413);
            this.GridEXTPYNT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GridEXTPYNT.Name = "GridEXTPYNT";
            this.GridEXTPYNT.RecordNavigator = true;
            this.GridEXTPYNT.ScrollBarWidth = 30;
            this.GridEXTPYNT.SelectionMode = Janus.Windows.GridEX.SelectionMode.MultipleSelection;
            this.GridEXTPYNT.Size = new System.Drawing.Size(1070, 206);
            this.GridEXTPYNT.TabIndex = 77;
            this.GridEXTPYNT.VisualStyle = Janus.Windows.GridEX.VisualStyle.VS2010;
            // 
            // gridEXFactors
            // 
            this.gridEXFactors.AllowCardSizing = false;
            this.gridEXFactors.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gridEXFactors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridEXFactors.BuiltInTextsData = resources.GetString("gridEXFactors.BuiltInTextsData");
            this.gridEXFactors.DefaultFilterRowComparison = Janus.Windows.GridEX.FilterConditionOperator.Contains;
            gridEXFactors_DesignTimeLayout_Reference_0.Instance = ((object)(resources.GetObject("gridEXFactors_DesignTimeLayout_Reference_0.Instance")));
            gridEXFactors_DesignTimeLayout_Reference_1.Instance = ((object)(resources.GetObject("gridEXFactors_DesignTimeLayout_Reference_1.Instance")));
            gridEXFactors_DesignTimeLayout_Reference_2.Instance = ((object)(resources.GetObject("gridEXFactors_DesignTimeLayout_Reference_2.Instance")));
            gridEXFactors_DesignTimeLayout.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            gridEXFactors_DesignTimeLayout_Reference_0,
            gridEXFactors_DesignTimeLayout_Reference_1,
            gridEXFactors_DesignTimeLayout_Reference_2});
            gridEXFactors_DesignTimeLayout.LayoutString = resources.GetString("gridEXFactors_DesignTimeLayout.LayoutString");
            this.gridEXFactors.DesignTimeLayout = gridEXFactors_DesignTimeLayout;
            this.gridEXFactors.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.gridEXFactors.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.gridEXFactors.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.gridEXFactors.FocusCellFormatStyle.Appearance = Janus.Windows.GridEX.Appearance.RaisedLight;
            this.gridEXFactors.FocusCellFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gridEXFactors.Font = new System.Drawing.Font("B Yekan", 9.75F);
            this.gridEXFactors.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gridEXFactors.GroupByBoxVisible = false;
            this.gridEXFactors.KeepRowSettings = true;
            this.gridEXFactors.Location = new System.Drawing.Point(0, 0);
            this.gridEXFactors.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridEXFactors.Name = "gridEXFactors";
            this.gridEXFactors.ScrollBarWidth = 50;
            this.gridEXFactors.SelectedFormatStyle.Appearance = Janus.Windows.GridEX.Appearance.RaisedLight;
            this.gridEXFactors.SelectedFormatStyle.BackColor = System.Drawing.Color.Empty;
            this.gridEXFactors.SelectedFormatStyle.BackColorGradient = System.Drawing.Color.Empty;
            this.gridEXFactors.SelectedFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gridEXFactors.Size = new System.Drawing.Size(1073, 405);
            this.gridEXFactors.TabIndex = 76;
            this.gridEXFactors.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.gridEXFactors.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.gridEXFactors_FormattingRow);
            this.gridEXFactors.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.gridEXFactors_ColumnButtonClick);
            this.gridEXFactors.SelectionChanged += new System.EventHandler(this.gridEXFactors_SelectionChanged);
            // 
            // panelFilters
            // 
            this.panelFilters.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panelFilters.Controls.Add(this.uiRadioButtonAll);
            this.panelFilters.Controls.Add(this.uiRadioButtonFail);
            this.panelFilters.Controls.Add(this.uiRadioButtonSuccess);
            this.panelFilters.Controls.Add(this.uiButtonLoadFactors);
            this.panelFilters.Controls.Add(this.userDateTarikhTa);
            this.panelFilters.Controls.Add(this.label2);
            this.panelFilters.Controls.Add(this.label1);
            this.panelFilters.Controls.Add(this.userDateTarikhAz);
            this.panelFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFilters.Location = new System.Drawing.Point(26, 98);
            this.panelFilters.Name = "panelFilters";
            this.panelFilters.Size = new System.Drawing.Size(1073, 44);
            this.panelFilters.TabIndex = 48;
            // 
            // uiRadioButtonAll
            // 
            this.uiRadioButtonAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiRadioButtonAll.ImageAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Center;
            this.uiRadioButtonAll.Location = new System.Drawing.Point(376, 10);
            this.uiRadioButtonAll.Name = "uiRadioButtonAll";
            this.uiRadioButtonAll.Size = new System.Drawing.Size(60, 23);
            this.uiRadioButtonAll.TabIndex = 8;
            this.uiRadioButtonAll.Text = "همه";
            this.uiRadioButtonAll.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center;
            // 
            // uiRadioButtonFail
            // 
            this.uiRadioButtonFail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiRadioButtonFail.ImageAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Center;
            this.uiRadioButtonFail.Location = new System.Drawing.Point(442, 10);
            this.uiRadioButtonFail.Name = "uiRadioButtonFail";
            this.uiRadioButtonFail.Size = new System.Drawing.Size(110, 23);
            this.uiRadioButtonFail.TabIndex = 7;
            this.uiRadioButtonFail.Text = "پرداخت ناموفق";
            this.uiRadioButtonFail.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center;
            // 
            // uiRadioButtonSuccess
            // 
            this.uiRadioButtonSuccess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiRadioButtonSuccess.Checked = true;
            this.uiRadioButtonSuccess.ImageAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Center;
            this.uiRadioButtonSuccess.Location = new System.Drawing.Point(558, 10);
            this.uiRadioButtonSuccess.Name = "uiRadioButtonSuccess";
            this.uiRadioButtonSuccess.Size = new System.Drawing.Size(104, 23);
            this.uiRadioButtonSuccess.TabIndex = 6;
            this.uiRadioButtonSuccess.TabStop = true;
            this.uiRadioButtonSuccess.Text = "پرداخت موفق";
            this.uiRadioButtonSuccess.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center;
            // 
            // uiButtonLoadFactors
            // 
            this.uiButtonLoadFactors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiButtonLoadFactors.Image = global::GeneralKiosk.Properties.Resources.refresh_square_icon_2048x2048_8977l1ow;
            this.uiButtonLoadFactors.ImageSize = new System.Drawing.Size(48, 48);
            this.uiButtonLoadFactors.Location = new System.Drawing.Point(322, 1);
            this.uiButtonLoadFactors.Name = "uiButtonLoadFactors";
            this.uiButtonLoadFactors.Size = new System.Drawing.Size(49, 40);
            this.uiButtonLoadFactors.TabIndex = 5;
            this.uiButtonLoadFactors.Click += new System.EventHandler(this.uiButtonLoadFactors_Click);
            // 
            // userDateTarikhTa
            // 
            this.userDateTarikhTa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.userDateTarikhTa.Location = new System.Drawing.Point(686, 10);
            this.userDateTarikhTa.MaximumSize = new System.Drawing.Size(250, 23);
            this.userDateTarikhTa.MinimumSize = new System.Drawing.Size(100, 23);
            this.userDateTarikhTa.Name = "userDateTarikhTa";
            this.userDateTarikhTa.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.userDateTarikhTa.SelectedDateTime = null;
            this.userDateTarikhTa.Size = new System.Drawing.Size(132, 23);
            this.userDateTarikhTa.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(824, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "تاریخ تا :";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1016, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "تاریخ از :";
            // 
            // userDateTarikhAz
            // 
            this.userDateTarikhAz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.userDateTarikhAz.Location = new System.Drawing.Point(878, 10);
            this.userDateTarikhAz.MaximumSize = new System.Drawing.Size(250, 23);
            this.userDateTarikhAz.MinimumSize = new System.Drawing.Size(100, 23);
            this.userDateTarikhAz.Name = "userDateTarikhAz";
            this.userDateTarikhAz.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.userDateTarikhAz.SelectedDateTime = null;
            this.userDateTarikhAz.Size = new System.Drawing.Size(132, 23);
            this.userDateTarikhAz.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Controls.Add(this.textBoxName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBoxCancelFactor, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(26, 23);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1073, 69);
            this.tableLayoutPanel1.TabIndex = 49;
            // 
            // textBoxName
            // 
            this.textBoxName.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBoxName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxName.Font = new System.Drawing.Font("B Yekan", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.textBoxName.Location = new System.Drawing.Point(53, 4);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(1017, 61);
            this.textBoxName.TabIndex = 41;
            this.textBoxName.Text = "شرکت ارتباطات پیوسته ایرانیان";
            this.textBoxName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxCancelFactor
            // 
            this.pictureBoxCancelFactor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxCancelFactor.Image = global::GeneralKiosk.Properties.Resources.icons8_cancel_480;
            this.pictureBoxCancelFactor.Location = new System.Drawing.Point(3, 4);
            this.pictureBoxCancelFactor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBoxCancelFactor.Name = "pictureBoxCancelFactor";
            this.pictureBoxCancelFactor.Size = new System.Drawing.Size(44, 61);
            this.pictureBoxCancelFactor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxCancelFactor.TabIndex = 46;
            this.pictureBoxCancelFactor.TabStop = false;
            this.pictureBoxCancelFactor.Click += new System.EventHandler(this.pictureBoxCancelFactor_Click);
            // 
            // FormFactorList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 826);
            this.ControlBox = false;
            this.Controls.Add(this.TableLayoutPanelMain);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "FormFactorList";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "راهکار های نرم افزاری رسیس - کیوسک";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormFactorList_FormClosing);
            this.Load += new System.EventHandler(this.Form23_Load);
            this.TableLayoutPanelMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridEXTPYNT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEXFactors)).EndInit();
            this.panelFilters.ResumeLayout(false);
            this.panelFilters.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCancelFactor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel TableLayoutPanelMain;
        private System.Windows.Forms.Panel panelRasisInfo;
        private System.Windows.Forms.Label textBoxName;
        private System.Windows.Forms.PictureBox pictureBoxCancelFactor;
        private System.Windows.Forms.Panel panel1;
        private Janus.Windows.GridEX.GridEX gridEXFactors;
        private System.Windows.Forms.Panel panelMain;
        private Janus.Windows.GridEX.GridEX GridEXTPYNT;
        private System.Windows.Forms.Panel panelFilters;
        private UserDate userDateTarikhTa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private UserDate userDateTarikhAz;
        private Janus.Windows.EditControls.UIButton uiButtonLoadFactors;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Janus.Windows.EditControls.UIRadioButton uiRadioButtonAll;
        private Janus.Windows.EditControls.UIRadioButton uiRadioButtonFail;
        private Janus.Windows.EditControls.UIRadioButton uiRadioButtonSuccess;
    }
}