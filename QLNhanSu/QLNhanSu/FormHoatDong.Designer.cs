namespace QLNhanSu
{
    partial class FormHoatDong
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox lstHoatDong;
        private System.Windows.Forms.Button btnHienThiHoatDong;

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
            this.lstHoatDong = new System.Windows.Forms.ListBox();
            this.btnHienThiHoatDong = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstHoatDong
            // 
            this.lstHoatDong.FormattingEnabled = true;
            this.lstHoatDong.ItemHeight = 16;
            this.lstHoatDong.Location = new System.Drawing.Point(20, 20);
            this.lstHoatDong.Name = "lstHoatDong";
            this.lstHoatDong.Size = new System.Drawing.Size(705, 292);
            this.lstHoatDong.TabIndex = 0;
            // 
            // btnHienThiHoatDong
            // 
            this.btnHienThiHoatDong.Location = new System.Drawing.Point(108, 338);
            this.btnHienThiHoatDong.Name = "btnHienThiHoatDong";
            this.btnHienThiHoatDong.Size = new System.Drawing.Size(576, 30);
            this.btnHienThiHoatDong.TabIndex = 1;
            this.btnHienThiHoatDong.Text = "Hiển thị các hoạt động";
            this.btnHienThiHoatDong.UseVisualStyleBackColor = true;
            this.btnHienThiHoatDong.Click += new System.EventHandler(this.btnHienThiHoatDong_Click);
            // 
            // FormHoatDong
            // 
            this.ClientSize = new System.Drawing.Size(766, 400);
            this.Controls.Add(this.lstHoatDong);
            this.Controls.Add(this.btnHienThiHoatDong);
            this.Name = "FormHoatDong";
            this.Text = "Theo dõi Hoạt Động";
            this.ResumeLayout(false);

        }
    }
}
