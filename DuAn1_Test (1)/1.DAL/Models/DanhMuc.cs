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
    [Table("DanhMuc")]
    public class DanhMuc
    {
        [Key]
        public Guid IdDanhMuc { get; set; }

        [Column("MaDanhMuc", TypeName = "varchar")]
        [StringLength(30)]
        public string MaDanhMuc { get; set; }

        [Column("TenDanhMuc", TypeName = "nvarchar")]
        [StringLength(50)]
        public string TenDanhMuc { get; set; }

        public virtual ObservableCollectionListSource<ChiTietSanPham> ChiTietSanPhams { get; } = new();

    }
}
