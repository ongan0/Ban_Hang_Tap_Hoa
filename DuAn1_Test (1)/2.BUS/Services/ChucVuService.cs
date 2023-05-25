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
    public class ChucVuService : IChucVuService
    {
        private IChucVuRepository _chucVuRepository;
        private List<ChucVu> _chucVuList;
        public ChucVuService()
        {
            _chucVuRepository = new ChucVuRepository();
            _chucVuList = new List<ChucVu>();
        }
        public bool AddChucVu(ChucVu chucVu)
        {
            _chucVuRepository.Add(chucVu);
            return true;    
        }

        

        public List<ChucVu> GetChucVuFromDB()
        {
            _chucVuList = _chucVuRepository.GetAllCv();
            return _chucVuList; 
        }
    }
}
