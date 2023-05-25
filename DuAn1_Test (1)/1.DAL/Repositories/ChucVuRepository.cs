using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.DAL.Models;
using _1.DAL.IRepositories;

namespace _1.DAL.Repositories
{
    public class ChucVuRepository : IChucVuRepository
    {
        private QLBHContext _qLBHContext;
        private List<ChucVu> _chucVuList;

        public ChucVuRepository()
        {
            _qLBHContext = new QLBHContext();
            _chucVuList = new List<ChucVu>();
        }

        public bool Add(ChucVu cv)
        {
            _qLBHContext.ChucVus.Add(cv);
            _qLBHContext.SaveChanges();
            return true;
        }

        public bool Delete(ChucVu cv)
        {
            _qLBHContext.ChucVus.Remove(cv);
            _qLBHContext.SaveChanges();
            return true;
        }

        public List<ChucVu> GetAllCv()
        {
            _chucVuList = _qLBHContext.ChucVus.ToList();
            return _chucVuList;
        }

        public ChucVu GetByMa(string ma)
        {
            throw new NotImplementedException();
        }

        public bool Update(ChucVu cv)
        {
            _qLBHContext.ChucVus.Update(cv);
            _qLBHContext.SaveChanges();
            return true;

        }
    }
}
