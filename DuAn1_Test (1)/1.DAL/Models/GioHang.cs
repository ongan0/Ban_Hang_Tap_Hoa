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
    [Table("GioHang")]
    public class GioHang
    {
        [Key]
        public Guid IdGioHang { get; set; }

        public Guid IdKhachHang { get; set; }
        public Guid IdNhanVien { get; set; }

        [Column("NgayTao", TypeName = "datetime")]
        public DateTime NgayTao { get; set; }

        [Column("NgayThanhToan", TypeName = "datetime")]
        public DateTime NgayThanhToan { get; set; }

        [ForeignKey("IdKhachHang")]
        public virtual KhachHang KhachHang { get; set; }

        public virtual ObservableCollectionListSource<GioHangChiTiet> GioHangChiTiets { get; } = new();
    }
}
