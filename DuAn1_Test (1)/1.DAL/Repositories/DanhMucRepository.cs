using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.DAL.Models;
using _1.DAL.IRepositories;

namespace _1.DAL.Repositories
{
    public class DanhMucRepository : IDanhMucRepository
    {
        private QLBHContext _qLBHContext;
        private List<DanhMuc> _danhMucList;

        public DanhMucRepository()
        {
            _qLBHContext = new QLBHContext();
            _danhMucList = new List<DanhMuc>();
        }

        public bool Add(DanhMuc danhMuc)
        {
            _qLBHContext.DanhMucs.Add(danhMuc);
            _qLBHContext.SaveChanges();
            return true;
        }

        public bool Delete(DanhMuc danhMuc)
        {
            _qLBHContext.DanhMucs.Remove(danhMuc);
            _qLBHContext.SaveChanges();
            return true;
        }

        public List<DanhMuc> GetAllDm()
        {
            _danhMucList = _qLBHContext.DanhMucs.ToList();
            return _danhMucList;
        }

        public DanhMuc GetByMa(string ma)
        {
            throw new NotImplementedException();
        }

        public bool Update(DanhMuc danhMuc)
        {
            _qLBHContext.DanhMucs.Update(danhMuc);
            _qLBHContext.SaveChanges();
            return true;
        }
    }
}
