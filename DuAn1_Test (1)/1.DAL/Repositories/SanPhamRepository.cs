using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.DAL.Models;
using _1.DAL.IRepositories;

namespace _1.DAL.Repositories
{
    public class SanPhamRepository : ISanPhamRepository
    {
        private QLBHContext _qLBHContext;
        private List<SanPham> _sanPhamList;

        public SanPhamRepository()
        {
            _qLBHContext = new QLBHContext();
            _sanPhamList = new List<SanPham>();
        }
        public bool Add(SanPham sp)
        {
            _qLBHContext.SanPhams.Add(sp);
            _qLBHContext.SaveChanges();
            return true;
        }

        public bool Delete(SanPham sp)
        {
            _qLBHContext.SanPhams.Remove(sp);
            _qLBHContext.SaveChanges();
            return true;
        }

        public List<SanPham> GetAllSp()
        {
            _sanPhamList = _qLBHContext.SanPhams.ToList();
            return _sanPhamList;
        }

        public SanPham GetByTen(string ma)
        {
            throw new NotImplementedException();
        }

        public bool Update(SanPham sp)
        {
            _qLBHContext.SanPhams.Update(sp);
            _qLBHContext.SaveChanges();
            return true;
        }
    }
}
