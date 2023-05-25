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
    [Table("ChucVu")]
    public class ChucVu
    {
        [Key]
        public int IdChucVu { get; set; }

        [Column("MaCV", TypeName = "varchar")]
        [StringLength(30)]
        public string MaCV { get; set; }

        [Column("TenCV", TypeName = "nvarchar")]
        [StringLength(50)]
        public string TenCV { get; set; }

        public virtual ObservableCollectionListSource<NhanVien> NhanViens { get; } = new();
    }
}
