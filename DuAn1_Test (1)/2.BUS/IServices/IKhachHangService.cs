using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.DAL.Models;
using _2.BUS.ViewModels;

namespace _2.BUS.IServices
{
    public interface IKhachHangService
    {
        bool AddKhachHang(KhachHang khachHang);

        bool DeleteKhachHang(KhachHang khachHang);

        bool UpdateKhachHang(KhachHang khachHang);

        List<KhachHang> GetKhachHangFromDB();
    }
}
