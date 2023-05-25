using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.ViewModels
{
    public class ViewThongKeNV
    {
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public double? TongSoTien { get; set; }
        public string Months { get; set; }
        public string Years { get; set; }
        public DateTime? NgayLap { get; set; }
        public ViewThongKeNV(string manv, string tennv, double? tongtien, string Month, string Year, DateTime? ngaylap)
        {
            MaNhanVien = manv;
            TenNhanVien = tennv;
            TongSoTien = tongtien;
            Months = Month;
            Years = Year;
            NgayLap = ngaylap;
        }
    }
}
