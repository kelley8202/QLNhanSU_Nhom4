namespace QLNhanSu
{
    partial class FormPhongBan
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgvPhongBan;
        private System.Windows.Forms.ComboBox cboPhongBan;
        private System.Windows.Forms.TextBox txtMaPB;
        private System.Windows.Forms.TextBox txtTruongPhong;
        private System.Windows.Forms.TextBox txtSoLuongThanhVien;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnXemChiTiet;
        private System.Windows.Forms.Label lblMaPB;
        private System.Windows.Forms.Label lblPhongBan;
        private System.Windows.Forms.Label lblTruongPhong;
        private System.Windows.Forms.Label lblSoLuongThanhVien;

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
            this.dgvPhongBan = new System.Windows.Forms.DataGridView();
            this.cboPhongBan = new System.Windows.Forms.ComboBox();
            this.txtMaPB = new System.Windows.Forms.TextBox();
            this.txtTruongPhong = new System.Windows.Forms.TextBox();
            this.txtSoLuongThanhVien = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnXemChiTiet = new System.Windows.Forms.Button();
            this.lblMaPB = new System.Windows.Forms.Label();
            this.lblPhongBan = new System.Windows.Forms.Label();
            this.lblTruongPhong = new System.Windows.Forms.Label();
            this.lblSoLuongThanhVien = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhongBan)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPhongBan
            // 
            this.dgvPhongBan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhongBan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhongBan.Location = new System.Drawing.Point(12, 12);
            this.dgvPhongBan.MinimumSize = new System.Drawing.Size(50, 0);
            this.dgvPhongBan.Name = "dgvPhongBan";
            this.dgvPhongBan.RowHeadersWidth = 51;
            this.dgvPhongBan.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvPhongBan.Size = new System.Drawing.Size(760, 250);
            this.dgvPhongBan.TabIndex = 0;
            this.dgvPhongBan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhongBan_CellClick);
            this.dgvPhongBan.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhongBan_CellDoubleClick);
            // 
            // cboPhongBan
            // 
            this.cboPhongBan.FormattingEnabled = true;
            this.cboPhongBan.Items.AddRange(new object[] {
            "Ban Lãnh Đạo",
            "Kế Toán",
            "Kỹ Thuật",
            "Thiết Kế"});
            this.cboPhongBan.Location = new System.Drawing.Point(140, 280);
            this.cboPhongBan.Name = "cboPhongBan";
            this.cboPhongBan.Size = new System.Drawing.Size(250, 24);
            this.cboPhongBan.TabIndex = 1;
            this.cboPhongBan.SelectedIndexChanged += new System.EventHandler(this.cboPhongBan_SelectedIndexChanged);
            // 
            // txtMaPB
            // 
            this.txtMaPB.Location = new System.Drawing.Point(140, 320);
            this.txtMaPB.Name = "txtMaPB";
            this.txtMaPB.Size = new System.Drawing.Size(250, 22);
            this.txtMaPB.TabIndex = 2;
            // 
            // txtTruongPhong
            // 
            this.txtTruongPhong.Location = new System.Drawing.Point(140, 360);
            this.txtTruongPhong.Name = "txtTruongPhong";
            this.txtTruongPhong.Size = new System.Drawing.Size(250, 22);
            this.txtTruongPhong.TabIndex = 3;
            // 
            // txtSoLuongThanhVien
            // 
            this.txtSoLuongThanhVien.Enabled = false;
            this.txtSoLuongThanhVien.Location = new System.Drawing.Point(140, 400);
            this.txtSoLuongThanhVien.Name = "txtSoLuongThanhVien";
            this.txtSoLuongThanhVien.Size = new System.Drawing.Size(250, 22);
            this.txtSoLuongThanhVien.TabIndex = 4;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(420, 341);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(120, 23);
            this.btnThem.TabIndex = 5;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(420, 393);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(120, 23);
            this.btnSua.TabIndex = 6;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(618, 313);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(120, 23);
            this.btnXoa.TabIndex = 7;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnXemChiTiet
            // 
            this.btnXemChiTiet.Location = new System.Drawing.Point(420, 280);
            this.btnXemChiTiet.Name = "btnXemChiTiet";
            this.btnXemChiTiet.Size = new System.Drawing.Size(120, 23);
            this.btnXemChiTiet.TabIndex = 8;
            this.btnXemChiTiet.Text = "Xem Chi Tiết";
            this.btnXemChiTiet.UseVisualStyleBackColor = true;
            this.btnXemChiTiet.Click += new System.EventHandler(this.btnXemChiTiet_Click);
            // 
            // lblMaPB
            // 
            this.lblMaPB.AutoSize = true;
            this.lblMaPB.Location = new System.Drawing.Point(12, 320);
            this.lblMaPB.Name = "lblMaPB";
            this.lblMaPB.Size = new System.Drawing.Size(98, 16);
            this.lblMaPB.TabIndex = 9;
            this.lblMaPB.Text = "Mã Phòng Ban:";
            // 
            // lblPhongBan
            // 
            this.lblPhongBan.AutoSize = true;
            this.lblPhongBan.Location = new System.Drawing.Point(12, 280);
            this.lblPhongBan.Name = "lblPhongBan";
            this.lblPhongBan.Size = new System.Drawing.Size(76, 16);
            this.lblPhongBan.TabIndex = 10;
            this.lblPhongBan.Text = "Phòng Ban:";
            // 
            // lblTruongPhong
            // 
            this.lblTruongPhong.AutoSize = true;
            this.lblTruongPhong.Location = new System.Drawing.Point(12, 360);
            this.lblTruongPhong.Name = "lblTruongPhong";
            this.lblTruongPhong.Size = new System.Drawing.Size(95, 16);
            this.lblTruongPhong.TabIndex = 11;
            this.lblTruongPhong.Text = "Trưởng Phòng:";
            // 
            // lblSoLuongThanhVien
            // 
            this.lblSoLuongThanhVien.AutoSize = true;
            this.lblSoLuongThanhVien.Location = new System.Drawing.Point(12, 400);
            this.lblSoLuongThanhVien.Name = "lblSoLuongThanhVien";
            this.lblSoLuongThanhVien.Size = new System.Drawing.Size(138, 16);
            this.lblSoLuongThanhVien.TabIndex = 12;
            this.lblSoLuongThanhVien.Text = "Số Lượng Thành Viên:";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(618, 372);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(120, 23);
            this.btnExit.TabIndex = 13;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FormPhongBan
            // 
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblSoLuongThanhVien);
            this.Controls.Add(this.lblTruongPhong);
            this.Controls.Add(this.lblPhongBan);
            this.Controls.Add(this.lblMaPB);
            this.Controls.Add(this.btnXemChiTiet);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtSoLuongThanhVien);
            this.Controls.Add(this.txtTruongPhong);
            this.Controls.Add(this.txtMaPB);
            this.Controls.Add(this.cboPhongBan);
            this.Controls.Add(this.dgvPhongBan);
            this.Name = "FormPhongBan";
            this.Text = "Quản Lý Phòng Ban";
            this.Load += new System.EventHandler(this.FormPhongBan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhongBan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button btnExit;
    }
}

