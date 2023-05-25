using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.DAL.Models;
using _1.DAL.IRepositories;

namespace _1.DAL.Repositories
{
    public class ChiTietSanPhamRepository : IChiTietSanPhamRepository
    {
        private QLBHContext _qLBHContext;
        private List<ChiTietSanPham> _chiTietSanPhamList;

        public ChiTietSanPhamRepository()
        {
            _qLBHContext = new QLBHContext();
            _chiTietSanPhamList = new List<ChiTietSanPham>();
        }

        public bool Add(ChiTietSanPham chiTietSanPham)
        {
            _qLBHContext.ChiTietSanPhams.Add(chiTietSanPham);
            _qLBHContext.SaveChanges(); 
            return true;
        }

        public bool Delete(ChiTietSanPham chiTietSanPham)
        {
            _qLBHContext.ChiTietSanPhams.Remove(chiTietSanPham);
            _qLBHContext.SaveChanges();
            return true;
        }

        public List<ChiTietSanPham> GetAllChiTietSp()
        {
            _chiTietSanPhamList = _qLBHContext.ChiTietSanPhams.ToList();
            return _chiTietSanPhamList;
        }

        public ChiTietSanPham GetByMa(string ma)
        {
            throw new NotImplementedException();
        }

        public bool Update(ChiTietSanPham chiTietSanPham)
        {
            _qLBHContext.ChiTietSanPhams.Update(chiTietSanPham);
            _qLBHContext.SaveChanges();
            return true;
        }
    }
}
