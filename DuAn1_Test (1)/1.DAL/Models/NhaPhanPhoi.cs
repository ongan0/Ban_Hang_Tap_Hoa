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
    [Table("NhaPhanPhoi")]
    public class NhaPhanPhoi
    {
        [Key]
        public Guid IdNhaPhanPhoi { get; set; }

        [Column("MaNhaPhanPhoi", TypeName = "varchar")]
        [StringLength(30)]
        public string MaNhaPhanPhoi { get; set; }

        [Column("TenNhaPhanPhoi", TypeName = "nvarchar")]
        [StringLength(50)]
        public string TenNhaPhanPhoi { get; set; }

        public virtual ObservableCollectionListSource<ChiTietSanPham> ChiTietSanPhams { get; } = new();
    }
}
