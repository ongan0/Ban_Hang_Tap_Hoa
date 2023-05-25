using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Net.Mail;
using System.Net;
using _1.DAL.Models;
using _2.BUS.IServices;
using _2.BUS.Services;
//using System.Data.SqlClient;

namespace _3.PL
{
    public partial class FrmDangNhap : Form
    {
        INhanVienService _nhanVienService;

        public FrmDangNhap()
        {
            InitializeComponent();
            this.CenterToScreen();
            _nhanVienService = new NhanVienService();
            tbt_TenDn.Text = Properties.Settings.Default.tk;
            tbt_MatKhau.Text = Properties.Settings.Default.mk;
            //cb_save.Checked = true;

        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tbt_TenDn_Click(object sender, EventArgs e)
        {
            tbt_TenDn.BackColor = Color.White;
            panel3.BackColor = Color.White;
            panel5.BackColor = SystemColors.Control;
            tbt_MatKhau.BackColor = SystemColors.Control;
        }

        private void tbt_MatKhau_Click(object sender, EventArgs e)
        {
            tbt_MatKhau.BackColor= Color.White;
            panel5.BackColor= Color.White;
            tbt_TenDn.BackColor = SystemColors.Control;
            panel3.BackColor = SystemColors.Control;
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            tbt_MatKhau.UseSystemPasswordChar = false;
        }

        private void btn_QuenMK_Click(object sender, EventArgs e)
        {
            FrmQuenMK quenMK = new FrmQuenMK();
            quenMK.ShowDialog();
        }

        public void saveInfor()
        {
            if (cb_save.Checked == true)
            {
                Properties.Settings.Default.tk = tbt_TenDn.Text;
                Properties.Settings.Default.mk = tbt_MatKhau.Text;
                Properties.Settings.Default.TKdaLogin = tbt_TenDn.Text;
                Properties.Settings.Default.MKdaLogin = tbt_MatKhau.Text;
                Properties.Settings.Default.Save();

            }
            else
            {
                Properties.Settings.Default.tk = "";
                Properties.Settings.Default.mk = "";
                Properties.Settings.Default.TKdaLogin = tbt_TenDn.Text;
                Properties.Settings.Default.MKdaLogin = tbt_MatKhau.Text;
                Properties.Settings.Default.Save();
            }
        }

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            var login = _nhanVienService.GetNhanVienFromDB().Where(p => p.Gmail == tbt_TenDn.Text 
            && p.MatKhau == tbt_MatKhau.Text).FirstOrDefault();
            if(login != null)
            {

                if (login.IdChucVu == 1)
                {
                    saveInfor();
                    this.Hide();
                    FrmTrangChu trangC = new FrmTrangChu();
                    trangC.ShowDialog();

                    this.Close();
                }
                else if (login.IdChucVu == 2)
                {
                    saveInfor();
                    this.Hide();
                    FrmMenuNv trangChu = new FrmMenuNv();
                    trangChu.ShowDialog();

                    this.Close();
                }
                //saveInfor();
                //this.Hide();
                //FrmTrangChu trangChu = new FrmTrangChu();
                //trangChu.ShowDialog();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại");
            }
        }
    }
}
