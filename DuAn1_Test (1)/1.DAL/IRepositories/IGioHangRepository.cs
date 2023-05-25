using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.DAL.Models;

namespace _1.DAL.IRepositories
{
    public interface IGioHangRepository
    {
        bool Add(GioHang gh);

        bool Delete(GioHang gh);
        bool Update(GioHang gh);

        //GioHang GetById(Guid id);

        List<GioHang> GetAllGh();
    }
}
