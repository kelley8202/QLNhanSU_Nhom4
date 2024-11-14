using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNhanSu
{
    public partial class FormPhongBan : System.Windows.Forms.Form
    {
        private string connectionString = @"Data Source=zodyyy\SQLEXPRESS;Initial Catalog=qlnhansu;Integrated Security=True;";
        private FormHoatDong formHoatDong = new FormHoatDong();
        private string username;
        public FormPhongBan(string username)
        {
            this.username = username;
            InitializeComponent();
        }

        private void FormPhongBan_Load(object sender, EventArgs e)
        {
            LoadPhongBanData();
        }

        private void LoadPhongBanData()
        {
            string query = @"
            SELECT 
                PhongBan.MaPB, 
                PhongBan.TenPB, 
                PhongBan.TruongPhong, 
                (SELECT COUNT(*) FROM NhanSu WHERE NhanSu.PhongBan = PhongBan.TenPB) AS SoLuongThanhVien 
            FROM 
                PhongBan";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();

                try
                {
                    connection.Open();
                    dataAdapter.Fill(dataTable);

                    dgvPhongBan.DataSource = dataTable;
                    dgvPhongBan.Columns["MaPB"].HeaderText = "Mã Phòng Ban";
                    dgvPhongBan.Columns["TenPB"].HeaderText = "Tên Phòng Ban";
                    dgvPhongBan.Columns["TruongPhong"].HeaderText = "Trưởng Phòng";
                    dgvPhongBan.Columns["SoLuongThanhVien"].HeaderText = "Số Lượng Thành Viên";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu phòng ban: " + ex.Message);
                }
            }
        }

        private void dgvPhongBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPhongBan.Rows[e.RowIndex];

                txtMaPB.Text = row.Cells["MaPB"].Value.ToString();
                cboPhongBan.Text = row.Cells["TenPB"].Value.ToString();
                txtTruongPhong.Text = row.Cells["TruongPhong"].Value.ToString();
                txtSoLuongThanhVien.Text = row.Cells["SoLuongThanhVien"].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cboPhongBan.Text) || string.IsNullOrWhiteSpace(txtTruongPhong.Text) || string.IsNullOrWhiteSpace(txtSoLuongThanhVien.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtSoLuongThanhVien.Text, out int soLuong))
            {
                MessageBox.Show("Số lượng thành viên phải là một số hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "INSERT INTO PhongBan (MaPB, TenPB, TruongPhong, SoLuongThanhVien) VALUES (@MaPB, @TenPB, @TruongPhong, @SoLuongThanhVien)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaPB", txtMaPB.Text);
                command.Parameters.AddWithValue("@TenPB", cboPhongBan.Text);
                command.Parameters.AddWithValue("@TruongPhong", txtTruongPhong.Text);
                command.Parameters.AddWithValue("@SoLuongThanhVien", soLuong);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Thêm phòng ban thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    formHoatDong.GhiHoatDong(username, "Thêm", "FormPhongBan");

                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }

                LoadPhongBanData();
            }
        }
        
        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            if (cboPhongBan.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn một phòng ban để xem chi tiết!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenPhongBan = cboPhongBan.Text;

            ShowChiTietPhongBan(tenPhongBan);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaPB.Text) || string.IsNullOrWhiteSpace(cboPhongBan.Text) || string.IsNullOrWhiteSpace(txtTruongPhong.Text) || string.IsNullOrWhiteSpace(txtSoLuongThanhVien.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtMaPB.Text, out int maPB) || !int.TryParse(txtSoLuongThanhVien.Text, out int soLuong))
            {
                MessageBox.Show("Mã phòng ban và số lượng thành viên phải là số hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "UPDATE PhongBan SET TenPB = @TenPB, TruongPhong = @TruongPhong, SoLuongThanhVien = @SoLuongThanhVien WHERE MaPB = @MaPB";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaPB", maPB);
                command.Parameters.AddWithValue("@TenPB", cboPhongBan.Text);
                command.Parameters.AddWithValue("@TruongPhong", txtTruongPhong.Text);
                command.Parameters.AddWithValue("@SoLuongThanhVien", soLuong);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật phòng ban thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Ghi hoạt động sửa phòng ban
                    formHoatDong.GhiHoatDong(username, $"Sửa phòng ban (Mã PB: {txtMaPB.Text}, Tên PB: {cboPhongBan.Text}, Trưởng phòng: {txtTruongPhong.Text})", "FormPhongBan");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }

                LoadPhongBanData();
                ClearInput();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaPB.Text))
            {
                MessageBox.Show("Vui lòng nhập mã phòng ban cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtMaPB.Text, out int maPB))
            {
                MessageBox.Show("Mã phòng ban phải là một số hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maPhongBan = txtMaPB.Text;

            string query = "DELETE FROM PhongBan WHERE MaPB = @MaPB";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaPB", maPB);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show($"Xóa phòng ban mã {maPhongBan} thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Ghi hoạt động xóa phòng ban
                    formHoatDong.GhiHoatDong(username, $"Xóa phòng ban (Mã PB: {maPhongBan})", "FormPhongBan");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }

                LoadPhongBanData();
                ClearInput();
            }
        }

        private void ClearInput()
        {
            txtMaPB.Text = "";
            cboPhongBan.SelectedIndex = -1;
            txtTruongPhong.Text = "";
            txtSoLuongThanhVien.Text = "";
        }

        private void dgvPhongBan_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPhongBan.Rows[e.RowIndex];
                string tenPhongBan = row.Cells["TenPB"].Value.ToString(); 
                DialogResult result = MessageBox.Show("Bạn có muốn xem thông tin chi tiết của phòng ban này không?", "Xem thông tin chi tiết", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    ShowChiTietPhongBan(tenPhongBan);
                }
            }
        }

        private void ShowChiTietPhongBan(string tenPhongBan)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                SELECT 
                    NhanSu.MaNV, 
                    NhanSu.HoTen, 
                    NhanSu.ChucVu, 
                    NhanSu.NgaySinh, 
                    NhanSu.DiaChi
                FROM 
                    NhanSu
                INNER JOIN 
                    PhongBan ON NhanSu.PhongBan = PhongBan.TenPB
                WHERE 
                    PhongBan.TenPB = @TenPB";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TenPB", tenPhongBan);

                try
                {
                    connection.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    if (dataTable.Rows.Count == 0)
                    {
                        MessageBox.Show("Không có dữ liệu chi tiết nhân viên cho phòng ban này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    formHoatDong.GhiHoatDong(username, $"Xem chi tiết phòng ban ({tenPhongBan})", "FormPhongBan");

                    FormChiTietPhongBan formChiTiet = new FormChiTietPhongBan(dataTable);
                    formChiTiet.ShowDialog();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi kết nối SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            formHoatDong.GhiHoatDong(username, "Thoát", "FormPhongBan");

        }

        private void cboPhongBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedPhongBan = cboPhongBan.SelectedItem.ToString();

            if (selectedPhongBan == "Ban Lãnh Đạo")
            {
                txtTruongPhong.Text = "Tổng Giám Đốc";
                txtTruongPhong.Enabled = false;
            }
            else
            {
                txtTruongPhong.Enabled = true;
                LoadChucVuForPhongBan(selectedPhongBan);
            }
        }
        private void LoadChucVuForPhongBan(string phongBan)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT DISTINCT ChucVu FROM NhanSu WHERE PhongBan = @PhongBan";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PhongBan", phongBan);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    List<string> chucVuList = new List<string>();

                    while (reader.Read())
                    {
                        chucVuList.Add(reader["ChucVu"].ToString());
                    }
                    
                    txtTruongPhong.Text = string.Join(", ", chucVuList);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải chức vụ: " + ex.Message);
                }
            }
        }
    }
}
