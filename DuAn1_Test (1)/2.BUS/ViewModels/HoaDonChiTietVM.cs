using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.ViewModels
{
    public class HoaDonChiTietVM
    {
        //public Guid IdHoaDon { get; set; }

        public Guid IdChiTietSp { get; set; }
        public string MaHD { get; set; }

        public string MaQR { get; set; }
        public string TenSP { get; set; }
        public string MaSp { get; set; }
        public int SoLuong { get; set; }
        public double GiaBan { get; set; }
    }
}
