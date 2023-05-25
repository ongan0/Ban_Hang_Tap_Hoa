using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.DAL.Models;
using _1.DAL.IRepositories;

namespace _1.DAL.Repositories
{
    public class GioHangChiTietRepository : IGioHangChiTietRepository
    {
        private QLBHContext _qLBHContext;
        private List<GioHangChiTiet> _gioHangChiTiets;

        public GioHangChiTietRepository()
        {
            _qLBHContext = new QLBHContext();
            _gioHangChiTiets = new List<GioHangChiTiet>();
        }

        public bool Add(GioHangChiTiet ghct)
        {
            _qLBHContext.GioHangChiTiets.Add(ghct);
            _qLBHContext.SaveChanges();
            return true;
        }

        public bool Delete(GioHangChiTiet ghct)
        {
            _qLBHContext.GioHangChiTiets.Remove(ghct);
            _qLBHContext.SaveChanges();
            return true;
        }

        public List<GioHangChiTiet> GetAllGhct()
        {
            _gioHangChiTiets = _qLBHContext.GioHangChiTiets.ToList();
            return _gioHangChiTiets;
        }

        public bool Update(GioHangChiTiet ghct)
        {
            _qLBHContext.GioHangChiTiets.Update(ghct);
            _qLBHContext.SaveChanges();
            return true;
        }
    }
}
