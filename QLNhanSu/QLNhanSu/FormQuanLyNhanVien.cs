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
    public partial class FormQuanLyNhanVien : System.Windows.Forms.Form
    {
        private string connectionString = @"Data Source=zodyyy\SQLEXPRESS;Initial Catalog=qlnhansu;Integrated Security=True;";
        private FormHoatDong formHoatDong = new FormHoatDong();
        private string username;
        public FormQuanLyNhanVien(string username)
        {
            this.username = username;
            InitializeComponent();
        }



        private void FormQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            LoadEmployeeData();
            List<string> phongBans = new List<string>()
            {
                "Ban Lãnh Đạo",
                "Kế Toán",
                "Kỹ Thuật",
                "Thiết Kế"
    };

            cboPhongBan.DataSource = phongBans;
        }
        private void LoadEmployeeData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM NhanSu";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();

                try
                {
                    connection.Open();
                    adapter.Fill(dataTable);
                    dataGridViewNhanVien.DataSource = dataTable;

                    dataGridViewNhanVien.Columns["MaNV"].HeaderText = "Mã Nhân Viên";
                    dataGridViewNhanVien.Columns["HoTen"].HeaderText = "Họ Tên";
                    dataGridViewNhanVien.Columns["ChucVu"].HeaderText = "Chức Vụ";
                    dataGridViewNhanVien.Columns["PhongBan"].HeaderText = "Phòng Ban";
                    dataGridViewNhanVien.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
                    dataGridViewNhanVien.Columns["DiaChi"].HeaderText = "Địa Chỉ";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                }
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO NhanSu (MaNV, HoTen, ChucVu, PhongBan, NgaySinh, DiaChi) " +
                               "VALUES (@MaNV, @HoTen, @ChucVu, @PhongBan, @NgaySinh, @DiaChi)";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@MaNV", txtMaNV.Text);
                command.Parameters.AddWithValue("@HoTen", txtHoTen.Text);
                command.Parameters.AddWithValue("@ChucVu", txtChucVu.Text);
                command.Parameters.AddWithValue("@PhongBan", cboPhongBan.SelectedItem.ToString());
                command.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);
                command.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);

                try
                {
                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Thêm nhân viên thành công!");
                        LoadEmployeeData();
                        formHoatDong.GhiHoatDong(username, $"Thêm nhân viên với mã NV {txtMaNV.Text}", "FormQuanLyNhanVien");
                    }
                    else
                    {
                        MessageBox.Show("Thêm nhân viên thất bại.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm nhân viên: " + ex.Message);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text) || string.IsNullOrWhiteSpace(txtChucVu.Text) || string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE NhanSu SET HoTen = @HoTen, ChucVu = @ChucVu, PhongBan = @PhongBan, NgaySinh = @NgaySinh, DiaChi = @DiaChi WHERE MaNV = @MaNV";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@MaNV", txtMaNV.Text);
                command.Parameters.AddWithValue("@HoTen", txtHoTen.Text);
                command.Parameters.AddWithValue("@ChucVu", txtChucVu.Text);
                command.Parameters.AddWithValue("@PhongBan", cboPhongBan.SelectedItem.ToString());
                command.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);
                command.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);

                try
                {
                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Cập nhật thông tin nhân viên thành công!");
                        LoadEmployeeData();
                        formHoatDong.GhiHoatDong(username, $"Cập nhật nhân viên mã NV {txtMaNV.Text}: Họ Tên = {txtHoTen.Text}, Chức Vụ = {txtChucVu.Text}, Phòng Ban = {cboPhongBan.SelectedItem}, Ngày Sinh = {dtpNgaySinh.Value.ToShortDateString()}, Địa Chỉ = {txtDiaChi.Text}", "FormQuanLyNhanVien");
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại. Kiểm tra lại thông tin nhân viên hoặc phòng ban.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Trước khi xóa, lấy mã nhân viên
                    string employeeId = txtMaNV.Text;

                    // Tiến hành xóa nhân viên
                    string deleteQuery = "DELETE FROM NhanSu WHERE MaNV = @MaNV";
                    SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                    deleteCommand.Parameters.AddWithValue("@MaNV", employeeId);

                    try
                    {
                        connection.Open();
                        int result = deleteCommand.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show($"Xóa nhân viên mã {employeeId} thành công!");
                            LoadEmployeeData();

                            // Ghi lại hoạt động: Xóa nhân viên theo mã nhân viên
                            formHoatDong.GhiHoatDong(username, $"Xóa nhân viên (Mã NV: {employeeId})", "FormQuanLyNhanVien");
                        }
                        else
                        {
                            MessageBox.Show("Xóa thất bại.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa nhân viên: " + ex.Message);
                    }
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM NhanSu WHERE MaNV LIKE @Search OR HoTen LIKE @Search";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Search", "%" + txtSearch.Text + "%");

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                try
                {
                    connection.Open();
                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count == 0)
                    {
                        MessageBox.Show("Không có nhân viên nào trùng với mã bạn tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        formHoatDong.GhiHoatDong(username, $"Tìm kiếm nhân viên với từ khóa: {txtSearch.Text}", "FormQuanLyNhanVien");
                        dataGridViewNhanVien.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm nhân viên: " + ex.Message);
                }
            }

        }

        private void dataGridViewNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewNhanVien.Rows[e.RowIndex];

                txtMaNV.Text = row.Cells["MaNV"].Value.ToString();
                txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
                txtChucVu.Text = row.Cells["ChucVu"].Value.ToString();
                dtpNgaySinh.Text = row.Cells["NgaySinh"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                var tenPhongBan = row.Cells["PhongBan"].Value.ToString();

                foreach (var item in cboPhongBan.Items)
                {
                    if (item.ToString() == tenPhongBan)
                    {
                        cboPhongBan.SelectedItem = item;
                        break;
                    }
                }
            }
        }



        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            formHoatDong.GhiHoatDong(username, "Thoát", "FormQuanLyNhanVien");

        }


    }
}
