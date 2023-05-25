using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.ViewModels
{
    public class NhanVienVM
    {
        public Guid IdNhanVien { get; set; }

        public string MaNhanVien { get; set; }
        public string TenCv { get; set; }

     
        public string MatKhau { get; set; }

       
        public string TenNhanVien { get; set; }

        public int GioiTinh { get; set; }


        public DateTime NgaySinh { get; set; }

        public string LinkAnh { get; set; }
        public string DiaChi { get; set; }



        public string SDT { get; set; }

        public string Gmail { get; set; }

        public bool TrangThai { get; set; }

        public int IdChucVu { get; set; }
    }
}
