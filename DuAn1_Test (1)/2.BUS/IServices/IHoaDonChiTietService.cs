using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.DAL.Models;
using _2.BUS.ViewModels;

namespace _2.BUS.IServices
{
    public interface IHoaDonChiTietService
    {
        bool AddHoaDonChiTiet(HoaDonChiTiet hoaDonChiTiet);

        bool UppdateHoaDonChiTiet(HoaDonChiTiet hoaDonChiTiet);

        bool DeleteHoaDonChiTiet(HoaDonChiTiet hoaDonChiTiet);

        //bool DeleteHDCT(HoaDonChiTietVM hoaDonChiTiet);

        List<HoaDonChiTiet> GetHoaDonChiTietFromDB();

        List<HoaDonChiTietVM> ShowHoaDonChiTiet(Guid IdHD);

        
    }
}
