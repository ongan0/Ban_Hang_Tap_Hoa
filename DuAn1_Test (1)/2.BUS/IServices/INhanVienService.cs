using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.DAL.Models;
using _2.BUS.ViewModels;

namespace _2.BUS.IServices
{
    public interface INhanVienService
    {
        bool AddNhanVien(NhanVien nhanVien);
        bool UpdateNhanVien(NhanVien nhanVien);

        bool DeleteNhanVien(NhanVien nhanVien);

        List<NhanVien> GetNhanVienFromDB();
        List<NhanVienVM> ShowNhanVien();



    }
}
