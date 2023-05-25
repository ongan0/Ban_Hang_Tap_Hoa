using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.DAL.Models;

namespace _1.DAL.IRepositories
{
    public interface INhaPhanPhoiRepository
    {
        bool Add(NhaPhanPhoi nhaPhanPhoi);

        bool Update(NhaPhanPhoi nhaPhanPhoi);
        bool Delete(NhaPhanPhoi nhaPhanPhoi);

        List<NhaPhanPhoi> GetAllNpp();

        
    }
}
