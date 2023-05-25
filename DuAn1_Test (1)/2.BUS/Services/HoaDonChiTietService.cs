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
using _1.DAL;

namespace _2.BUS.Services
{
    public class HoaDonChiTietService : IHoaDonChiTietService
    {
        private IHoaDonChiTietRepository _hoaDonChiTietRepository;
        private IHoaDonRepository _hoaDonRepository;
        private IChiTietSanPhamRepository _chiTietSanPhamRepository;
        private ISanPhamRepository _sanPhamRepository;
        private QLBHContext _context;
        private List<HoaDonChiTiet> _hoaDonChiTietList;
        public HoaDonChiTietService()
        {
            _sanPhamRepository = new SanPhamRepository();
            _hoaDonChiTietRepository = new HoaDonChiTietRepository();
            _hoaDonRepository = new HoaDonRepository(); 
            _chiTietSanPhamRepository = new ChiTietSanPhamRepository();
            _hoaDonChiTietList = new List<HoaDonChiTiet>();
            _context = new QLBHContext();
        }
        public bool AddHoaDonChiTiet(HoaDonChiTiet hoaDonChiTiet)
        {
            _hoaDonChiTietRepository.Add(hoaDonChiTiet);
            return true;
        }

        

        public bool DeleteHoaDonChiTiet(HoaDonChiTiet hoaDonChiTiet)
        {
            _hoaDonChiTietRepository.Delete(hoaDonChiTiet);
            return true;
        }

        public List<HoaDonChiTiet> GetHoaDonChiTietFromDB()
        {
            _hoaDonChiTietList = _hoaDonChiTietRepository.GetAllHDCT();
            return _hoaDonChiTietList;
        }



        public List<HoaDonChiTietVM> ShowHoaDonChiTiet(Guid IdHD)
        {
            var data = (from od in _context.HoaDonChiTiets
                        join o in _context.HoaDons on od.IdHoaDon equals o.IdHoaDon
                        join ct in _context.ChiTietSanPhams on od.IdChiTietSp equals ct.IdChiTietSp
                        where od.HoaDon.IdHoaDon == IdHD
                        select new HoaDonChiTietVM
                        {
                            IdChiTietSp = od.IdChiTietSp,
                            MaSp = ct.SanPham.MaSP,
                            TenSP = ct.SanPham.TenSP,
                            MaQR = ct.MaQRCode,
                            GiaBan = od.GiaBan,
                            SoLuong = od.SoLuong,

                        }).ToList();
            return data;
        }

        public bool UppdateHoaDonChiTiet(HoaDonChiTiet hoaDonChiTiet)
        {
            _hoaDonChiTietRepository.Update(hoaDonChiTiet);
            return true;
        }
    }
}
