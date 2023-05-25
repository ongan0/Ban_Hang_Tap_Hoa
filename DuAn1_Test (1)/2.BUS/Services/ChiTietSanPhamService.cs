using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.DAL.Models;
using _1.DAL.IRepositories;
using _1.DAL.Repositories;
using _2.BUS.IServices;
using _2.BUS.ViewModels;

namespace _2.BUS.Services
{
    public class ChiTietSanPhamService : IChiTietSanPhamService
    {
        private IChiTietSanPhamRepository _chiTietSanPhamRepository;
        private ISanPhamRepository _sanPhamRepository;
        private INhaPhanPhoiRepository _nhaPhanPhoiRepository;
        private IDanhMucRepository _danhMucRepository;
        private List<ChiTietSanPham> _chiTietSanPhamList;

        public ChiTietSanPhamService()
        {
            _chiTietSanPhamRepository = new ChiTietSanPhamRepository();
            _sanPhamRepository = new SanPhamRepository();
            _nhaPhanPhoiRepository = new NhaPhanPhoiRepository();
            _danhMucRepository = new DanhMucRepository();
            _chiTietSanPhamList = new List<ChiTietSanPham>();
        }
       
        public bool AddChiTietSp(ChiTietSanPham chiTietSanPham)
        {
            _chiTietSanPhamRepository.Add(chiTietSanPham);
            return true;
        }

        public bool Addctsp(SanPhamVM sanPhamVM)
        {
            ChiTietSanPham chiTietSp = new ChiTietSanPham()
            {
                IdChiTietSp = sanPhamVM.IdChiTietSp,
                IdNhaPhanPhoi = sanPhamVM.IdNhaPhanPhoi,
                IdDanhMuc = sanPhamVM.IdDanhMuc,
                IdSanPham = sanPhamVM.IdSanPham,
                GiaNhap = sanPhamVM.GiaNhap,
                GiaBan = sanPhamVM.GiaBan,
                SoLuongTon = sanPhamVM.SoLuongTon,
                NgaySX = sanPhamVM.NgaySX,
                HanSD = sanPhamVM.HanSD,
                MaQRCode = sanPhamVM.MaQRCode,
                Anh = sanPhamVM.LinkAnh,
                TrangThai = sanPhamVM.TrangThai
            };
            _chiTietSanPhamRepository.Add(chiTietSp);
            return true;
        }

        public bool DeleteChiTietSp(ChiTietSanPham chiTietSanPham)
        {
            _chiTietSanPhamRepository.Delete(chiTietSanPham);
            return true;
        }

        public List<ChiTietSanPham> GetChiTietSpFromDB()
        {
            _chiTietSanPhamList = _chiTietSanPhamRepository.GetAllChiTietSp();
            return _chiTietSanPhamList;
        }

        public List<SanPhamVM> ShowSanPham()
        {
            var data = (from a in _chiTietSanPhamRepository.GetAllChiTietSp()
                        join b in _nhaPhanPhoiRepository.GetAllNpp() on a.IdNhaPhanPhoi equals b.IdNhaPhanPhoi
                        join c in _danhMucRepository.GetAllDm() on a.IdDanhMuc equals c.IdDanhMuc
                        join d in _sanPhamRepository.GetAllSp() on a.IdSanPham equals d.IdSanPham
                        select new SanPhamVM
                        {
                            IdChiTietSp = a.IdChiTietSp,
                            MaQRCode = a.MaQRCode,
                            TenSP = d.TenSP,
                            Masp = d.MaSP,
                            TenDanhMuc = c.TenDanhMuc,
                            TenNhaPhanPhoi = b.TenNhaPhanPhoi,
                            GiaNhap = a.GiaNhap,
                            GiaBan = a.GiaBan,
                            SoLuongTon = a.SoLuongTon,
                            NgaySX = a.NgaySX,
                            HanSD = a.HanSD,
                            LinkAnh = a.Anh,
                            TrangThai = a.TrangThai
                        }).ToList();
            return data;
        }

        public bool UpdateChiTietSp(ChiTietSanPham chiTietSanPham)
        {
            _chiTietSanPhamRepository.Update(chiTietSanPham);
            return true;
        }

        public bool Updatectsp(SanPhamVM sanPhamVM)
        {
            ChiTietSanPham chiTietSp = new ChiTietSanPham()
            {
                IdChiTietSp = sanPhamVM.IdChiTietSp,
                IdNhaPhanPhoi = sanPhamVM.IdNhaPhanPhoi,
                IdDanhMuc = sanPhamVM.IdDanhMuc,
                IdSanPham = sanPhamVM.IdSanPham,
                GiaNhap = sanPhamVM.GiaNhap,
                GiaBan = sanPhamVM.GiaBan,
                SoLuongTon = sanPhamVM.SoLuongTon,
                NgaySX = sanPhamVM.NgaySX,
                HanSD = sanPhamVM.HanSD,
                MaQRCode = sanPhamVM.MaQRCode,
                Anh = sanPhamVM.LinkAnh,
                TrangThai = sanPhamVM.TrangThai
            };
            _chiTietSanPhamRepository.Update(chiTietSp);
            return true;
        }
    }
}
