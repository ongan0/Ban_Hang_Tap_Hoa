using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _2.BUS.IServices;
using _2.BUS.Services;
using _1.DAL.Models;

namespace _3.PL
{
    public partial class FrmTrangChu : Form
    {
        INhanVienService _nhanVienService;
        IChucVuService _chucVuService;
        public FrmTrangChu()
        {
            InitializeComponent();
            _chucVuService = new ChucVuService();
            _nhanVienService = new NhanVienService();
            //lb_TenDn.Text = Properties.Settings.Default.tk;
            //lb_TenDn.Text = Const.TenNV;
            //lb_NgayGio.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            timer1.Start();
        }

       
        private Form currentFormChild;

        private void OpenChildForm(Form childFrom)
        {
            if(currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childFrom;
            childFrom.TopLevel = false;
            childFrom.FormBorderStyle = FormBorderStyle.None; 
            childFrom.Dock = DockStyle.Fill;
            panel_Body.Controls.Add(childFrom);
            panel_Body.Tag = childFrom;
            childFrom.BringToFront();
            childFrom.Show();
        }

        private void btn_BanHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmBanHang());
            lb_TenTrang.Text = btn_BanHang.Text;
        }

        private void btn_HoaDon_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmHoaDon());
            lb_TenTrang.Text = btn_HoaDon.Text;
        }

        private void btn_KhachHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmKhachHang());
            lb_TenTrang.Text = btn_KhachHang.Text;
        }

        private void btn_ThongKe_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmThongKe());
            lb_TenTrang.Text = btn_ThongKe.Text;
        }

        private void btn_NhanVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmNhanVien());
            lb_TenTrang.Text = btn_NhanVien.Text;
        }

        private void btn_QLKho_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmKhoHang());
            lb_TenTrang.Text = btn_QLKho.Text;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(currentFormChild != null)
            {
                currentFormChild.Close();
            }
            lb_TenTrang.Text = "Trang chủ";
        }

        private void btn_DangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn đăng xuất không?", "Đăng xuất", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
            {
                this.Hide();
                FrmDangNhap frmLogin = new FrmDangNhap();
                frmLogin.ShowDialog();
            }
        }

        private void FrmTrangChu_Load(object sender, EventArgs e)
        {
            var layEmail = Properties.Settings.Default.TKdaLogin;
            var nhanvien = _nhanVienService.GetNhanVienFromDB().FirstOrDefault(p => p.Gmail == layEmail);
            
            lb_MaNv.Text = nhanvien.MaNhanVien;
            lb_TenNv.Text = nhanvien.TenNhanVien;
            lb_Email.Text = nhanvien.Gmail;
            lb_DiaChi.Text = nhanvien.DiaChi;
            lb_Sdt.Text = nhanvien.SDT;
            lb_GioiTinh.Text = nhanvien.GioiTinh == 1 ? "Nam" : "Nữ";

            var role = _chucVuService.GetChucVuFromDB().FirstOrDefault(x => x.IdChucVu == nhanvien.IdChucVu);
            lb_TenDn.Text =  nhanvien.TenNhanVien;
            lb_ChucVu.Text = role.TenCV;
            pictureBox1.Image = Image.FromFile(nhanvien.LinkAnh);
 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            lb_Ngay.Text = DateTime.Now.ToLongDateString();
            lb_Gio.Text = DateTime.Now.ToLongTimeString();
        }

        private void btn_DoiMk_Click(object sender, EventArgs e)
        {
            var mk = _nhanVienService.GetNhanVienFromDB().FirstOrDefault(p => p.MatKhau == tbt_Mk.Text);
            if (mk == null)
            {
                MessageBox.Show("Mật khẩu cũ không chính xác");

            }
            else if (tbt_MkMoi.Text.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 6 kí tự");

            }
            else if (tbt_XacNhanMK.Text != tbt_MkMoi.Text)
            {
                MessageBox.Show("Nhập lại mật khẩu không chính xác");
            }


            else
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có muốn đổi mật khẩu không ?", "Thông Báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    var mkmoi = _nhanVienService.GetNhanVienFromDB().FirstOrDefault();
                    mkmoi.MatKhau = tbt_MkMoi.Text;
                    _nhanVienService.UpdateNhanVien(mkmoi);
                    MessageBox.Show("Đổi mật khẩu thành công");

                }
                this.Hide();
                FrmDangNhap login = new FrmDangNhap();
                login.ShowDialog();
                this.Close();
            }
        }

        
    }
}
