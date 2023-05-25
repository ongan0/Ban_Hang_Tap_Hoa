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
    public class NhanVienService : INhanVienService
    {
        private INhanVienRepository _nhanVienRepository;
        private IChucVuRepository _chucVuRepository;
        private List<NhanVien> _nhanVienList;
        public NhanVienService()
        {
            _chucVuRepository = new ChucVuRepository();
            _nhanVienList = new List<NhanVien>();
            _nhanVienRepository = new NhanVienRepository();
        }
        public bool AddNhanVien(NhanVien nhanVien)
        {
            _nhanVienRepository.Add(nhanVien);
            return true;
        }

        public bool DeleteNhanVien(NhanVien nhanVien)
        {
            _nhanVienRepository.Delete(nhanVien);
            return true;
        }

        public List<NhanVien> GetNhanVienFromDB()
        {
            _nhanVienList = _nhanVienRepository.GetAllNv();
            return _nhanVienList;

        }

        public List<NhanVienVM> ShowNhanVien()
        {
            var data = (from n in _nhanVienRepository.GetAllNv()
                        join c in _chucVuRepository.GetAllCv() on n.IdChucVu equals c.IdChucVu
                        select new NhanVienVM
                        {
                            IdNhanVien = n.IdNhanVien,
                            IdChucVu = c.IdChucVu,
                            MaNhanVien = n.MaNhanVien,
                            TenNhanVien = n.TenNhanVien,
                            NgaySinh = n.NgaySinh,
                            DiaChi = n.DiaChi,
                            SDT = n.SDT,
                            LinkAnh = n.LinkAnh,
                            TenCv = c.TenCV,
                            Gmail = n.Gmail,
                            GioiTinh = n.GioiTinh,
                            TrangThai = n.TrangThai,
                        }
                        ).ToList();
            return data;
        }

 

        public bool UpdateNhanVien(NhanVien nhanVien)
        {
            _nhanVienRepository.Update(nhanVien);
            return true;
        }
    }
}
