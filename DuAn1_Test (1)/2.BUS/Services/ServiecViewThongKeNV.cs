using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.DAL.Models;
using _1.DAL.IRepositories;
using _1.DAL.Repositories;
using _2.BUS.IServices;
using _2.BUS.ViewModels;

namespace _2.BUS.Services
{
    public class ServiecViewThongKeNV : iViewThongKeNV4
    {
        private INhanVienService _invser;
        private IHoaDonService _ihdser;
        private List<ViewThongKeNV> _lstdoanhthu;
        private string manv;
        private double tong;
        private NhanVien _nv;
        private ViewThongKeNV _viewdoanhthu;
        private DateTime? day;
        private DateTime? nam;
        private string mon;
        private string year;
        public ServiecViewThongKeNV()
        {
            _ihdser = new HoaDonService();
            _nv = new NhanVien();
            _invser = new NhanVienService();
            _lstdoanhthu = new List<ViewThongKeNV>();
            Getlistviewdoanhthu();
        }
        public List<ViewThongKeNV> Getlistviewdoanhthu()
        {
            var listcommit = (from a in _invser.GetNhanVienFromDB() join b in _ihdser.GetHoaDonFromDB() on a.IdNhanVien equals b.IdNhanVien select new { a.MaNhanVien, a.TenNhanVien, b.TongTien, b.NgayTao }).ToList();
            // gán giá trị
            foreach (var x in listcommit)
            {
                tong = Convert.ToDouble(_ihdser.GetHoaDonFromDB().Where(c => c.IdNhanVien == _nv.IdNhanVien).Select(c => c.TongTien).Sum());
                day = x.NgayTao;
                nam = x.NgayTao;
                mon = day.Value.Month.ToString();
                year = nam.Value.Year.ToString();
                _viewdoanhthu = new ViewThongKeNV(manv, x.TenNhanVien, tong, mon, year, x.NgayTao);
                _lstdoanhthu.Add(_viewdoanhthu);
            }

            var lisfinal = listcommit.OrderBy(c => c.TongTien).GroupBy(c => c.MaNhanVien)
                .Select(g => new ViewThongKeNV(g.Key, g.Where(c => c.MaNhanVien == g.Key).Select(c => c.TenNhanVien).FirstOrDefault(), g.Sum(c => c.TongTien), mon, year, g.Where(c => c.MaNhanVien == g.Key).Select(c => c.NgayTao).FirstOrDefault())).ToList();
            return lisfinal;
        }
    }
}
