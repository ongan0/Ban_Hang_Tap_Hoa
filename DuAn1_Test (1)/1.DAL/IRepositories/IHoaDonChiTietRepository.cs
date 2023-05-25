using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.DAL.Models;

namespace _1.DAL.IRepositories
{
    public interface IHoaDonChiTietRepository
    {
        bool Add(HoaDonChiTiet HoaDonCT);

        bool Update(HoaDonChiTiet HoaDonCT);

        bool Delete(HoaDonChiTiet HoaDonCT);

        //HoaDonChiTiet GetById(Guid id); 

        List<HoaDonChiTiet> GetAllHDCT();
    }
}
