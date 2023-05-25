using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.DAL.Models;
using _1.DAL.IRepositories;
using _1.DAL.Repositories;
using _2.BUS.IServices;
using _2.BUS.ViewModels;

namespace _2.BUS.Services
{
    public class NhaPhanPhoiService : INhaPhanPhoiService
    {
        private INhaPhanPhoiRepository _nhaPhanPhoiRepository;
        private List<NhaPhanPhoi> _nhaPhanPhoiList;
        public NhaPhanPhoiService()
        {
            _nhaPhanPhoiRepository= new NhaPhanPhoiRepository();
            _nhaPhanPhoiList = new List<NhaPhanPhoi>();
        }
        public bool AddNhaPhanPhoi(NhaPhanPhoi nhaPhanPhoi)
        {
            _nhaPhanPhoiRepository.Add(nhaPhanPhoi);
            return true;
        }

        public bool DeleteNhaPhanPhoi(NhaPhanPhoi nhaPhanPhoi)
        {
            _nhaPhanPhoiRepository.Delete(nhaPhanPhoi);
            return true;
        }

        public List<NhaPhanPhoi> GetNhaPhanPhoiFromDB()
        {
            _nhaPhanPhoiList = _nhaPhanPhoiRepository.GetAllNpp();
            return _nhaPhanPhoiList;    
        }

        public bool UpdateNhaPhanPhoi(NhaPhanPhoi nhaPhanPhoi)
        {
            _nhaPhanPhoiRepository.Update(nhaPhanPhoi);
            return true;
        }
    }
}
