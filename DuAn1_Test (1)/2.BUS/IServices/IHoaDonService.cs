using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.DAL.Models;
using _2.BUS.ViewModels;

namespace _2.BUS.IServices
{
    public interface IHoaDonService
    {
        bool AddHoaDon(HoaDon hoaDon);
        bool DeleteHoaDon(HoaDon hoaDon);
        
        bool UpdateHoaDon(HoaDon hoaDon);

        List<HoaDon> GetHoaDonFromDB();

        List<HoaDonVM> ShowHoaDon();
    }
}
