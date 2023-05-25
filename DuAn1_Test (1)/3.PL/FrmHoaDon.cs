using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;
using System.Data.OleDb;
using System.Windows.Forms;
using _1.DAL.Models;
using _2.BUS.IServices;
using _2.BUS.Services;
using _2.BUS.ViewModels;
using System.Diagnostics;
using Microsoft.Office.Interop.Excel;
using app = Microsoft.Office.Interop.Excel.Application;
using OfficeOpenXml;

namespace _3.PL
{
    public partial class FrmHoaDon : Form
    {

        public HoaDonChiTietService _hoaDonChiTietService;
        public HoaDonService _hoaDonService;
        public ChiTietSanPhamService _chiTietSanPhamService;
        public Guid temp;
        public FrmHoaDon()
        {
            _chiTietSanPhamService = new ChiTietSanPhamService();
            _hoaDonService = new HoaDonService();
            _hoaDonChiTietService = new HoaDonChiTietService();
            InitializeComponent();
            LoadHoaDon();
            
        }
        public void LoadHoaDon()
        {
            dtg_hoadon.Rows.Clear();
            dtg_hoadonchitiet.Rows.Clear();
            foreach(var item in _hoaDonService.ShowHoaDon())
            {
                dtg_hoadon.Rows.Add(item.IdHoaDon,item.MaHD, item.NgayTao, item.NgayThanhToan, item.GmailNv, item.SDTKhacHang == "0" ? "Khách vãng lai" : item.SDTKhacHang,
                    item.GiaBan, item.TrangThai == 1 ? "Đã thanh toán" : "Chờ thanh toán");
            }
        }
        public void LoadHoaDonCT(Guid IdHd)
        {
            temp = IdHd;
            dtg_hoadonchitiet.Rows.Clear();
            foreach(var item in _hoaDonChiTietService.ShowHoaDonChiTiet(IdHd))
            {
                dtg_hoadonchitiet.Rows.Add(item.IdChiTietSp, item.MaSp, item.TenSP, item.SoLuong, item.GiaBan);
            }
        }

