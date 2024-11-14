using System;
using System.IO;
using System.Windows.Forms;

namespace QLNhanSu
{
    public partial class FormHoatDong : Form
    {
        private string filePath = @"hoatdong.txt";

        public FormHoatDong()
        {
            InitializeComponent();
        }

        public void GhiHoatDong(string username, string action, string formName)
        {
            string activity = $"{DateTime.Now}: [User: {username}] [Action: {action}] [Form: {formName}]";
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(activity);
            }
        }

        private void btnHienThiHoatDong_Click(object sender, EventArgs e)
        {
            lstHoatDong.Items.Clear();
            if (File.Exists(filePath))
            {
                string[] activities = File.ReadAllLines(filePath);
                lstHoatDong.Items.AddRange(activities);
            }
            else
            {
                MessageBox.Show("Không có hoạt động nào được ghi lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
