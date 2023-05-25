using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.DAL.Models;

namespace _1.DAL.IRepositories
{
    public interface IKhachHangRepository
    {
        bool Add(KhachHang kh);
        bool Update(KhachHang kh);

        bool Delete(KhachHang kh);

        KhachHang GetByMa(string ma); // tìm theo ma 

        List<KhachHang> GetAllKh();
    }
}
