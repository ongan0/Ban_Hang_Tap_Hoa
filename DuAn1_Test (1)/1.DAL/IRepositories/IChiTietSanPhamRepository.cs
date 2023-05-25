using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.DAL.Models;

namespace _1.DAL.IRepositories
{
    public interface IChiTietSanPhamRepository
    {
        bool Add(ChiTietSanPham chiTietSanPham);

        bool Update(ChiTietSanPham chiTietSanPham);

        bool Delete(ChiTietSanPham chiTietSanPham);

        ChiTietSanPham GetByMa(string ma);

        List<ChiTietSanPham> GetAllChiTietSp();


    }
}
