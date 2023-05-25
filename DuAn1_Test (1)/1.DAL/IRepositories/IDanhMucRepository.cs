using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.DAL.Models;

namespace _1.DAL.IRepositories
{
    public interface IDanhMucRepository
    {
        bool Add(DanhMuc danhMuc);

        bool Delete(DanhMuc danhMuc);
        bool Update(DanhMuc danhMuc);

        DanhMuc GetByMa(string ma); // tìm theo ma 

        List<DanhMuc> GetAllDm();
    }
}
