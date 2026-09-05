
namespace GeneralKiosk
{
    partial class FormPayWithCard
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
            this.components = new System.ComponentModel.Container();
            this.timerPayTime = new System.Windows.Forms.Timer(this.components);
            this.TableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBoxDown = new System.Windows.Forms.PictureBox();
            this.PayInfo = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelPayPic = new System.Windows.Forms.Panel();
            this.pictureBoxPayPic = new System.Windows.Forms.PictureBox();
            this.textBoxPayTime = new System.Windows.Forms.Label();
            this.pictureBoxCancelFactor = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBoxTopRight = new System.Windows.Forms.PictureBox();
            this.pictureBoxTopCenter = new System.Windows.Forms.PictureBox();
            this.pictureBoxTopLeft = new System.Windows.Forms.PictureBox();
            this.TableLayoutPanelMain.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDown)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelPayPic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPayPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCancelFactor)).BeginInit();
            this.panel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTopRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTopCenter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTopLeft)).BeginInit();
            this.SuspendLayout();
            // 
            // timerPayTime
            // 
            this.timerPayTime.Enabled = true;
            this.timerPayTime.Interval = 1000;
            this.timerPayTime.Tick += new System.EventHandler(this.timerPayTime_Tick);
            // 
            // TableLayoutPanelMain
            // 
            this.TableLayoutPanelMain.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.TableLayoutPanelMain.BackgroundImage = global::GeneralKiosk.Properties.Resources.Group_1;
            this.TableLayoutPanelMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TableLayoutPanelMain.ColumnCount = 3;
            this.TableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanelMain.Controls.Add(this.panel1, 1, 3);
            this.TableLayoutPanelMain.Controls.Add(this.tableLayoutPanel1, 1, 2);
            this.TableLayoutPanelMain.Controls.Add(this.panel2, 1, 1);
            this.TableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TableLayoutPanelMain.Name = "TableLayoutPanelMain";
            this.TableLayoutPanelMain.RowCount = 4;
            this.TableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.509142F));
            this.TableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.TableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.52003F));
            this.TableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.97083F));
            this.TableLayoutPanelMain.Size = new System.Drawing.Size(984, 661);
            this.TableLayoutPanelMain.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.pictureBoxDown);
            this.panel1.Controls.Add(this.PayInfo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(23, 483);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(938, 175);
            this.panel1.TabIndex = 52;
            // 
            // pictureBoxDown
            // 
            this.pictureBoxDown.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBoxDown.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxDown.Image = global::GeneralKiosk.Properties.Resources.logo_mohebe_mehr;
            this.pictureBoxDown.Location = new System.Drawing.Point(428, 104);
            this.pictureBoxDown.Name = "pictureBoxDown";
            this.pictureBoxDown.Size = new System.Drawing.Size(107, 62);
            this.pictureBoxDown.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxDown.TabIndex = 47;
            this.pictureBoxDown.TabStop = false;
            // 
            // PayInfo
            // 
            this.PayInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.PayInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.PayInfo.Font = new System.Drawing.Font("B Yekan", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.PayInfo.ForeColor = System.Drawing.Color.Black;
            this.PayInfo.Location = new System.Drawing.Point(0, 0);
            this.PayInfo.Name = "PayInfo";
            this.PayInfo.Size = new System.Drawing.Size(938, 101);
            this.PayInfo.TabIndex = 46;
            this.PayInfo.Text = "لطفا کارت خود را بکشید.";
            this.PayInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.Controls.Add(this.panelPayPic, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxPayTime, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBoxCancelFactor, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(23, 91);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.83691F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.16309F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(938, 386);
            this.tableLayoutPanel1.TabIndex = 53;
            // 
            // panelPayPic
            // 
            this.panelPayPic.BackColor = System.Drawing.Color.Transparent;
            this.panelPayPic.Controls.Add(this.pictureBoxPayPic);
            this.panelPayPic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPayPic.Location = new System.Drawing.Point(63, 3);
            this.panelPayPic.Name = "panelPayPic";
            this.panelPayPic.Size = new System.Drawing.Size(812, 325);
            this.panelPayPic.TabIndex = 44;
            // 
            // pictureBoxPayPic
            // 
            this.pictureBoxPayPic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxPayPic.Image = global::GeneralKiosk.Properties.Resources._7611a78982cbed109cd23e3419b630da;
            this.pictureBoxPayPic.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxPayPic.Name = "pictureBoxPayPic";
            this.pictureBoxPayPic.Size = new System.Drawing.Size(812, 325);
            this.pictureBoxPayPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPayPic.TabIndex = 0;
            this.pictureBoxPayPic.TabStop = false;
            // 
            // textBoxPayTime
            // 
            this.textBoxPayTime.BackColor = System.Drawing.Color.Transparent;
            this.textBoxPayTime.Font = new System.Drawing.Font("B Yekan", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.textBoxPayTime.ForeColor = System.Drawing.Color.Red;
            this.textBoxPayTime.Location = new System.Drawing.Point(881, 0);
            this.textBoxPayTime.Name = "textBoxPayTime";
            this.textBoxPayTime.Size = new System.Drawing.Size(54, 54);
            this.textBoxPayTime.TabIndex = 45;
            this.textBoxPayTime.Text = "50";
            this.textBoxPayTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxCancelFactor
            // 
            this.pictureBoxCancelFactor.Image = global::GeneralKiosk.Properties.Resources.icons8_cancel_480;
            this.pictureBoxCancelFactor.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxCancelFactor.Name = "pictureBoxCancelFactor";
            this.pictureBoxCancelFactor.Size = new System.Drawing.Size(54, 54);
            this.pictureBoxCancelFactor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxCancelFactor.TabIndex = 50;
            this.pictureBoxCancelFactor.TabStop = false;
            this.pictureBoxCancelFactor.Visible = false;
            this.pictureBoxCancelFactor.Click += new System.EventHandler(this.pictureBoxCancelFactor_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(23, 11);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(938, 74);
            this.panel2.TabIndex = 54;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.pictureBoxTopRight);
            this.flowLayoutPanel1.Controls.Add(this.pictureBoxTopCenter);
            this.flowLayoutPanel1.Controls.Add(this.pictureBoxTopLeft);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(938, 74);
            this.flowLayoutPanel1.TabIndex = 50;
            // 
            // pictureBoxTopRight
            // 
            this.pictureBoxTopRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxTopRight.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxTopRight.Image = global::GeneralKiosk.Properties.Resources.logo_mohebe_mehr;
            this.pictureBoxTopRight.Location = new System.Drawing.Point(810, 3);
            this.pictureBoxTopRight.Margin = new System.Windows.Forms.Padding(3, 3, 218, 3);
            this.pictureBoxTopRight.Name = "pictureBoxTopRight";
            this.pictureBoxTopRight.Size = new System.Drawing.Size(125, 65);
            this.pictureBoxTopRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxTopRight.TabIndex = 2;
            this.pictureBoxTopRight.TabStop = false;
            // 
            // pictureBoxTopCenter
            // 
            this.pictureBoxTopCenter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.pictureBoxTopCenter.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxTopCenter.Image = global::GeneralKiosk.Properties.Resources.RASISPNG;
            this.pictureBoxTopCenter.Location = new System.Drawing.Point(395, 3);
            this.pictureBoxTopCenter.Margin = new System.Windows.Forms.Padding(3, 3, 218, 3);
            this.pictureBoxTopCenter.Name = "pictureBoxTopCenter";
            this.pictureBoxTopCenter.Size = new System.Drawing.Size(194, 65);
            this.pictureBoxTopCenter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxTopCenter.TabIndex = 1;
            this.pictureBoxTopCenter.TabStop = false;
            // 
            // pictureBoxTopLeft
            // 
            this.pictureBoxTopLeft.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxTopLeft.Image = global::GeneralKiosk.Properties.Resources.L_O_G_O_new_color_01_removebg_preview;
            this.pictureBoxTopLeft.Location = new System.Drawing.Point(28, 3);
            this.pictureBoxTopLeft.Name = "pictureBoxTopLeft";
            this.pictureBoxTopLeft.Size = new System.Drawing.Size(146, 65);
            this.pictureBoxTopLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxTopLeft.TabIndex = 2;
            this.pictureBoxTopLeft.TabStop = false;
            // 
            // FormPayWithCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.ControlBox = false;
            this.Controls.Add(this.TableLayoutPanelMain);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormPayWithCard";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "راهکار های نرم افزاری رسیس - کیوسک";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPayWithCard_FormClosing);
            this.Load += new System.EventHandler(this.Form23_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMainUI_KeyDown);
            this.TableLayoutPanelMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDown)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelPayPic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPayPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCancelFactor)).EndInit();
            this.panel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTopRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTopCenter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTopLeft)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel TableLayoutPanelMain;
        private System.Windows.Forms.Panel panelPayPic;
        private System.Windows.Forms.PictureBox pictureBoxPayPic;
        private System.Windows.Forms.Label textBoxPayTime;
        private System.Windows.Forms.Label PayInfo;
        private System.Windows.Forms.PictureBox pictureBoxCancelFactor;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBoxDown;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBoxTopRight;
        private System.Windows.Forms.PictureBox pictureBoxTopCenter;
        private System.Windows.Forms.PictureBox pictureBoxTopLeft;
        private System.Windows.Forms.Timer timerPayTime;
    }
}