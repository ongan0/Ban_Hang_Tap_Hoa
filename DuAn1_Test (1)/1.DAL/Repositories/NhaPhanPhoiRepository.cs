using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.DAL.Models;
using _1.DAL.IRepositories;

namespace _1.DAL.Repositories
{
    public class NhaPhanPhoiRepository : INhaPhanPhoiRepository
    {
        private QLBHContext _qLBHContext;
        private List<NhaPhanPhoi> _nhaPhanPhois;

        public NhaPhanPhoiRepository()
        {
            _qLBHContext = new QLBHContext();
            _nhaPhanPhois = new List<NhaPhanPhoi>();
        }
        public bool Add(NhaPhanPhoi nhaPhanPhoi)
        {
            _qLBHContext.NhaPhanPhois.Add(nhaPhanPhoi);
            _qLBHContext.SaveChanges();
            return true;
        }

        public bool Delete(NhaPhanPhoi nhaPhanPhoi)
        {
            _qLBHContext.NhaPhanPhois.Remove(nhaPhanPhoi);
            _qLBHContext.SaveChanges();
            return true;
        }

        public List<NhaPhanPhoi> GetAllNpp()
        {
            _nhaPhanPhois = _qLBHContext.NhaPhanPhois.ToList();
            return _nhaPhanPhois;
        }

        public bool Update(NhaPhanPhoi nhaPhanPhoi)
        {
            _qLBHContext.NhaPhanPhois.Update(nhaPhanPhoi);
            _qLBHContext.SaveChanges();
            return true;
        }
    }
}
