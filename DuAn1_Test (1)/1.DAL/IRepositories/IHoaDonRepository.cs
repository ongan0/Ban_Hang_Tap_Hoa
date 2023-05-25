using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.DAL.Models;

namespace _1.DAL.IRepositories
{
    public interface IHoaDonRepository
    {
        bool Add(HoaDon hd);
        bool Update(HoaDon hd);

        bool Delete(HoaDon hd);

        HoaDon GetByMa(string ma); // tìm theo ma 

        List<HoaDon> GetAllHD();
    }
}
