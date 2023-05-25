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
    [Table("NhanVien")]
    public class NhanVien
    {
        [Key]
        public Guid IdNhanVien { get; set; }

        [Column("MaNhanVien", TypeName = "varchar")]
        [StringLength(30)]
        public string MaNhanVien { get; set; }

        [Column("TenDangNhap", TypeName = "nvarchar")]
        [StringLength(100)]
        public string TenDangNhap { get; set; }

        [Column("MatKhau", TypeName = "nvarchar")]
        [StringLength(50)]
        public string MatKhau { get; set; }

        [Column("TenNhanVien", TypeName = "nvarchar")]
        [StringLength(100)]
        public string TenNhanVien { get; set; }

        public int GioiTinh { get; set; }

        [Column("NgaySinh", TypeName = "datetime")]
        public DateTime NgaySinh { get; set; }


        public string DiaChi { get; set; }


        [Column("SDT", TypeName = "varchar")]
        [StringLength(20)]
        public string SDT { get; set; }

        [Column("Gmail", TypeName = "varchar")]
        [StringLength(100)]
        public string Gmail { get; set; }

        public string LinkAnh { get; set; }

        public bool TrangThai { get; set; }

        public int IdChucVu { get; set; }

        [ForeignKey("IdChucVu")]
        public virtual ChucVu ChucVu { get; set; }

        public virtual ObservableCollectionListSource<HoaDon> HoaDons { get; } = new();
    }
}
