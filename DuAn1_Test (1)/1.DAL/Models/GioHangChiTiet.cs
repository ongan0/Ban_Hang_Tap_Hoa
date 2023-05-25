using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.Models
{
    [Table("GioHangChiTiet")]
    public class GioHangChiTiet
    {
        public Guid IdGioHang { get; set; }

        public Guid IdChiTietSp { get; set; }


        public int SoLuong { get; set; }
        public double DonGia { get; set; }

        [ForeignKey("IdChiTietSp")]
        public virtual ChiTietSanPham ChiTietSanPham { get; set; }

        [ForeignKey("IdGioHang")]
        public virtual GioHang GioHang { get; set; }
    }
}
