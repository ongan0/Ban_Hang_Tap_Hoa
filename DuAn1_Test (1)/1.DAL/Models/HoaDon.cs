using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.Models
{
    [Table("HoaDon")]
    public  class HoaDon
    {
        [Key]
        public Guid IdHoaDon { get; set; }

        public Guid IdNhanVien { get; set; }
        public Guid IdKhachHang { get; set; }

        [Column("MaHD", TypeName = "varchar")]
        [StringLength(30)]
        public string MaHD { get; set; }

        [Column("NgayTao", TypeName = "datetime")]
        public DateTime NgayTao { get; set; }

        [Column("NgayThanhToan", TypeName = "datetime")]
        public DateTime NgayThanhToan { get; set; }
        public int TrangThai { get; set; }

        public double TongTien { get; set; }

        [ForeignKey("IdKhachHang")]
        public virtual KhachHang KhachHang { get; set; }


        public virtual NhanVien NhanVien { get; set; }

        public virtual ObservableCollectionListSource<HoaDonChiTiet> HoaDonChiTiets { get; } = new();
    }
}
