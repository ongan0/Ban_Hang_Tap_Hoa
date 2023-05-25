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
    public class SanPhamService : ISanPhamService
    {
        private ISanPhamRepository _sanPhamRepository;
        private List<SanPham> _sanPhamList;
        public SanPhamService()
        {
            _sanPhamList = new List<SanPham>();
            _sanPhamRepository = new SanPhamRepository();
        }
        public bool AddSanPham(SanPham sanPham)
        {
            _sanPhamRepository.Add(sanPham);
            return true;
        }

        public bool DeleteSanPham(SanPham sanPham)
        {
            _sanPhamRepository.Delete(sanPham);
            return true;
        }

        public List<SanPham> GetSanPhamFromDB()
        {
            _sanPhamList = _sanPhamRepository.GetAllSp();
            return _sanPhamList;    
        }

        public bool UpdateSanPham(SanPham sanPham)
        {
            _sanPhamRepository.Update(sanPham);
            return true;
        }
    }
}
