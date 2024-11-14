using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLNhanSu
{
    public partial class FormThemHopDong : System.Windows.Forms.Form
    {
        private string connectionString = @"Data Source=zodyyy\SQLEXPRESS;Initial Catalog=qlnhansu;Integrated Security=True;";

        public FormThemHopDong()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text;

            // Kiểm tra nếu mã nhân viên đã tồn tại trong bảng hợp đồng
            if (KiemTraMaNhanVien(maNV))
            {
                MessageBox.Show("Mã nhân viên này đã tồn tại trong bảng Hợp Đồng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Câu lệnh SQL để thêm hợp đồng mới, không cần phải đưa MaHD vào vì nó là trường tự động tăng
            string query = "INSERT INTO HopDong (MaNV, NgayBatDau, NgayKetThuc, LoaiHopDong,MucLuong) " +
                           "VALUES (@MaNV, @NgayBatDau, @NgayKetThuc, @LoaiHopDong, @MucLuong)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaNV", maNV);
                command.Parameters.AddWithValue("@NgayBatDau", dtpNgayBatDau.Value);
                command.Parameters.AddWithValue("@NgayKetThuc", dtpNgayKetThuc.Value);
                command.Parameters.AddWithValue("@LoaiHopDong", txtLoaiHopDong.Text);
                command.Parameters.AddWithValue("@MucLuong", txtMucLuong.Text);
                
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Thêm hợp đồng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Đóng form sau khi thêm thành công
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm hợp đồng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Kiểm tra mã nhân viên đã tồn tại trong bảng Hợp Đồng hay chưa
        private bool KiemTraMaNhanVien(string maNV)
        {
            bool isExist = false;
            string query = "SELECT COUNT(*) FROM HopDong WHERE MaNV = @MaNV";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaNV", maNV);

                try
                {
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    if (count > 0)
                    {
                        isExist = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi kiểm tra mã nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return isExist;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close(); // Đóng form mà không thêm hợp đồng
        }
    }
}
