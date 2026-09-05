
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GeneralKiosk.Common
{


    public partial class NumericKeyboardForm : Form
    {
        private System.ComponentModel.IContainer components = null;
        private Button btn0;
        private Button btn1;
        private Button btn2;
        private Button btn3;
        private Button btn4;
        private Button btn5;
        private Button btn6;
        private Button btn7;
        private Button btn8;
        private Button btn9;
        private Button btnClear;
        private Button btnBackspace;

        public NumericKeyboardForm()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btn0 = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btn6 = new System.Windows.Forms.Button();
            this.btn7 = new System.Windows.Forms.Button();
            this.btn8 = new System.Windows.Forms.Button();
            this.btn9 = new System.Windows.Forms.Button();
            this.btnBackspace = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.buttonCloseNumForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn0
            // 
            this.btn0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(69)))), ((int)(((byte)(229)))));
            this.btn0.Font = new System.Drawing.Font("B Nazanin", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn0.ForeColor = System.Drawing.Color.White;
            this.btn0.Location = new System.Drawing.Point(97, 270);
            this.btn0.Name = "btn0";
            this.btn0.Size = new System.Drawing.Size(90, 70);
            this.btn0.TabIndex = 0;
            this.btn0.Text = "0";
            this.btn0.UseVisualStyleBackColor = false;
            this.btn0.Click += new System.EventHandler(this.NumericButton_Click);
            // 
            // btn1
            // 
            this.btn1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(69)))), ((int)(((byte)(229)))));
            this.btn1.Font = new System.Drawing.Font("B Nazanin", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn1.ForeColor = System.Drawing.Color.White;
            this.btn1.Location = new System.Drawing.Point(1, 34);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(90, 70);
            this.btn1.TabIndex = 1;
            this.btn1.Text = "1";
            this.btn1.UseVisualStyleBackColor = false;
            this.btn1.Click += new System.EventHandler(this.NumericButton_Click);
            // 
            // btn2
            // 
            this.btn2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(69)))), ((int)(((byte)(229)))));
            this.btn2.Font = new System.Drawing.Font("B Sara", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn2.ForeColor = System.Drawing.Color.White;
            this.btn2.Location = new System.Drawing.Point(97, 34);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(90, 70);
            this.btn2.TabIndex = 2;
            this.btn2.Text = "2";
            this.btn2.UseVisualStyleBackColor = false;
            this.btn2.Click += new System.EventHandler(this.NumericButton_Click);
            // 
            // btn3
            // 
            this.btn3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(69)))), ((int)(((byte)(229)))));
            this.btn3.Font = new System.Drawing.Font("B Nazanin", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn3.ForeColor = System.Drawing.Color.White;
            this.btn3.Location = new System.Drawing.Point(193, 34);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(90, 70);
            this.btn3.TabIndex = 3;
            this.btn3.Text = "3";
            this.btn3.UseVisualStyleBackColor = false;
            this.btn3.Click += new System.EventHandler(this.NumericButton_Click);
            // 
            // btn4
            // 
            this.btn4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(69)))), ((int)(((byte)(229)))));
            this.btn4.Font = new System.Drawing.Font("B Nazanin", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn4.ForeColor = System.Drawing.Color.White;
            this.btn4.Location = new System.Drawing.Point(1, 114);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(90, 70);
            this.btn4.TabIndex = 4;
            this.btn4.Text = "4";
            this.btn4.UseVisualStyleBackColor = false;
            this.btn4.Click += new System.EventHandler(this.NumericButton_Click);
            // 
            // btn5
            // 
            this.btn5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(69)))), ((int)(((byte)(229)))));
            this.btn5.Font = new System.Drawing.Font("B Nazanin", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn5.ForeColor = System.Drawing.Color.White;
            this.btn5.Location = new System.Drawing.Point(97, 114);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(90, 70);
            this.btn5.TabIndex = 5;
            this.btn5.Text = "5";
            this.btn5.UseVisualStyleBackColor = false;
            this.btn5.Click += new System.EventHandler(this.NumericButton_Click);
            // 
            // btn6
            // 
            this.btn6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(69)))), ((int)(((byte)(229)))));
            this.btn6.Font = new System.Drawing.Font("B Nazanin", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn6.ForeColor = System.Drawing.Color.White;
            this.btn6.Location = new System.Drawing.Point(193, 114);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(90, 70);
            this.btn6.TabIndex = 6;
            this.btn6.Text = "6";
            this.btn6.UseVisualStyleBackColor = false;
            this.btn6.Click += new System.EventHandler(this.NumericButton_Click);
            // 
            // btn7
            // 
            this.btn7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(69)))), ((int)(((byte)(229)))));
            this.btn7.Font = new System.Drawing.Font("B Nazanin", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn7.ForeColor = System.Drawing.Color.White;
            this.btn7.Location = new System.Drawing.Point(1, 194);
            this.btn7.Name = "btn7";
            this.btn7.Size = new System.Drawing.Size(90, 70);
            this.btn7.TabIndex = 7;
            this.btn7.Text = "7";
            this.btn7.UseVisualStyleBackColor = false;
            this.btn7.Click += new System.EventHandler(this.NumericButton_Click);
            // 
            // btn8
            // 
            this.btn8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(69)))), ((int)(((byte)(229)))));
            this.btn8.Font = new System.Drawing.Font("B Nazanin", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn8.ForeColor = System.Drawing.Color.White;
            this.btn8.Location = new System.Drawing.Point(97, 194);
            this.btn8.Name = "btn8";
            this.btn8.Size = new System.Drawing.Size(90, 70);
            this.btn8.TabIndex = 8;
            this.btn8.Text = "8";
            this.btn8.UseVisualStyleBackColor = false;
            this.btn8.Click += new System.EventHandler(this.NumericButton_Click);
            // 
            // btn9
            // 
            this.btn9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(69)))), ((int)(((byte)(229)))));
            this.btn9.Font = new System.Drawing.Font("B Nazanin", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn9.ForeColor = System.Drawing.Color.White;
            this.btn9.Location = new System.Drawing.Point(193, 194);
            this.btn9.Name = "btn9";
            this.btn9.Size = new System.Drawing.Size(90, 70);
            this.btn9.TabIndex = 9;
            this.btn9.Text = "9";
            this.btn9.UseVisualStyleBackColor = false;
            this.btn9.Click += new System.EventHandler(this.NumericButton_Click);
            // 
            // btnBackspace
            // 
            this.btnBackspace.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnBackspace.Font = new System.Drawing.Font("B Nazanin", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnBackspace.ForeColor = System.Drawing.Color.Black;
            this.btnBackspace.Location = new System.Drawing.Point(193, 270);
            this.btnBackspace.Name = "btnBackspace";
            this.btnBackspace.Size = new System.Drawing.Size(90, 70);
            this.btnBackspace.TabIndex = 11;
            this.btnBackspace.Text = "تصحیح";
            this.btnBackspace.UseVisualStyleBackColor = false;
            this.btnBackspace.Click += new System.EventHandler(this.btnBackspace_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnClear.Font = new System.Drawing.Font("B Nazanin", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.Location = new System.Drawing.Point(1, 269);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(90, 70);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "پاک کردن";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // buttonCloseNumForm
            // 
            this.buttonCloseNumForm.BackColor = System.Drawing.Color.Brown;
            this.buttonCloseNumForm.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.buttonCloseNumForm.ForeColor = System.Drawing.Color.White;
            this.buttonCloseNumForm.Location = new System.Drawing.Point(193, 1);
            this.buttonCloseNumForm.Name = "buttonCloseNumForm";
            this.buttonCloseNumForm.Size = new System.Drawing.Size(90, 33);
            this.buttonCloseNumForm.TabIndex = 12;
            this.buttonCloseNumForm.Text = "x";
            this.buttonCloseNumForm.UseVisualStyleBackColor = false;
            this.buttonCloseNumForm.Click += new System.EventHandler(this.button1_Click);
            // 
            // NumericKeyboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(286, 343);
            this.ControlBox = false;
            this.Controls.Add(this.btnBackspace);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btn9);
            this.Controls.Add(this.btn8);
            this.Controls.Add(this.btn7);
            this.Controls.Add(this.btn6);
            this.Controls.Add(this.btn5);
            this.Controls.Add(this.btn4);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.btn0);
            this.Controls.Add(this.buttonCloseNumForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NumericKeyboardForm";
            this.Load += new System.EventHandler(this.NumericKeyboardForm_Load);
            this.ResumeLayout(false);

        }

        private Button buttonCloseNumForm;
    }



}