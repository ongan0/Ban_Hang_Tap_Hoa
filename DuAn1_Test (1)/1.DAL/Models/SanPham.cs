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
    [Table("SanPham")]
    public class SanPham
    {
        [Key]
        public Guid IdSanPham { get; set; }

        [Column("MaSP", TypeName = "varchar")]
        [StringLength(30)]
        public string MaSP { get; set; }

        [Column("TenSP", TypeName = "nvarchar")]
        [StringLength(50)]
        public string TenSP { get; set; }

        public virtual ObservableCollectionListSource<ChiTietSanPham> ChiTietSanPhams { get; } = new();
    }
}
