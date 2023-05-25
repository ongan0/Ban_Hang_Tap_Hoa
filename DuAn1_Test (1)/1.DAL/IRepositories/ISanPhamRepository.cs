using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.DAL.Models;

namespace _1.DAL.IRepositories
{
    public interface ISanPhamRepository
    {
        bool Add(SanPham sp);

        bool Update(SanPham sp);

        bool Delete(SanPham sp);

        SanPham GetByTen(string ma); // tìm theo id 

        List<SanPham> GetAllSp();
    }
}
