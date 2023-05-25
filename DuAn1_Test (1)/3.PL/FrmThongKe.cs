using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using _1.DAL.Models;
using _2.BUS.Services;
using _2.BUS.IServices;

namespace _3.PL
{
    public partial class FrmThongKe : Form
    {
        private IHoaDonService hoaDonService;
        private IKhachHangService khachHangService;
        private IHoaDonChiTietService hoaDonChiTietService;
        private IChiTietSanPhamService chiTietSanPhamService;
        public List<HoaDon> _lstOrder;
        ISanPhamService SanPham;
        private Form activeForm;
        public FrmThongKe()
        {
            InitializeComponent();

            SanPham = new SanPhamService();
            hoaDonChiTietService = new HoaDonChiTietService();
            hoaDonService = new HoaDonService();
            khachHangService = new KhachHangService();
            chiTietSanPhamService = new ChiTietSanPhamService();
            _lstOrder = hoaDonService.GetHoaDonFromDB();
            loadDate();
            loadData();


        }
        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panel_kh.Controls.Add(childForm);
            this.panel_kh.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        public void loadDate()
        {
            for (int i = 1; i < 13; i++)
            {
                cbb_thang.Items.Add(i);
            }
            var x = Convert.ToInt32(hoaDonService.GetHoaDonFromDB().First().NgayTao.ToString("yyyy"));
            var y = Convert.ToInt32(hoaDonService.GetHoaDonFromDB().Last().NgayTao.ToString("yyyy"));
            for (int i = x; i <= y; i++)
            {
                cbb_nam.Items.Add(i);
            }
        }




        public void loadData()
        {
            dtg_show1.Rows.Clear();
            var x = (from a in _lstOrder
                     join b in khachHangService.GetKhachHangFromDB() on a.IdKhachHang equals b.IdKhachHang
                     join c in hoaDonChiTietService.GetHoaDonChiTietFromDB() on a.IdHoaDon equals c.IdHoaDon
                     join d in chiTietSanPhamService.GetChiTietSpFromDB() on c.IdChiTietSp equals d.IdChiTietSp
                     join e in SanPham.GetSanPhamFromDB() on d.IdSanPham equals e.IdSanPham
                     where a.MaHD.ToLower().Contains(tbt_timkiem.Text.ToLower())
                     select new { a, b, c, d, e });
            foreach (var i in x)
            {
                dtg_show1.Rows.Add(i.a.MaHD,
                    i.e.TenSP,
                    i.c.SoLuong,
                    i.c.GiaBan,

                    i.c.SoLuong * i.c.GiaBan,
                    i.b.SDT == "0" ? " khach vang lai" : i.b.SDT
                    );
            }

            lb_doanhthu.Text = x.Select(x => x.a).Distinct().Sum(x => x.TongTien).ToString();
            lb_sohd.Text = x.GroupBy(x => x.a).Count().ToString();
            lb_sohdchuathanhtoan.Text = x.Select(x => x.a).Distinct().Where(x => x.TrangThai == 0).Count().ToString();
            lb_sokhachhang.Text = x.GroupBy(x => x.b).Count().ToString();
        }

        

        private void dtp_ngay_ValueChanged(object sender, EventArgs e)
        {
            _lstOrder = hoaDonService.GetHoaDonFromDB().Where(x => x.NgayTao.ToString("dd-MM-yyyy") == dtp_ngay.Value.ToString("dd-MM-yyyy")).ToList();
            loadData();
        }

        private void cbb_thang_TextChanged(object sender, EventArgs e)
        {
            _lstOrder = hoaDonService.GetHoaDonFromDB().Where(x => (x.NgayTao.Month.ToString() == cbb_thang.Text && x.NgayTao.Year.ToString() == cbb_nam.Text)).ToList();
            loadData();
        }

        private void cbb_nam_TextChanged(object sender, EventArgs e)
        {
            if (cbb_thang.Text != "")
            {
                _lstOrder = hoaDonService.GetHoaDonFromDB().Where(x => (x.NgayTao.Month.ToString() == cbb_thang.Text && x.NgayTao.Year.ToString() == cbb_nam.Text)).ToList();
                loadData();
            }
        }


        public void loadData1()
        {
            dtg_show1.Rows.Clear();
            var x = (from a in _lstOrder
                     join b in khachHangService.GetKhachHangFromDB() on a.IdKhachHang equals b.IdKhachHang
                     join c in hoaDonChiTietService.GetHoaDonChiTietFromDB() on a.IdHoaDon equals c.IdHoaDon
                     join d in chiTietSanPhamService.GetChiTietSpFromDB() on c.IdChiTietSp equals d.IdChiTietSp
                     join e in SanPham.GetSanPhamFromDB() on d.IdSanPham equals e.IdSanPham
                     where a.MaHD.ToLower().Contains(tbt_timkiem.Text.ToLower())
                     select new { a, b, c, d, e });
            foreach (var i in x)
            {
                dtg_show1.Rows.Add(i.a.MaHD,
                    i.e.TenSP,
                    i.c.SoLuong,
                    i.c.GiaBan,
                    i.c.SoLuong * i.c.GiaBan,
                    i.b.SDT == "0" ? " khach vang lai" : i.b.SDT
                    );
            }


        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            dtg_show1.Rows.Clear();
            var x = (from a in _lstOrder
                     join b in khachHangService.GetKhachHangFromDB() on a.IdKhachHang equals b.IdKhachHang
                     join c in hoaDonChiTietService.GetHoaDonChiTietFromDB() on a.IdHoaDon equals c.IdHoaDon
                     join d in chiTietSanPhamService.GetChiTietSpFromDB() on c.IdChiTietSp equals d.IdChiTietSp
                     join f in SanPham.GetSanPhamFromDB() on d.IdSanPham equals f.IdSanPham
                     where a.MaHD.ToLower().Contains(tbt_timkiem.Text.ToLower())
                     select new { a, b, c, d, f });
            foreach (var i in x)
            {
                dtg_show1.Rows.Add(i.a.MaHD,
                    i.f.TenSP,
                    i.c.SoLuong,
                    i.c.GiaBan,
                    i.c.SoLuong * i.c.GiaBan,
                    i.b.SDT == "0" ? " khach vang lai" : i.b.SDT
                    );
            }
        }

        private void MnSNhanVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormThongKeNV());
        }

        private void button_rset_Click(object sender, EventArgs e)
        {
            cbb_nam.Text = "";
            cbb_thang.Text = "";
            tbt_timkiem.Text = "";
        }
    }
}
