using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.Models
{
    [Table("HoaDonChiTiet")]
    public class HoaDonChiTiet
    {
        public Guid IdHoaDon { get; set; }

        public Guid IdChiTietSp { get; set; }

        [Column("TenSP", TypeName = "nvarchar")]
        [StringLength(50)]
        public string TenSP { get; set; }

        public int SoLuong { get; set; }
        public double GiaBan { get; set; }

        [ForeignKey("IdHoaDon")]
        public virtual HoaDon HoaDon { get; set; }


        [ForeignKey("IdChiTietSp")]
        public virtual ChiTietSanPham ChiTietSanPham { get; set; }
    }
}
