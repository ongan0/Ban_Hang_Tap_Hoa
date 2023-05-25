using _1.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace _1.DAL
{
    public class QLBHContext : DbContext
    {
        public DbSet<ChiTietSanPham> ChiTietSanPhams { get; set; }

        public DbSet<ChucVu> ChucVus { get; set; }

        public DbSet<DanhMuc> DanhMucs { get; set; }

        public DbSet<GioHang> GioHangs { get; set; }

        public DbSet<GioHangChiTiet> GioHangChiTiets { get; set; }

        public DbSet<HoaDon> HoaDons { get; set; }

        public DbSet<HoaDonChiTiet> HoaDonChiTiets { get; set; }

        public DbSet<KhachHang> KhachHangs { get; set; }


        public DbSet<NhanVien> NhanViens { get; set; }

        public DbSet<NhaPhanPhoi> NhaPhanPhois { get; set; }

        public DbSet<SanPham> SanPhams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseSqlServer(@"Data Source = QUANGBM\SQLEXPRESS;Initial Catalog = DuAn1_testMaster;User Id = Quang;Password = 123456;Connect Timeout=3"));
        }
    
        
       //=> optionsBuilder.UseSqlServer(@"Data Source = DESKTOP-KSKIQPN\SQLEXPRESS;Initial Catalog = QLBH;User Id = lekientl;Password = 12345;Connect Timeout=3");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GioHangChiTiet>()
             .HasKey(p => new { p.IdGioHang, p.IdChiTietSp });

            modelBuilder.Entity<HoaDonChiTiet>()
           .HasKey(p => new { p.IdHoaDon, p.IdChiTietSp });
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
