using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.DAL.Models;
using _1.DAL.IRepositories;

namespace _1.DAL.Repositories
{
    public class NhanVienRepository : INhanVienRepository
    {
        private QLBHContext _qLBHContext;
        private List<NhanVien> _NhanVienList;

        public NhanVienRepository()
        {
            _qLBHContext = new QLBHContext();
            _NhanVienList = new List<NhanVien>();
        }

        public bool Add(NhanVien nv)
        {
            _qLBHContext.NhanViens.Add(nv);
            _qLBHContext.SaveChanges();
            return true;
        }

        public bool Delete(NhanVien nv)
        {
            _qLBHContext.NhanViens.Remove(nv);
            _qLBHContext.SaveChanges();
            return true;
        }

        public List<NhanVien> GetAllNv()
        {
            _NhanVienList = _qLBHContext.NhanViens.ToList();
            return _NhanVienList;
        }

        public NhanVien GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Update(NhanVien nv)
        {
            _qLBHContext.NhanViens.Update(nv);
            _qLBHContext.SaveChanges();
            return true;
        }
    }
}
