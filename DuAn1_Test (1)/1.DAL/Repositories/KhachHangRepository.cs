using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.DAL.Models;
using _1.DAL.IRepositories;

namespace _1.DAL.Repositories
{
    public class KhachHangRepository : IKhachHangRepository
    {
        private QLBHContext _qLBHContext;
        private List<KhachHang> _khachHangList;

        public KhachHangRepository()
        {
            _qLBHContext = new QLBHContext();
            _khachHangList = new List<KhachHang>();
        }
        public bool Add(KhachHang kh)
        {
            _qLBHContext.KhachHangs.Add(kh);
            _qLBHContext.SaveChanges();
            return true;
        }

        public bool Delete(KhachHang kh)
        {
            _qLBHContext.KhachHangs.Remove(kh);
            _qLBHContext.SaveChanges();
            return true;
        }

        public List<KhachHang> GetAllKh()
        {
            _khachHangList = _qLBHContext.KhachHangs.ToList();
            return _khachHangList;
        }

        public KhachHang GetByMa(string ma)
        {
            throw new NotImplementedException();
        }

        public bool Update(KhachHang kh)
        {
            _qLBHContext.KhachHangs.Update(kh);
            _qLBHContext.SaveChanges();
            return true;
        }
    }
}
