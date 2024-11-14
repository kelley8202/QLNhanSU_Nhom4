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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QLNhanSu
{
    public partial class FormQuanLyLuong : System.Windows.Forms.Form
    {
        private string connectionString = @"Data Source=zodyyy\SQLEXPRESS;Initial Catalog=qlnhansu;Integrated Security=True;";
        private FormHoatDong formHoatDong = new FormHoatDong();
        private string username;

        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;
        public FormQuanLyLuong(string username)
        {
            InitializeComponent();
            LoadData();
            this.username = username;
        }
        private void LoadData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT l.MaNV, nv.HoTen, l.LuongCoBan, l.PhuCap, l.NgayNhanLuong " +
                               "FROM Luong l " +
                               "JOIN NhanSu nv ON l.MaNV = nv.MaNV";

                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dgvLuong.DataSource = dataTable;

                    dgvLuong.Columns["MaNV"].HeaderText = "Mã NV";
                    dgvLuong.Columns["HoTen"].HeaderText = "Họ Tên";
                    dgvLuong.Columns["LuongCoBan"].HeaderText = "Lương Cơ Bản";
                    dgvLuong.Columns["PhuCap"].HeaderText = "Phụ Cấp";
                    dgvLuong.Columns["NgayNhanLuong"].HeaderText = "Ngày Nhận Lương";
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi kết nối SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text) || string.IsNullOrWhiteSpace(txtLuongCoBan.Text) || string.IsNullOrWhiteSpace(txtPhuCap.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin lương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Luong (MaNV, LuongCoBan, PhuCap, NgayNhanLuong) VALUES (@MaNV, @LuongCoBan, @PhuCap, @NgayNhanLuong)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaNV", txtMaNV.Text);
                command.Parameters.AddWithValue("@LuongCoBan", decimal.Parse(txtLuongCoBan.Text));
                command.Parameters.AddWithValue("@PhuCap", decimal.Parse(txtPhuCap.Text));
                command.Parameters.AddWithValue("@NgayNhanLuong", dtpNgayNhanLuong.Value);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Thêm lương thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                formHoatDong.GhiHoatDong(username, "Thêm", "FormQuanLyLuong");

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text) || string.IsNullOrWhiteSpace(txtLuongCoBan.Text) || string.IsNullOrWhiteSpace(txtPhuCap.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin lương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Luong SET LuongCoBan = @LuongCoBan, PhuCap = @PhuCap, NgayNhanLuong = @NgayNhanLuong WHERE MaNV = @MaNV";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaNV", txtMaNV.Text);
                command.Parameters.AddWithValue("@LuongCoBan", decimal.Parse(txtLuongCoBan.Text));
                command.Parameters.AddWithValue("@PhuCap", decimal.Parse(txtPhuCap.Text));
                command.Parameters.AddWithValue("@NgayNhanLuong", dtpNgayNhanLuong.Value);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Cập nhật lương thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                formHoatDong.GhiHoatDong(username, "Sửa", "FormQuanLyLuong");

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên để xóa lương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Luong WHERE MaNV = @MaNV";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaNV", txtMaNV.Text);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Xóa lương thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                formHoatDong.GhiHoatDong(username, "Xóa", "FormQuanLyLuong");

            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            formHoatDong.GhiHoatDong(username, "Thoát", "FormQuanLyLuong");

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchValue = txtSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchValue))
            {
                MessageBox.Show("Vui lòng nhập thông tin cần tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT l.MaNV, nv.HoTen, l.LuongCoBan, l.PhuCap, l.NgayNhanLuong " +
                               "FROM Luong l " +
                               "JOIN NhanSu nv ON l.MaNV = nv.MaNV " +
                               "WHERE l.MaNV LIKE @search OR nv.HoTen LIKE @search";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@search", "%" + searchValue + "%");

                try
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dgvLuong.DataSource = dataTable;
                    formHoatDong.GhiHoatDong(username, "Tìm kiếm", "FormQuanLyLuong");


                    if (dataTable.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy kết quả nào phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi kết nối SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvLuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLuong.Rows[e.RowIndex];
                txtMaNV.Text = row.Cells["MaNV"].Value.ToString();
                txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
                txtLuongCoBan.Text = row.Cells["LuongCoBan"].Value.ToString();
                txtPhuCap.Text = row.Cells["PhuCap"].Value.ToString();
                dtpNgayNhanLuong.Value = Convert.ToDateTime(row.Cells["NgayNhanLuong"].Value);
            }
        }
    }
}
