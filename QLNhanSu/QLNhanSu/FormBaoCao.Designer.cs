namespace QLNhanSu
{
    partial class FormBaoCao
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTongSoNhanVien;
        private System.Windows.Forms.TextBox txtTongSoNhanVien;
        private System.Windows.Forms.Label lblTongSoHopDong;
        private System.Windows.Forms.TextBox txtTongSoHopDong;
        private System.Windows.Forms.DataGridView dgvThongKePhongBan;
        private System.Windows.Forms.DataGridView dgvThongKeChucVu;
        private System.Windows.Forms.Label lblThongKePhongBan;
        private System.Windows.Forms.Label lblThongKeChucVu;

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
            this.lblTongSoNhanVien = new System.Windows.Forms.Label();
            this.txtTongSoNhanVien = new System.Windows.Forms.TextBox();
            this.lblTongSoHopDong = new System.Windows.Forms.Label();
            this.txtTongSoHopDong = new System.Windows.Forms.TextBox();
            this.dgvThongKePhongBan = new System.Windows.Forms.DataGridView();
            this.dgvThongKeChucVu = new System.Windows.Forms.DataGridView();
            this.lblThongKePhongBan = new System.Windows.Forms.Label();
            this.lblThongKeChucVu = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKePhongBan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKeChucVu)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTongSoNhanVien
            // 
            this.lblTongSoNhanVien.AutoSize = true;
            this.lblTongSoNhanVien.Location = new System.Drawing.Point(30, 30);
            this.lblTongSoNhanVien.Name = "lblTongSoNhanVien";
            this.lblTongSoNhanVien.Size = new System.Drawing.Size(120, 16);
            this.lblTongSoNhanVien.TabIndex = 0;
            this.lblTongSoNhanVien.Text = "Tổng số nhân viên:";
            // 
            // txtTongSoNhanVien
            // 
            this.txtTongSoNhanVien.Enabled = false;
            this.txtTongSoNhanVien.Location = new System.Drawing.Point(150, 27);
            this.txtTongSoNhanVien.Name = "txtTongSoNhanVien";
            this.txtTongSoNhanVien.ReadOnly = true;
            this.txtTongSoNhanVien.Size = new System.Drawing.Size(100, 22);
            this.txtTongSoNhanVien.TabIndex = 1;
            // 
            // lblTongSoHopDong
            // 
            this.lblTongSoHopDong.AutoSize = true;
            this.lblTongSoHopDong.Location = new System.Drawing.Point(30, 70);
            this.lblTongSoHopDong.Name = "lblTongSoHopDong";
            this.lblTongSoHopDong.Size = new System.Drawing.Size(120, 16);
            this.lblTongSoHopDong.TabIndex = 2;
            this.lblTongSoHopDong.Text = "Tổng số hợp đồng:";
            // 
            // txtTongSoHopDong
            // 
            this.txtTongSoHopDong.Enabled = false;
            this.txtTongSoHopDong.Location = new System.Drawing.Point(150, 67);
            this.txtTongSoHopDong.Name = "txtTongSoHopDong";
            this.txtTongSoHopDong.ReadOnly = true;
            this.txtTongSoHopDong.Size = new System.Drawing.Size(100, 22);
            this.txtTongSoHopDong.TabIndex = 3;
            // 
            // dgvThongKePhongBan
            // 
            this.dgvThongKePhongBan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThongKePhongBan.ColumnHeadersHeight = 29;
            this.dgvThongKePhongBan.Location = new System.Drawing.Point(30, 150);
            this.dgvThongKePhongBan.Name = "dgvThongKePhongBan";
            this.dgvThongKePhongBan.RowHeadersWidth = 51;
            this.dgvThongKePhongBan.Size = new System.Drawing.Size(300, 150);
            this.dgvThongKePhongBan.TabIndex = 5;
            // 
            // dgvThongKeChucVu
            // 
            this.dgvThongKeChucVu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThongKeChucVu.ColumnHeadersHeight = 29;
            this.dgvThongKeChucVu.Location = new System.Drawing.Point(360, 150);
            this.dgvThongKeChucVu.Name = "dgvThongKeChucVu";
            this.dgvThongKeChucVu.RowHeadersWidth = 51;
            this.dgvThongKeChucVu.Size = new System.Drawing.Size(300, 150);
            this.dgvThongKeChucVu.TabIndex = 7;
            // 
            // lblThongKePhongBan
            // 
            this.lblThongKePhongBan.AutoSize = true;
            this.lblThongKePhongBan.Location = new System.Drawing.Point(30, 120);
            this.lblThongKePhongBan.Name = "lblThongKePhongBan";
            this.lblThongKePhongBan.Size = new System.Drawing.Size(134, 16);
            this.lblThongKePhongBan.TabIndex = 4;
            this.lblThongKePhongBan.Text = "Thống kê phòng ban:";
            // 
            // lblThongKeChucVu
            // 
            this.lblThongKeChucVu.AutoSize = true;
            this.lblThongKeChucVu.Location = new System.Drawing.Point(360, 120);
            this.lblThongKeChucVu.Name = "lblThongKeChucVu";
            this.lblThongKeChucVu.Size = new System.Drawing.Size(115, 16);
            this.lblThongKeChucVu.TabIndex = 6;
            this.lblThongKeChucVu.Text = "Thống kê chức vụ:";
            // 
            // FormBaoCao
            // 
            this.ClientSize = new System.Drawing.Size(700, 350);
            this.Controls.Add(this.lblTongSoNhanVien);
            this.Controls.Add(this.txtTongSoNhanVien);
            this.Controls.Add(this.lblTongSoHopDong);
            this.Controls.Add(this.txtTongSoHopDong);
            this.Controls.Add(this.lblThongKePhongBan);
            this.Controls.Add(this.dgvThongKePhongBan);
            this.Controls.Add(this.lblThongKeChucVu);
            this.Controls.Add(this.dgvThongKeChucVu);
            this.Name = "FormBaoCao";
            this.Text = "Báo Cáo Thống Kê";
            this.Load += new System.EventHandler(this.FormBaoCao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKePhongBan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKeChucVu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
