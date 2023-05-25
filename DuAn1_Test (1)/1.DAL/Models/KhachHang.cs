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
    [Table("KhachHang")]
    public class KhachHang
    {
        [Key]
        public Guid IdKhachHang { get; set; }

        [Column("MaKH", TypeName = "varchar")]
        [StringLength(30)]
        public string MaKH { get; set; }

        [Column("TenKH", TypeName = "nvarchar")]
        [StringLength(50)]
        public string TenKH { get; set; }

        [Column("NgaySinh", TypeName = "datetime")]
        public DateTime? NgaySinh { get; set; }

        [Column("SDT", TypeName = "varchar")]
        [StringLength(20)]
        public string SDT { get; set; }

        public string? DiaChi { get; set; }

        public int? DiemTieuDung { get; set; }

        public virtual ObservableCollectionListSource<GioHang> GioHangs { get; } = new();
        public virtual ObservableCollectionListSource<HoaDon> HoaDons { get; } = new();
    }
}
