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
    public partial class FormHopDong : System.Windows.Forms.Form
    {
        private string connectionString = @"Data Source=zodyyy\SQLEXPRESS;Initial Catalog=qlnhansu;Integrated Security=True;";
        private string username;
        private FormHoatDong formHoatDong = new FormHoatDong();

        public FormHopDong(string username)
        {
            InitializeComponent();
            this.username = username;
            LoadData();
        }

        private void LoadData()
        {
            string query = "SELECT * FROM HopDong";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvHopDong.DataSource = dt;

                dgvHopDong.Columns["MaHD"].HeaderText = "Mã Hợp Đồng";
                dgvHopDong.Columns["MaNV"].HeaderText = "Mã Nhân Viên";
                dgvHopDong.Columns["NgayBatDau"].HeaderText = "Ngày Bắt Đầu";
                dgvHopDong.Columns["NgayKetThuc"].HeaderText = "Ngày Kết Thúc";
                dgvHopDong.Columns["LoaiHopDong"].HeaderText = "Loại Hợp Đồng";
                dgvHopDong.Columns["MucLuong"].HeaderText = "Mức Lương";

            }
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            FormThemHopDong formThemHopDong = new FormThemHopDong();
            formThemHopDong.FormClosed += (s, args) => LoadData();
            formThemHopDong.ShowDialog();
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            string MaHD = txtMaHD.Text;
            string maNV = txtMaNV.Text;

            string query = "UPDATE HopDong SET MaNV = @MaNV, NgayBatDau = @NgayBatDau, NgayKetThuc = @NgayKetThuc, LoaiHopDong = @LoaiHopDong WHERE MaHD = @MaHD";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaHD", MaHD);
                command.Parameters.AddWithValue("@MaNV", maNV);
                command.Parameters.AddWithValue("@NgayBatDau", dtpNgayBatDau.Value);
                command.Parameters.AddWithValue("@NgayKetThuc", dtpNgayKetThuc.Value);
                command.Parameters.AddWithValue("@LoaiHopDong", txtLoaiHopDong.Text);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Sửa hợp đồng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy hợp đồng để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sửa hợp đồng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            string MaHD = txtMaHD.Text;

            // Hiển thị thông báo xác nhận
            DialogResult result = MessageBox.Show("Bạn có chắc chắn chấm dứt hợp đồng của nhân viên này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string query = "DELETE FROM HopDong WHERE MaHD = @MaHD";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaHD", MaHD);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Chấm dứt hợp đồng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy hợp đồng để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa hợp đồng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }



        private void dgvHopDong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvHopDong.Rows[e.RowIndex];
                txtMaHD.Text = row.Cells["MaHD"].Value.ToString();
                txtMaNV.Text = row.Cells["MaNV"].Value.ToString();
                dtpNgayBatDau.Value = Convert.ToDateTime(row.Cells["NgayBatDau"].Value);
                dtpNgayKetThuc.Value = Convert.ToDateTime(row.Cells["NgayKetThuc"].Value);
                txtLoaiHopDong.Text = row.Cells["LoaiHopDong"].Value.ToString();
                txtMucLuong.Text = row.Cells["MucLuong"].Value.ToString();
            }
        }

        private void btnGiaHan_Click(object sender, EventArgs e)
        {
            string MaHD = txtMaHD.Text;

            // Kiểm tra nếu hợp đồng không tồn tại
            if (string.IsNullOrEmpty(MaHD))
            {
                MessageBox.Show("Vui lòng chọn hợp đồng cần gia hạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hiển thị thông báo chọn thời gian gia hạn
            var giaHanOptions = MessageBox.Show("Bạn có muốn gia hạn cho hợp đồng này không???", "Gia hạn hợp đồng", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (giaHanOptions == DialogResult.Cancel)
            {
                return;
            }

            int thoiGianGiaHan = 0;
            if (giaHanOptions == DialogResult.Yes)
            {
                // Hiển thị các lựa chọn gia hạn
                string message = "Chọn thời gian gia hạn hợp đồng:";
                var giaHanDialog = new FormGiaHan(); // Form gia hạn mới, bạn sẽ tạo một form này

                if (giaHanDialog.ShowDialog() == DialogResult.OK)
                {
                    // Cập nhật ngày kết thúc hợp đồng
                    thoiGianGiaHan = giaHanDialog.GetSelectedDuration(); // Trả về thời gian gia hạn

                    // Cập nhật ngày kết thúc hợp đồng
                    UpdateNgayKetThuc(MaHD, thoiGianGiaHan);
                }
            }
        }

        // Hàm cập nhật ngày kết thúc hợp đồng
        private void UpdateNgayKetThuc(string MaHD, int thoiGianGiaHan)
        {
            string query = "SELECT NgayKetThuc FROM HopDong WHERE MaHD = @MaHD";
            DateTime currentNgayKetThuc = DateTime.MinValue;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaHD", MaHD);

                try
                {
                    connection.Open();
                    currentNgayKetThuc = (DateTime)command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy ngày kết thúc hợp đồng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Cộng thêm thời gian gia hạn vào NgayKetThuc
            DateTime newNgayKetThuc = currentNgayKetThuc;

            if (thoiGianGiaHan == 1) // 1 tháng
            {
                newNgayKetThuc = currentNgayKetThuc.AddMonths(1);
            }
            else if (thoiGianGiaHan == 3) // 3 tháng
            {
                newNgayKetThuc = currentNgayKetThuc.AddMonths(3);
            }
            else if (thoiGianGiaHan == 6) // 6 tháng
            {
                newNgayKetThuc = currentNgayKetThuc.AddMonths(6);
            }
            else if (thoiGianGiaHan == 12) // 1 năm
            {
                newNgayKetThuc = currentNgayKetThuc.AddYears(1);
            }
            else if (thoiGianGiaHan == 36) // 3 năm
            {
                newNgayKetThuc = currentNgayKetThuc.AddYears(3);
            }
            else if (thoiGianGiaHan == 120) // 10 năm
            {
                newNgayKetThuc = currentNgayKetThuc.AddYears(10);
            }

            // Cập nhật ngày kết thúc mới vào cơ sở dữ liệu
            string updateQuery = "UPDATE HopDong SET NgayKetThuc = @NgayKetThuc WHERE MaHD = @MaHD";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(updateQuery, connection);
                command.Parameters.AddWithValue("@NgayKetThuc", newNgayKetThuc);
                command.Parameters.AddWithValue("@MaHD", MaHD);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Gia hạn hợp đồng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(); // Load lại dữ liệu hợp đồng
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi gia hạn hợp đồng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}