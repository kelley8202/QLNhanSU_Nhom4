namespace QLNhanSu
{
    partial class FormGiaHan
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

        private void InitializeComponent()
        {
            this.rb1Month = new System.Windows.Forms.RadioButton();
            this.rb3Months = new System.Windows.Forms.RadioButton();
            this.rb6Months = new System.Windows.Forms.RadioButton();
            this.rb1Year = new System.Windows.Forms.RadioButton();
            this.rb3Years = new System.Windows.Forms.RadioButton();
            this.rb10Years = new System.Windows.Forms.RadioButton();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rb1Month
            // 
            this.rb1Month.AutoSize = true;
            this.rb1Month.Location = new System.Drawing.Point(50, 60);
            this.rb1Month.Name = "rb1Month";
            this.rb1Month.Size = new System.Drawing.Size(69, 21);
            this.rb1Month.TabIndex = 0;
            this.rb1Month.TabStop = true;
            this.rb1Month.Text = "1 Tháng";
            this.rb1Month.UseVisualStyleBackColor = true;
            // 
            // rb3Months
            // 
            this.rb3Months.AutoSize = true;
            this.rb3Months.Location = new System.Drawing.Point(50, 90);
            this.rb3Months.Name = "rb3Months";
            this.rb3Months.Size = new System.Drawing.Size(79, 21);
            this.rb3Months.TabIndex = 1;
            this.rb3Months.TabStop = true;
            this.rb3Months.Text = "3 Tháng";
            this.rb3Months.UseVisualStyleBackColor = true;
            // 
            // rb6Months
            // 
            this.rb6Months.AutoSize = true;
            this.rb6Months.Location = new System.Drawing.Point(50, 120);
            this.rb6Months.Name = "rb6Months";
            this.rb6Months.Size = new System.Drawing.Size(79, 21);
            this.rb6Months.TabIndex = 2;
            this.rb6Months.TabStop = true;
            this.rb6Months.Text = "6 Tháng";
            this.rb6Months.UseVisualStyleBackColor = true;
            // 
            // rb1Year
            // 
            this.rb1Year.AutoSize = true;
            this.rb1Year.Location = new System.Drawing.Point(50, 150);
            this.rb1Year.Name = "rb1Year";
            this.rb1Year.Size = new System.Drawing.Size(65, 21);
            this.rb1Year.TabIndex = 3;
            this.rb1Year.TabStop = true;
            this.rb1Year.Text = "1 Năm";
            this.rb1Year.UseVisualStyleBackColor = true;
            // 
            // rb3Years
            // 
            this.rb3Years.AutoSize = true;
            this.rb3Years.Location = new System.Drawing.Point(50, 180);
            this.rb3Years.Name = "rb3Years";
            this.rb3Years.Size = new System.Drawing.Size(79, 21);
            this.rb3Years.TabIndex = 4;
            this.rb3Years.TabStop = true;
            this.rb3Years.Text = "3 Năm";
            this.rb3Years.UseVisualStyleBackColor = true;
            // 
            // rb10Years
            // 
            this.rb10Years.AutoSize = true;
            this.rb10Years.Location = new System.Drawing.Point(50, 210);
            this.rb10Years.Name = "rb10Years";
            this.rb10Years.Size = new System.Drawing.Size(92, 21);
            this.rb10Years.TabIndex = 5;
            this.rb10Years.TabStop = true;
            this.rb10Years.Text = "10 Năm";
            this.rb10Years.UseVisualStyleBackColor = true;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(50, 240);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(120, 30);
            this.btnConfirm.TabIndex = 6;
            this.btnConfirm.Text = "Xác Nhận";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(46, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(233, 25);
            this.lblTitle.TabIndex = 7;
            this.lblTitle.Text = "Chọn Thời Gian Gia Hạn";
            // 
            // FormGiaHan
            // 
            this.ClientSize = new System.Drawing.Size(330, 300);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.rb10Years);
            this.Controls.Add(this.rb3Years);
            this.Controls.Add(this.rb1Year);
            this.Controls.Add(this.rb6Months);
            this.Controls.Add(this.rb3Months);
            this.Controls.Add(this.rb1Month);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormGiaHan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gia Hạn Hợp Đồng";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.RadioButton rb1Month;
        private System.Windows.Forms.RadioButton rb3Months;
        private System.Windows.Forms.RadioButton rb6Months;
        private System.Windows.Forms.RadioButton rb1Year;
        private System.Windows.Forms.RadioButton rb3Years;
        private System.Windows.Forms.RadioButton rb10Years;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label lblTitle;
    }
}
