using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.ViewModels
{
    public class HoaDonVM
    {
        public Guid IdHoaDon { get; set; }

        public Guid IdNhanVien { get; set; }
        public Guid IdKhachHang { get; set; }
        public string GmailNv { get; set; }

        public string SDTKhacHang { get; set; }

        public double GiaBan { get; set; }
       // public double TongTien { get; set; }
        public string MaHD { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayThanhToan { get; set; }
        public int TrangThai { get; set; }
    }
}
