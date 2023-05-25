using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.DAL.Models;

namespace _1.DAL.IRepositories
{
    public interface IGioHangChiTietRepository
    {
        bool Add(GioHangChiTiet ghct);

        bool Delete(GioHangChiTiet ghct);
        bool Update(GioHangChiTiet ghct);

        //GioHangChiTiet GetById(Guid id);

        List<GioHangChiTiet> GetAllGhct();
    }
}