        private void dtg_hoadon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow r = dtg_hoadon.Rows[e.RowIndex];
                LoadHoaDonCT((Guid)r.Cells[0].Value);
            }
        }

        private void btn_timk_Click(object sender, EventArgs e)
        {
            dtg_hoadon.Rows.Clear();
            dtg_hoadonchitiet.Rows.Clear();
            if(tbt_timk.Text != "")
            {
                var item = _hoaDonService.ShowHoaDon().Where(x => x.MaHD.Contains(tbt_timk.Text));
                if (item.Any())
                {
                    foreach(var a in item)
                    {
                        dtg_hoadon.Rows.Add(a.IdHoaDon, a.MaHD, a.NgayTao, a.GmailNv, a.SDTKhacHang, a.GiaBan, a.TrangThai == 1 ? "Đã thanh toán" : "Chờ thanh toán");
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã hóa đơn tương ứng");
                    LoadHoaDon();
                }
            }
            else
            {
                MessageBox.Show("Không được để trống");
                LoadHoaDon();
            }
        }

        private void btn_XoaHD_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn xoa hoa don không?", "Thanh toán", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                HoaDon o = _hoaDonService.GetHoaDonFromDB().FirstOrDefault(x => x.IdHoaDon == temp);
                if (o.TrangThai == 1)
                {
                    MessageBox.Show("Chỉ được xóa các hóa đơn chưa thanh toán");
                }
                else
                {
                    var _listHDCT = _hoaDonChiTietService.GetHoaDonChiTietFromDB().Where(x => x.IdHoaDon == temp);
                    foreach (var item in _listHDCT)
                    {
                        var p = _chiTietSanPhamService.GetChiTietSpFromDB().FirstOrDefault(x => x.IdChiTietSp == item.IdChiTietSp);
                        p.SoLuongTon += item.SoLuong;
                        _chiTietSanPhamService.UpdateChiTietSp(p);
                        _hoaDonChiTietService.DeleteHoaDonChiTiet(item);
                    }
                    _hoaDonService.DeleteHoaDon(o);
                    //temp = null;
                    MessageBox.Show("Xóa thành công");
                    LoadHoaDon();
                    dtg_hoadonchitiet.Rows.Clear();
                }
            }
            else
            {
                LoadHoaDon();
                dtg_hoadonchitiet.Rows.Clear();
            }
        }

       private void export2Execl(DataGridView g, string duongDan, string tenTap)
       {
            app obj = new app();
            obj.Application.Workbooks.Add(Type.Missing);
            obj.Columns.ColumnWidth = 25;
            for(int i = 0; i < g.Columns.Count +1; i++)
            {
                obj.Cells[1, i] = g.Columns[i - 1].HeaderText;
            }
            for(int i = 0; i < g.Rows.Count; i++)
            {
                for( int j = 0; j < g.Columns.Count; j++)
                {
                    if(g.Rows[i].Cells[j].Value != null)
                    {
                        obj.Cells[i + 2, j+1]  = g.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }
            obj.ActiveWorkbook.SaveCopyAs(duongDan + tenTap + ".xlsx");
            obj.ActiveWorkbook.Saved = true;
        }

        private void senderexcel(string path)
        {
            using (ExcelPackage p = new ExcelPackage())
            {
                // đặt tên người tạo file
                p.Workbook.Properties.Author = "";

                // đặt tiêu đề cho file
                p.Workbook.Properties.Title = "Báo cáo thống kê";

                //Tạo một sheet để làm việc trên đó
                p.Workbook.Worksheets.Add("sheet");

                // lấy sheet vừa add ra để thao tác
                ExcelWorksheet ws = p.Workbook.Worksheets[1];

                // đặt tên cho sheet
                ws.Name = "sheet";
                // fontsize mặc định cho cả sheet
                ws.Cells.Style.Font.Size = 11;
                // font family mặc định cho cả sheet
                ws.Cells.Style.Font.Name = "Calibri";

                for (int i = 0; i < dtg_hoadon.Columns.Count; i++)
                {
                    ws.Cells[1, i + 1].Value = dtg_hoadon.Columns[i].HeaderText;
                }
                for (int i = 0; i < dtg_hoadon.Rows.Count; i++)
                {
                    for (int j = 0; j < dtg_hoadon.Columns.Count; j++)
                    {
                        ws.Cells[i + 2, j + 1].Value = dtg_hoadon.Rows[i].Cells[j].Value;
                    }
                }
                //Lưu file lại
                Byte[] bin = p.GetAsByteArray();
                File.WriteAllBytes(path, bin);
            };
        }
        private void btn_XuatExcel_Click(object sender, EventArgs e)
        {
            //export2Execl(dtg_hoadon, @"C:\Users\ADMIN\OneDrive\Máy tính\DuAn1_Test (1)\", "abc");
            string filePath = "";
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Export Excel";
            saveFileDialog.Filter = "Excel | *.xlsx | Excel 2003 | *.xls";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = saveFileDialog.FileName;
                try
                {
                    senderexcel(filePath);
                    MessageBox.Show("Xuất File Excel Thành công");
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Xuất File Excel không  Thành công" + ex.Message);
                }
            }

        }

        private void dtp_NgayKT_ValueChanged(object sender, EventArgs e)
        {
            var data = _hoaDonService.ShowHoaDon().Where(p => p.NgayTao >= dtp_NgayBD.Value 
                                                              && p.NgayThanhToan <= dtp_NgayKT.Value);
            dtg_hoadon.Rows.Clear();
            foreach (var item in data)
            {
                dtg_hoadon.Rows.Add(item.IdHoaDon, item.MaHD, item.NgayTao, item.NgayThanhToan, item.GmailNv, item.SDTKhacHang == "0" ? "Khách vãng lai" : item.SDTKhacHang,
                    item.GiaBan, item.TrangThai == 1 ? "Đã thanh toán" : "Chờ thanh toán");
            }
        }

        private void button_rset_Click(object sender, EventArgs e)
        {
            dtp_NgayBD.Value = DateTime.Now;
            dtp_NgayKT.Value = DateTime.Now;
            LoadHoaDon();
        }
    }
}
