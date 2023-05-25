using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.ViewModels
{
    public class SanPhamVM
    {
        public Guid IdChiTietSp { get; set; }

        public Guid IdNhaPhanPhoi { get; set; }
        public Guid IdSanPham { get; set; }
        public Guid IdDanhMuc { get; set; }
        public DateTime NgaySX { get; set; }

        public DateTime HanSD { get; set; }
        public double GiaNhap { get; set; }
        public double GiaBan { get; set; }
        public string LinkAnh { get; set; }
        public int SoLuongTon { get; set; }
        public int  TrangThai { get; set; }
        public string MaQRCode { get; set; }
        public string TenSP { get; set; }
        public string Masp { get; set; }
        public string TenNhaPhanPhoi { get; set; }
        public string TenDanhMuc { get; set; }
    }
}
