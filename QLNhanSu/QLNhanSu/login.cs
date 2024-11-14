using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLNhanSu
{
    public partial class login : Form
    {
        private string connectionString = @"Data Source=zodyyy\SQLEXPRESS;Initial Catalog=qlnhansu;Integrated Security=True;";

        public login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Role FROM Users WHERE Username = @Username AND Password = @Password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                try
                {
                    connection.Open();
                    var role = command.ExecuteScalar()?.ToString();

                    if (role != null)
                    {
                        MessageBox.Show("Đăng nhập thành công!");
                        FormMain mainForm = new FormMain(role, username);
                        mainForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message);
                }
            }
        }
    }
}
