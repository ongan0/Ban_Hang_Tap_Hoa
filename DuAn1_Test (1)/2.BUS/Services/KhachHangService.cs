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
    public class KhachHangService : IKhachHangService
    {
        private IKhachHangRepository _khachHangRepository;
        private List<KhachHang> _khachHangList;
        public KhachHangService()
        {
            _khachHangRepository = new KhachHangRepository();
            _khachHangList = new List<KhachHang>();
        }
        public bool AddKhachHang(KhachHang khachHang)
        {
            _khachHangRepository.Add(khachHang);
            return true;
        }

        public bool DeleteKhachHang(KhachHang khachHang)
        {
            _khachHangRepository.Delete(khachHang);
            return true;
        }

        public List<KhachHang> GetKhachHangFromDB()
        {
            _khachHangList = _khachHangRepository.GetAllKh();
            return _khachHangList;
        }

        public bool UpdateKhachHang(KhachHang khachHang)
        {
            _khachHangRepository.Update(khachHang);
            return true;
        }
    }
}
