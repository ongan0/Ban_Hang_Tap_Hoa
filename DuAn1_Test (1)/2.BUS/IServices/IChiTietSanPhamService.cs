using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.DAL.Models;
using _2.BUS.ViewModels;


namespace _2.BUS.IServices
{
    public interface IChiTietSanPhamService
    {
        bool AddChiTietSp(ChiTietSanPham chiTietSanPham);

        bool UpdateChiTietSp(ChiTietSanPham chiTietSanPham);

        bool DeleteChiTietSp(ChiTietSanPham chiTietSanPham);

        List<ChiTietSanPham> GetChiTietSpFromDB();

        List<SanPhamVM> ShowSanPham();

        bool Addctsp(SanPhamVM sanPhamVM);

        bool Updatectsp(SanPhamVM sanPhamVM);


    }
}
