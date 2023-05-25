using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.DAL.Models;
using _1.DAL.IRepositories;

namespace _1.DAL.Repositories
{
    public class GioHangRepository : IGioHangRepository
    {
        private QLBHContext _qLBHContext;
        private List<GioHang> _gioHangList;

        public GioHangRepository()
        {
            _qLBHContext = new QLBHContext();
            _gioHangList = new List<GioHang>();
        }

        public bool Add(GioHang gh)
        {
            _qLBHContext.GioHangs.Add(gh);
            _qLBHContext.SaveChanges();
            return true;
        }

        public bool Delete(GioHang gh)
        {
            _qLBHContext.GioHangs.Remove(gh);
            _qLBHContext.SaveChanges();
            return true;
        }

        public List<GioHang> GetAllGh()
        {
            _gioHangList = _qLBHContext.GioHangs.ToList();
            return _gioHangList;
        }

        public bool Update(GioHang gh)
        {
            _qLBHContext.GioHangs.Update(gh);
            _qLBHContext.SaveChanges();
            return true;
        }
    }
}
