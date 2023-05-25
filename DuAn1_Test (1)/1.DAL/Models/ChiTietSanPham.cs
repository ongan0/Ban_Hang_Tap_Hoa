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
    [Table("ChiTietSanPham")]
    public class ChiTietSanPham
    {
        [Key]
        public Guid IdChiTietSp { get; set; }

        public Guid IdNhaPhanPhoi { get; set; }
        public Guid IdSanPham { get; set; }
        public Guid IdDanhMuc { get; set; }

        [Column("NgaySX", TypeName = "datetime")]
        public DateTime NgaySX { get; set; }

        [Column("HanSD", TypeName = "datetime")]
        public DateTime HanSD { get; set; }
        public double GiaNhap { get; set; }
        public double GiaBan { get; set; }
        public  int SoLuongTon { get; set; }
        public string  Anh { get; set; }
        public int TrangThai { get; set; }
        public string MaQRCode { get; set; }
        

        [ForeignKey("IdDanhMuc")]
        public virtual DanhMuc DanhMuc { get; set; }

        [ForeignKey("IdSanPham")]
        public virtual SanPham SanPham { get; set; }

        [ForeignKey("IdNhaPhanPhoi")]
        public virtual NhaPhanPhoi NhaPhanPhoi { get; set; }

        public virtual ObservableCollectionListSource<GioHangChiTiet> GioHangChiTiets { get; } = new();

        public virtual ObservableCollectionListSource<HoaDonChiTiet> HoaDonChiTiets { get; } = new();

    }
}
