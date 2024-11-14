using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNhanSu
{
    public partial class FormChiTietPhongBan : System.Windows.Forms.Form
    {
        private string connectionString = @"Data Source=zodyyy\SQLEXPRESS;Initial Catalog=qlnhansu;Integrated Security=True;";


        public FormChiTietPhongBan(DataTable nhanSuData)
        {
            InitializeComponent();
            if (nhanSuData != null && nhanSuData.Rows.Count > 0)
            {
                dgvChiTiet.DataSource = nhanSuData;
            }
            else
            {
                MessageBox.Show("Không có dữ liệu nhân viên để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvChiTiet.DataSource = null;
            }
        }

        private void FormChiTietPhongBan_Load(object sender, EventArgs e)
        {
            if (dgvChiTiet.Columns.Contains("MaNV"))
            {
                dgvChiTiet.Columns["MaNV"].HeaderText = "Mã Nhân Viên";
            }
            if (dgvChiTiet.Columns.Contains("HoTen"))
            {
                dgvChiTiet.Columns["HoTen"].HeaderText = "Họ và Tên";
            }
            if (dgvChiTiet.Columns.Contains("ChucVu"))
            {
                dgvChiTiet.Columns["ChucVu"].HeaderText = "Chức Vụ";
            }
            if (dgvChiTiet.Columns.Contains("NgaySinh"))
            {
                dgvChiTiet.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
            }
            if (dgvChiTiet.Columns.Contains("DiaChi"))
            {
                dgvChiTiet.Columns["DiaChi"].HeaderText = "Địa Chỉ";
            }

            dgvChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
