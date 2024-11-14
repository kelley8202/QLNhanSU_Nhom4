using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLNhanSu
{
    public partial class FormPhanQuyen : System.Windows.Forms.Form
    {
        private string connectionString = @"Data Source=zodyyy\SQLEXPRESS;Initial Catalog=qlnhansu;Integrated Security=True;";
        private string username;
        private FormHoatDong formHoatDong = new FormHoatDong();


        public FormPhanQuyen(string username)
        {
            InitializeComponent();
            LoadUserData();
            this.username = username;
        }

        private void LoadUserData()
        {
            string query = "SELECT Username, Role FROM Users";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable userTable = new DataTable();

                try
                {
                    connection.Open();
                    adapter.Fill(userTable);
                    dgvThongTin.DataSource = userTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu tài khoản: " + ex.Message);
                }
            }
        }

        private void btnCapQuyen_Click(object sender, EventArgs e)
        {
            string selectedUser = txtUsername.Text;

            if (string.IsNullOrEmpty(selectedUser))
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần cấp quyền.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selectedUser.ToLower() == "admin")
            {
                MessageBox.Show("Không thể thay đổi quyền của tài khoản admin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UpdateRole(selectedUser, "admin");
            formHoatDong.GhiHoatDong(username, $"Cấp quyền cho tài khoản '{selectedUser}'", "FormPhanQuyen");
        }

        private void btnHaQuyen_Click(object sender, EventArgs e)
        {
            string selectedUser = txtUsername.Text;

            if (string.IsNullOrEmpty(selectedUser))
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần hạ quyền.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selectedUser.ToLower() == "admin")
            {
                MessageBox.Show("Không thể thay đổi quyền của tài khoản admin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UpdateRole(selectedUser, "nhansu");
            formHoatDong.GhiHoatDong(username, $"Hạ quyền cho tài khoản '{selectedUser}'", "FormPhanQuyen");
        }

        private void UpdateRole(string username, string newRole)
        {
            string query = "UPDATE Users SET Role = @newRole WHERE Username = @username";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@newRole", newRole);
                command.Parameters.AddWithValue("@username", username);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"Đã thay đổi quyền của tài khoản '{username}' thành '{newRole}'.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadUserData(); // Cập nhật lại dữ liệu sau khi thay đổi quyền
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy tài khoản.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi hệ thống: " + ex.Message);
                }
            }
        }

        private void dgvThongTin_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvThongTin.Rows[e.RowIndex];
                txtUsername.Text = row.Cells["Username"].Value.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormThemTaiKhoan formThemTaiKhoan = new FormThemTaiKhoan();
            formThemTaiKhoan.FormClosed += (s, args) => LoadUserData();
            formThemTaiKhoan.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (username.ToLower() == "admin")
            {
                MessageBox.Show("Không thể xóa tài khoản admin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "DELETE FROM Users WHERE Username = @username";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Đã xóa tài khoản thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadUserData();
                        formHoatDong.GhiHoatDong(username, $"Xóa tài khoản '{username}'", "FormPhanQuyen");

                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy tài khoản.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi hệ thống: " + ex.Message);
                }
            }
        }
    }
}
