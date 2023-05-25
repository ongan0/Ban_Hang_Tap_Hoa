using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.DAL.Models;

namespace _1.DAL.IRepositories
{
    public interface INhanVienRepository
    {
        bool Add(NhanVien nv);

        bool Update(NhanVien nv);

        bool Delete(NhanVien nv);

        NhanVien GetByName(string name); // tìm theo tên

        List<NhanVien> GetAllNv();
    }
}
