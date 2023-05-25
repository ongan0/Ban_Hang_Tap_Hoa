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
    public class HoaDonService : IHoaDonService
    {
        private QLBHContext _context;
        private IHoaDonRepository _hoaDonRepository;
        private INhanVienRepository _nhanVienRepository;
        private IKhachHangRepository _khachHangRepository;
        private List<HoaDon> _hoaDonList;
        public HoaDonService()
        {
            _hoaDonRepository = new HoaDonRepository();
            _hoaDonList = new List<HoaDon>();
            _context = new QLBHContext();
            _nhanVienRepository = new NhanVienRepository(); 
            _khachHangRepository = new KhachHangRepository();
        }
        public bool AddHoaDon(HoaDon hoaDon)
        {
            _hoaDonRepository.Add(hoaDon);
            return true;
        }

        public bool DeleteHoaDon(HoaDon hoaDon)
        {
            _hoaDonRepository.Delete(hoaDon);
            return true;
        }

        public List<HoaDon> GetHoaDonFromDB()
        {
            _hoaDonList = _hoaDonRepository.GetAllHD();
            return _hoaDonList;
        }

        public List<HoaDonVM> ShowHoaDon()
        {
            var data = (from o in _context.HoaDons
                        join c in _context.KhachHangs on o.IdKhachHang equals c.IdKhachHang
                        join e in _context.NhanViens on o.IdNhanVien equals e.IdNhanVien
                        select new HoaDonVM
                        {
                            IdHoaDon = o.IdHoaDon,
                            MaHD = o.MaHD,
                            NgayTao = o.NgayTao,
                            GmailNv = e.Gmail,
                            SDTKhacHang = c.SDT, 
                            GiaBan = o.TongTien, 
                            TrangThai = o.TrangThai,
                            NgayThanhToan = o.NgayThanhToan
                        }).ToList();
            return data;
        }

        public bool UpdateHoaDon(HoaDon hoaDon)
        {
            _hoaDonRepository.Update(hoaDon);
            return true;
        }
    }
}
