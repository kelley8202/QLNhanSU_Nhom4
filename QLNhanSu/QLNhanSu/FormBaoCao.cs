using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLNhanSu
{
    public partial class FormBaoCao : Form
    {
        private string connectionString = @"Data Source=zodyyy\SQLEXPRESS;Initial Catalog=qlnhansu;Integrated Security=True;";


        public FormBaoCao()
        {
            InitializeComponent();
        }

        private void FormBaoCao_Load(object sender, EventArgs e)
        {
            LoadThongKeTongSoNhanVien();
            LoadThongKeTongSoHopDong();
            LoadThongKePhongBan();
            LoadThongKeChucVu();
        }

        private void LoadThongKeTongSoNhanVien()
        {
            string query = "SELECT COUNT(*) FROM NhanSu";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    int totalEmployees = (int)command.ExecuteScalar();
                    txtTongSoNhanVien.Text = totalEmployees.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải tổng số nhân viên: " + ex.Message);
                }
            }
        }

        private void LoadThongKeTongSoHopDong()
        {
            string query = "SELECT COUNT(*) FROM HopDong";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    int totalContracts = (int)command.ExecuteScalar();
                    txtTongSoHopDong.Text = totalContracts.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải tổng số hợp đồng: " + ex.Message);
                }
            }
        }

        private void LoadThongKePhongBan()
        {
            string query = "SELECT PhongBan, COUNT(*) AS SoLuong FROM NhanSu GROUP BY PhongBan";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                try
                {
                    adapter.Fill(dataTable);
                    dgvThongKePhongBan.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải thống kê phòng ban: " + ex.Message);
                }
            }
        }

        private void LoadThongKeChucVu()
        {
            string query = "SELECT ChucVu, COUNT(*) AS SoLuong FROM NhanSu GROUP BY ChucVu";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                try
                {
                    adapter.Fill(dataTable);
                    dgvThongKeChucVu.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải thống kê chức vụ: " + ex.Message);
                }
            }
        }
    }
}
