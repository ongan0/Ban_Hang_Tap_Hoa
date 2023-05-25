using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.DAL.Models;
using _1.DAL.IRepositories;

namespace _1.DAL.Repositories
{
    public class HoaDonRepository : IHoaDonRepository
    {
        private QLBHContext _qLBHContext;
        private List<HoaDon> _hoaDonList;   
        public HoaDonRepository()
        {
            _qLBHContext = new QLBHContext();
            _hoaDonList = new List<HoaDon>();
        }
        public bool Add(HoaDon hd)
        {
            _qLBHContext.HoaDons.Add(hd);
            _qLBHContext.SaveChanges();
            return true;
        }

        public bool Delete(HoaDon hd)
        {
            _qLBHContext.HoaDons.Remove(hd);
            _qLBHContext.SaveChanges();
            return true;
        }

        public List<HoaDon> GetAllHD()
        {
            _hoaDonList = _qLBHContext.HoaDons.ToList();
            return _hoaDonList;
        }

        public HoaDon GetByMa(string ma)
        {
            throw new NotImplementedException();
        }

        public bool Update(HoaDon hd)
        {
            _qLBHContext.HoaDons.Update(hd);
            _qLBHContext.SaveChanges();
            return true;
        }
    }
}
