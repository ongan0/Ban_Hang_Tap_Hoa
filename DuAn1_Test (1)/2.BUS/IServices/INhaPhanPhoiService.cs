using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.DAL.Models;
using _2.BUS.ViewModels;

namespace _2.BUS.IServices
{
    public interface INhaPhanPhoiService
    {
        bool AddNhaPhanPhoi(NhaPhanPhoi nhaPhanPhoi);

        bool DeleteNhaPhanPhoi(NhaPhanPhoi nhaPhanPhoi);

        bool UpdateNhaPhanPhoi(NhaPhanPhoi nhaPhanPhoi);

        List<NhaPhanPhoi> GetNhaPhanPhoiFromDB();
    }
}
