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
    public partial class FormThongKeNV : Form
    {
        private iViewThongKeNV4 _idtnvser;
        private IHoaDonService hoaDonService;
        public FormThongKeNV()
        {
            InitializeComponent();
            _idtnvser = new ServiecViewThongKeNV();
            hoaDonService = new HoaDonService();
            loadData();
            loadngay();
            loadthang();
            loadnam();
        }
        public string[] Getnam()
        {
            string[] TempNs = new string[2030 - 2010];
            for (int i = 0; i < TempNs.Length; i++)
            {
                TempNs[i] = Convert.ToString(2010 + i);
            }
            return TempNs;
        }
        public string[] Getngay()
        {
            string[] TempNs = new string[32 - 1];
            for (int i = 0; i < TempNs.Length; i++)
            {
                TempNs[i] = Convert.ToString(1 + i);
            }
            return TempNs;
        }
        void loadngay()
        {
            foreach (var x in Getngay())
            {
                cbb_ngay.Items.Add(x);
            }

        }
        void loadnam()
        {
            foreach (var x in Getnam())
            {
                cbb_nam.Items.Add(x);
            }

        }
        void loadthang()
        {

            string[] lstmon = new string[12];
            lstmon[0] = "1";
            lstmon[1] = "2";
            lstmon[2] = "3";
            lstmon[3] = "4";
            lstmon[4] = "5";
            lstmon[5] = "6";
            lstmon[6] = "7";
            lstmon[7] = "8";
            lstmon[8] = "9";
            lstmon[9] = "10";
            lstmon[10] = "11";
            lstmon[11] = "12";

            foreach (var x in lstmon)
            {
                cbb_thang.Items.Add(x);
            }

        }
        public void loadData()
        {

            dtg_show.ColumnCount = 3;
            dtg_show.Columns[0].Name = "Mã Nhân Viên";
            dtg_show.Columns[1].Name = "Tên Nhân Viên";
            dtg_show.Columns[2].Name = "Tổng Doanh Thu";
            dtg_show.Rows.Clear();
            foreach (var x in _idtnvser.Getlistviewdoanhthu().OrderByDescending(c => c.TongSoTien))
            {
                dtg_show.Rows.Add(x.MaNhanVien, x.TenNhanVien, x.TongSoTien);
            }



        }
        void loaddoanhthuforlocall(string ngay, string thang, string nam)
        {
            dtg_show.ColumnCount = 3;
            dtg_show.Columns[0].Name = "Mã Nhân Viên";
            dtg_show.Columns[1].Name = "Tên Nhân Viên";
            dtg_show.Columns[2].Name = "Tổng Doanh Thu";
            dtg_show.Rows.Clear();
            foreach (var x in _idtnvser.Getlistviewdoanhthu().Where(c => c.NgayLap.Value.Day.ToString() == ngay && c.NgayLap.Value.Month.ToString() == thang && c.NgayLap.Value.Year.ToString() == nam).OrderByDescending(c => c.TongSoTien))
            {
                dtg_show.Rows.Add(x.MaNhanVien, x.TenNhanVien, x.TongSoTien);
            }
        }
        void loaddataforlocngay(string ngay)
        {
            dtg_show.ColumnCount = 3;
            dtg_show.Columns[0].Name = "Mã Nhân Viên";
            dtg_show.Columns[1].Name = "Tên Nhân Viên";
            dtg_show.Columns[2].Name = "Tổng Doanh Thu";
            dtg_show.Rows.Clear();
            foreach (var x in _idtnvser.Getlistviewdoanhthu().Where(c => c.NgayLap.Value.Day.ToString() == ngay).OrderByDescending(c => c.TongSoTien))
            {
                dtg_show.Rows.Add(x.MaNhanVien, x.TenNhanVien, x.TongSoTien);
            }
        }
        //tháng
        void loaddataforlocthang(string thang)
        {
            dtg_show.ColumnCount = 3;
            dtg_show.Columns[0].Name = "Mã Nhân Viên";
            dtg_show.Columns[1].Name = "Tên Nhân Viên";
            dtg_show.Columns[2].Name = "Tổng Doanh Thu";
            dtg_show.Rows.Clear();
            foreach (var x in _idtnvser.Getlistviewdoanhthu().Where(c => c.NgayLap.Value.Month.ToString() == thang).OrderByDescending(c => c.TongSoTien))
            {
                dtg_show.Rows.Add(x.MaNhanVien, x.TenNhanVien, x.TongSoTien);
            }
        }
        //năm
        void loaddataforlocnam(string nam)
        {
            dtg_show.ColumnCount = 3;
            dtg_show.Columns[0].Name = "Mã Nhân Viên";
            dtg_show.Columns[1].Name = "Tên Nhân Viên";
            dtg_show.Columns[2].Name = "Tổng Doanh Thu";
            dtg_show.Rows.Clear();
            foreach (var x in _idtnvser.Getlistviewdoanhthu().Where(c => c.NgayLap.Value.Year.ToString() == nam).OrderByDescending(c => c.TongSoTien))
            {
                dtg_show.Rows.Add(x.MaNhanVien, x.TenNhanVien, x.TongSoTien);
            }
        }
        private void ptp_excel_Click(object sender, EventArgs e)
        {

        }

        private void cbb_ngay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_thang.Text == "" && cbb_nam.Text == "")
            {
                loaddataforlocngay(cbb_ngay.Text);
                return;
            }
            else
            {
                loaddoanhthuforlocall(cbb_ngay.Text, cbb_thang.Text, cbb_nam.Text);
                return;
            }
        }

        private void cbb_thang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_ngay.Text == "" && cbb_nam.Text == "")
            {
                loaddataforlocthang(cbb_thang.Text);
                return;
            }
            else
            {
                loaddoanhthuforlocall(cbb_ngay.Text, cbb_thang.Text, cbb_nam.Text);
            }
        }

        private void cbb_nam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_thang.Text == "" && cbb_ngay.Text == "")
            {
                loaddataforlocnam(cbb_nam.Text);
                return;
            }
            else
            {
                loaddoanhthuforlocall(cbb_ngay.Text, cbb_thang.Text, cbb_nam.Text);
                return;
            }
        }

        private void FormThongKeNV_Load(object sender, EventArgs e)
        {

        }

        private void button_rset_Click(object sender, EventArgs e)
        {
            cbb_ngay.Text = "";
            cbb_nam.Text = "";
            cbb_thang.Text = "";
        }
    }
}
