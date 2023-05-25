using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _2.BUS.IServices;
using _2.BUS.Services;
using _1.DAL.Models;


namespace _3.PL
{
    public partial class FrmSanPham : Form
    {
        SanPhamService _sanPhamService;
        SanPham Sp;
        public FrmSanPham()
        {
            _sanPhamService = new SanPhamService();
            InitializeComponent();
            loaddata();
        }
        public void loaddata()
        {
            dtg_Sp.Rows.Clear();
            dtg_Sp.ColumnCount = 3;
            dtg_Sp.Columns[0].Name = "ID";
            dtg_Sp.Columns[1].Name = "Mã nhà phân phối";
            dtg_Sp.Columns[2].Name = "Tên nhà phân phối";
            dtg_Sp.Columns[0].Visible = false;
            foreach (var item in _sanPhamService.GetSanPhamFromDB())
            {
                dtg_Sp.Rows.Add(item.IdSanPham, item.MaSP, item.TenSP);
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if (tbt_TenSp.Text != "" && tbt_MaSp.Text != "")
            {
                if (_sanPhamService.GetSanPhamFromDB().FirstOrDefault(x => x.MaSP == tbt_MaSp.Text) == null)
                {
                    Sp = new SanPham()
                    {
                        TenSP = tbt_TenSp.Text,
                        MaSP = tbt_MaSp.Text,
                    };

                    _sanPhamService.AddSanPham(Sp);
                    MessageBox.Show("Thêm thành công");
                    loaddata();
                    tbt_TenSp.Text = "";
                    tbt_MaSp.Text = "";
                }
                else
                {
                    MessageBox.Show("Mã sản phẩm đã tồn tại");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên hoặc mã sản phẩm");
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (tbt_TenSp.Text != "" && tbt_MaSp.Text != "")
            {
                if (_sanPhamService.GetSanPhamFromDB().FirstOrDefault(x => x.MaSP == tbt_MaSp.Text) == null)
                {
                    Sp.TenSP = tbt_TenSp.Text;
                    Sp.MaSP = tbt_MaSp.Text;
                    
                    _sanPhamService.UpdateSanPham(Sp);
                    MessageBox.Show("Thêm thành công");
                    loaddata();
                    tbt_TenSp.Text = "";
                    tbt_MaSp.Text = "";
                }
                else
                {
                    MessageBox.Show("Mã sản phẩm đã tồn tại");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên hoặc mã sản phẩm");
            }
        }

        private void dtg_Sp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow r = dtg_Sp.Rows[e.RowIndex];
                Sp = _sanPhamService.GetSanPhamFromDB().FirstOrDefault(x => x.IdSanPham == (Guid)r.Cells[0].Value);
                tbt_MaSp.Text = r.Cells[1].Value.ToString();
                tbt_TenSp.Text = r.Cells[2].Value.ToString();
            }
        }
    }
}
