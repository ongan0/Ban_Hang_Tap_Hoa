using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.DAL.Models;

namespace _2.BUS.IServices
{
    public interface IDanhMucService
    {
        bool AddDanhMuc (DanhMuc danhMuc);

        bool DeleteDanhMuc (DanhMuc danhMuc);

        bool UpdateDanhMuc(DanhMuc danhMuc);

        List<DanhMuc> GetDanhMucFromDB(); 

    }
}
