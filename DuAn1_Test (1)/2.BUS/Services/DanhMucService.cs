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
    public class DanhMucService : IDanhMucService
    {
        private DanhMucRepository _danhMucRepository;
        private List<DanhMuc> _danhMucList;
        public DanhMucService()
        {
            _danhMucList = new List<DanhMuc>();
            _danhMucRepository = new DanhMucRepository();
        }
        public bool AddDanhMuc(DanhMuc danhMuc)
        {
            _danhMucRepository.Add(danhMuc);

            return true;
        }

        public bool DeleteDanhMuc(DanhMuc danhMuc)
        {
            _danhMucRepository.Delete(danhMuc);

            return true;
        }

        public List<DanhMuc> GetDanhMucFromDB()
        {
            _danhMucList = _danhMucRepository.GetAllDm();
            return _danhMucList;
        }

        public bool UpdateDanhMuc(DanhMuc danhMuc)
        {
            _danhMucRepository.Update(danhMuc);

            return true;
        }
    }
}
