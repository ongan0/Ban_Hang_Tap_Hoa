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
    public partial class FrmNhaPhanPhoi : Form
    {
        public NhaPhanPhoiService _nhaPhanPhoiService;
        public NhaPhanPhoi npp;
        public FrmNhaPhanPhoi()
        {
            _nhaPhanPhoiService = new NhaPhanPhoiService();
            InitializeComponent();
            loaddata();
        }

        public void loaddata()
        {
            dtg_Npp.Rows.Clear();
            dtg_Npp.ColumnCount = 3;
            dtg_Npp.Columns[0].Name = "ID";
            dtg_Npp.Columns[1].Name = "Mã nhà phân phối";
            dtg_Npp.Columns[2].Name = "Tên nhà phân phối";
            dtg_Npp.Columns[0].Visible = false;
            foreach (var item in _nhaPhanPhoiService.GetNhaPhanPhoiFromDB())
            {
                dtg_Npp.Rows.Add(item.IdNhaPhanPhoi, item.MaNhaPhanPhoi, item.TenNhaPhanPhoi);
            }
        }
        private void btn_them_Click(object sender, EventArgs e)
        {
            if (tbt_TenNpp.Text != "" && tbt_MaNpp.Text != "")
            {
                if (_nhaPhanPhoiService.GetNhaPhanPhoiFromDB().FirstOrDefault(x => x.MaNhaPhanPhoi == tbt_MaNpp.Text) == null)
                {
                    npp = new NhaPhanPhoi()
                    {
                        TenNhaPhanPhoi = tbt_TenNpp.Text,
                        MaNhaPhanPhoi = tbt_MaNpp.Text,
                    };

                    _nhaPhanPhoiService.AddNhaPhanPhoi(npp);
                    MessageBox.Show("Thêm thành công");
                    loaddata();
                    tbt_TenNpp.Text = "";
                    tbt_MaNpp.Text = "";
                }
                else
                {
                    MessageBox.Show("Mã nhà phân phối đã tồn tại");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên hoặc mã nhà phân phối");
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (tbt_TenNpp.Text != "" && tbt_MaNpp.Text != "")
            {
                if (_nhaPhanPhoiService.GetNhaPhanPhoiFromDB().FirstOrDefault(x => x.MaNhaPhanPhoi == tbt_MaNpp.Text) == null)
                {

                    npp.TenNhaPhanPhoi = tbt_TenNpp.Text;
                        npp.MaNhaPhanPhoi = tbt_MaNpp.Text;
             

                    _nhaPhanPhoiService.UpdateNhaPhanPhoi(npp);
                    MessageBox.Show("Thêm thành công");
                    loaddata();
                    tbt_TenNpp.Text = "";
                    tbt_MaNpp.Text = "";
                }
                else
                {
                    MessageBox.Show("Mã danh mục đã tồn tại");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên danh mục hoặc mã danh mục");
            }
        }

        private void dtg_Npp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow r = dtg_Npp.Rows[e.RowIndex];
                npp = _nhaPhanPhoiService.GetNhaPhanPhoiFromDB().FirstOrDefault(x => x.IdNhaPhanPhoi == (Guid)r.Cells[0].Value);
                tbt_MaNpp.Text = r.Cells[1].Value.ToString();
                tbt_TenNpp.Text = r.Cells[2].Value.ToString();
            }
        }

        
    }
}
