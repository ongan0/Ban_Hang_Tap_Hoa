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
    public partial class FrmDanhMuc : Form
    {
        public DanhMucService _danhMucService;
        public DanhMuc dm;
        public FrmDanhMuc()
        {
            _danhMucService = new DanhMucService();
            InitializeComponent();
            loaddata();
        }
        public void loaddata()
        {
            dtg_DM.Rows.Clear();
            dtg_DM.ColumnCount = 3;
            dtg_DM.Columns[0].Name = "ID";
            dtg_DM.Columns[1].Name = "Mã danh mục";
            dtg_DM.Columns[2].Name = "Tên danh mục";
            dtg_DM.Columns[0].Visible = false;
            foreach(var item in _danhMucService.GetDanhMucFromDB())
            {
                dtg_DM.Rows.Add(item.IdDanhMuc, item.MaDanhMuc, item.TenDanhMuc);
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if (tbt_tenDM.Text != "" && tbt_MaDM.Text != "")
            {
                if (_danhMucService.GetDanhMucFromDB().FirstOrDefault(x => x.MaDanhMuc == tbt_MaDM.Text) == null)
                {
                    dm = new DanhMuc()
                    {
                        TenDanhMuc = tbt_tenDM.Text,
                        MaDanhMuc = tbt_MaDM.Text,
                    };
                    
                    _danhMucService.AddDanhMuc(dm);
                    MessageBox.Show("Thêm thành công");
                    loaddata();
                    tbt_tenDM.Text = "";
                    tbt_MaDM.Text = "";
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

        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (tbt_tenDM.Text != "" && tbt_MaDM.Text != "")
            {
                if (_danhMucService.GetDanhMucFromDB().FirstOrDefault(x => x.MaDanhMuc == tbt_MaDM.Text) == null)
                {

                    dm.TenDanhMuc = tbt_MaDM.Text;
                        dm.MaDanhMuc = tbt_MaDM.Text;
                    
                    _danhMucService.UpdateDanhMuc(dm);
                    MessageBox.Show("Thêm thành công");
                    loaddata();
                    tbt_tenDM.Text = "";
                    tbt_MaDM.Text = "";
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

        private void dtg_DM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow r = dtg_DM.Rows[e.RowIndex];
                dm = _danhMucService.GetDanhMucFromDB().FirstOrDefault(x => x.IdDanhMuc == (Guid)r.Cells[0].Value);
                tbt_MaDM.Text = r.Cells[1].Value.ToString();
                tbt_tenDM.Text = r.Cells[2].Value.ToString();
            }
        }
    }
}
