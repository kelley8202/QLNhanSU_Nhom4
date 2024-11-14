using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QLNhanSu
{
    public partial class FormMain : System.Windows.Forms.Form
    {

        private FormHoatDong formHoatDong = new FormHoatDong();

        private string username;

        private string role;

        public FormMain(string role, string username)
        {
            InitializeComponent();
            this.role = role;
            this.username = username;
            SetupRolePermissions();
            GhiHoatDong($"User '{username}' đăng nhập vào hệ thống.");
        }

        private void GhiHoatDong(string noiDung)
        {
            string path = "hoatdong.txt";
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine($"{DateTime.Now}: {noiDung}");
            }
        }

        private void SetupRolePermissions()
        {
            if (role == "admin")
            {
                quảnLýNhânViênToolStripMenuItem.Enabled = true;
                quảnLýLươngToolStripMenuItem.Enabled = true;
                quảnLýHợpĐồngLaoĐộngToolStripMenuItem.Enabled = true;
                thốngKêVàBáoCáoToolStripMenuItem.Enabled = true;
                phânQuyềnNgườiDùngToolStripMenuItem.Enabled = true;
            }
            else if (role == "nhansu")
            {
                quảnLýNhânViênToolStripMenuItem.Enabled = true;
                quảnLýLươngToolStripMenuItem.Enabled = true;
                quảnLýHợpĐồngLaoĐộngToolStripMenuItem.Enabled = false;
                thốngKêVàBáoCáoToolStripMenuItem.Enabled = true;
                phânQuyềnNgườiDùngToolStripMenuItem.Enabled = false;
            }
            else
            {
                quảnLýNhânViênToolStripMenuItem.Enabled = false;
                quảnLýLươngToolStripMenuItem.Enabled = false;
                quảnLýHợpĐồngLaoĐộngToolStripMenuItem.Enabled = false;
                thốngKêVàBáoCáoToolStripMenuItem.Enabled = false;
                phânQuyềnNgườiDùngToolStripMenuItem.Enabled = false;
            }
        }
        public FormMain()
        {
            InitializeComponent();
        }

        private void mainfrom_Load(object sender, EventArgs e)
        {
        }
        
        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormQuanLyNhanVien formNhanVien = new FormQuanLyNhanVien(username);
            formNhanVien.ShowDialog();
            formHoatDong.GhiHoatDong(username, "Mở Form quản lý nhân viên", "FormMain");
        }

        private void quảnLýLươngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormQuanLyLuong formLuong = new FormQuanLyLuong(username);
            formLuong.ShowDialog();
            formHoatDong.GhiHoatDong(username, "Mở Form quản lý lương", "FormMain");
        }
        
        private void quảnLýHợpĐồngLaoĐộngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHopDong formHopDong = new FormHopDong();
            formHopDong.ShowDialog();
            formHoatDong.GhiHoatDong(username, "Mở Form quản lý hợp đồng lao động", "FormMain");
        }

        private void thốngKêVàBáoCáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBaoCao formThongKe = new FormBaoCao();
            formThongKe.ShowDialog();
            formHoatDong.GhiHoatDong(username, "Mở Form thống kê và báo cáo", "FormMain");
        }

        private void phânQuyềnNgườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPhanQuyen formPhanQuyen = new FormPhanQuyen(username);
            formPhanQuyen.ShowDialog();
            formHoatDong.GhiHoatDong(username, "Mở Form phân quyền người dùng", "FormMain");
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
            formHoatDong.GhiHoatDong(username, "Đăng xuất", "FormMain");

        }

        private void quảnLýPhòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPhongBan formPhongBan = new FormPhongBan(username);
            formPhongBan.ShowDialog();
            formHoatDong.GhiHoatDong(username, "Mở form quản lý phòng ban", "FormMain");

        }

        private void hoạtĐộngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHoatDong formHoatDong = new FormHoatDong();
            formHoatDong.ShowDialog();
            formHoatDong.GhiHoatDong(username, "Mở form theo dõi hoạt động", "FormMain");

        }
    }   
}
