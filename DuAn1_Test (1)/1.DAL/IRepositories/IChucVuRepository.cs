using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.DAL.Models;

namespace _1.DAL.IRepositories
{
    public interface IChucVuRepository
    {
        bool Add(ChucVu cv);

        bool Delete(ChucVu cv);
        bool Update(ChucVu cv);

        ChucVu GetByMa(string ma); // tìm theo ma

        List<ChucVu> GetAllCv();
    }
}
