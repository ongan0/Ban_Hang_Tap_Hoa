using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.DAL.Models;
using _1.DAL.IRepositories;

namespace _1.DAL.Repositories
{
    public class HoaDonChiTietRepository : IHoaDonChiTietRepository
    {
        private QLBHContext _qLBHContext;
        private List<HoaDonChiTiet> _hoaDonChiTiets;

        public HoaDonChiTietRepository()
        {
            _qLBHContext = new QLBHContext();
            _hoaDonChiTiets = new List<HoaDonChiTiet>();
        }
        public bool Add(HoaDonChiTiet HoaDonCT)
        {
            _qLBHContext.HoaDonChiTiets.Add(HoaDonCT);
            _qLBHContext.SaveChanges();
            return true;
        }

        public bool Delete(HoaDonChiTiet HoaDonCT)
        {
            _qLBHContext.HoaDonChiTiets.Remove(HoaDonCT);
            _qLBHContext.SaveChanges();
            return true;
        }

        public List<HoaDonChiTiet> GetAllHDCT()
        {
            _hoaDonChiTiets = _qLBHContext.HoaDonChiTiets.ToList(); 
            return _hoaDonChiTiets;
        }

        public bool Update(HoaDonChiTiet HoaDonCT)
        {
            _qLBHContext.HoaDonChiTiets.Update(HoaDonCT);
            _qLBHContext.SaveChanges();
            return true;
        }
    }
}
