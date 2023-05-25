using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _1.DAL.Models;
using _2.BUS.Services;
using _2.BUS.IServices;
using _2.BUS.ViewModels;
using System.IO;
using OfficeOpenXml;

namespace _3.PL
{
    public partial class FrmKhoHang : Form
    {
        public NhaPhanPhoiService _nhaPhanPhoiService;
        public DanhMucService _danhMucService;
        public ChiTietSanPhamService _chiTietSanPhamService;
        public SanPhamService _sanPhamService;
        public ChiTietSanPham sp;
        string LinkAnh = "";
        string tenSp = "";
        

        public FrmKhoHang()
        {
            _chiTietSanPhamService = new ChiTietSanPhamService();
            _sanPhamService = new SanPhamService();
            _nhaPhanPhoiService = new NhaPhanPhoiService();
            _danhMucService = new DanhMucService();
            InitializeComponent();
            LoadDanhMuc();
            LoadNhaPhanPhoi();
            Loaddata();
            LoadSanpham();
            //dtp_NgaySx.CustomFormat = "dd-MM-yyyy";
            //dtp_HanSd.CustomFormat = "dd-MM-yyyy";
            cbo_loc.Items.Add("Kinh doanh");
            cbo_loc.Items.Add("Ngừng kinh doanh");
        }
        public void LoadDanhMuc()
        {
            foreach (var item in _danhMucService.GetDanhMucFromDB())
            {
                cbb_DanhMuc.Items.Add(item.TenDanhMuc);
            }
        }
        public void LoadNhaPhanPhoi()
        {
            foreach (var item in _nhaPhanPhoiService.GetNhaPhanPhoiFromDB())
            {
                cbb_nhaPhanPhoi.Items.Add(item.TenNhaPhanPhoi);
            }
        }
        public void LoadSanpham()
        {
            foreach (var item in _sanPhamService.GetSanPhamFromDB())
            {
                cbb_SanPham.Items.Add(item.TenSP);
            }
        }

        public void Loaddata()
        {
            dtgv_frmSP.Rows.Clear();
            dtgv_frmSP.ColumnCount = 11;
            dtgv_frmSP.Columns[0].Name = "ID";
            dtgv_frmSP.Columns[0].Visible = false; 
            dtgv_frmSP.Columns[1].Name = "Mã BarCode";
            dtgv_frmSP.Columns[2].Name = "Tên sản phẩm";
            dtgv_frmSP.Columns[3].Name = "Giá nhập";
            dtgv_frmSP.Columns[4].Name = "Giá bán";
            dtgv_frmSP.Columns[5].Name = "Ngày sản xuất";
            dtgv_frmSP.Columns[6].Name = "Hạn sử dụng";
            dtgv_frmSP.Columns[7].Name = "Số lượng";
            dtgv_frmSP.Columns[8].Name = "Danh mục";
            dtgv_frmSP.Columns[9].Name = "Nhà phân phối";
            dtgv_frmSP.Columns[10].Name = "Trạng thái";
            foreach(var item in _chiTietSanPhamService.ShowSanPham())
            {

                dtgv_frmSP.Rows.Add(item.IdChiTietSp, item.MaQRCode, item.TenSP,item.GiaNhap,item.GiaBan,item.NgaySX.ToString("dd-MM-yyyy"), item.HanSD.ToString("dd-MM-yyyy"), item.SoLuongTon,
                    item.TenDanhMuc,item.TenNhaPhanPhoi, item.TrangThai == 1 ? "Kinh doanh" : "Ngừng kinh doanh");
            }
        }



        public bool checknhap()
        {
            if (tbt_maBarCode.Text == "" || cbb_SanPham.Text == "" || tbt_gianhap.Text == "" || tbt_giaban.Text == "" || tbt_soLuong.Text == "" 
                || cbb_DanhMuc.Text == "" || cbb_nhaPhanPhoi.Text == "") return false;
            return true;
        }

        private void pcb_anhSP_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
                LinkAnh = op.FileName;
                pcb_anhSP.Image = Image.FromFile(op.FileName);
                pcb_anhSP.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            var p = _chiTietSanPhamService.ShowSanPham().FirstOrDefault(x => x.MaQRCode == tbt_maBarCode.Text);
            var tsp = _chiTietSanPhamService.ShowSanPham().FirstOrDefault(p => p.TenSP == cbb_SanPham.Text);

            if (checknhap() == false)
            {
                MessageBox.Show("Không được để trống các trường", "Chú ý");
            }
            else if (p != null)
            {
                MessageBox.Show("Mã sản phẩm đã tồn tại", "Chú ý");
            }
            else if (tsp != null)
            {
                MessageBox.Show("Tên sản phẩm đã tồn tại", "Chú ý");
            }
            else if (Convert.ToDecimal(tbt_gianhap.Text) > Convert.ToDecimal(tbt_giaban.Text))
            {
                MessageBox.Show("Giá bán phải cao hơn giá nhập", "Chú ý");
            }
            else if (LinkAnh == "")
            {
                MessageBox.Show("Bạn chưa thêm ảnh cho sản phẩm", "Chú ý");
            }
            else
            {
                DialogResult dialog = MessageBox.Show("Bạn có muốn thêm sản phẩm không?", "Thêm", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {

                    ChiTietSanPham sanPham = new ChiTietSanPham()
                    {
                        //sanPham.IdChiTietSp = Guid.NewGuid(),
                        IdDanhMuc = _danhMucService.GetDanhMucFromDB()[cbb_DanhMuc.SelectedIndex].IdDanhMuc,
                        IdNhaPhanPhoi = _nhaPhanPhoiService.GetNhaPhanPhoiFromDB()[cbb_nhaPhanPhoi.SelectedIndex].IdNhaPhanPhoi,
                        IdSanPham = _sanPhamService.GetSanPhamFromDB()[cbb_SanPham.SelectedIndex].IdSanPham,
                        MaQRCode = tbt_maBarCode.Text,
                        SoLuongTon = Convert.ToInt32(tbt_soLuong.Text),
                        GiaBan = Convert.ToDouble(tbt_giaban.Text),
                        GiaNhap = Convert.ToDouble(tbt_gianhap.Text),
                        NgaySX = dtp_NgaySx.Value,
                        HanSD = dtp_HanSd.Value,
                        TrangThai = rd_kd.Checked == true ? 1 : 0,
                        Anh = LinkAnh,
                    };

                    _chiTietSanPhamService.AddChiTietSp(sanPham);
                    MessageBox.Show("Thêm sản phẩm thành công");
                    Loaddata();
                }
            }
        }




        private void dtgv_frmSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow r = dtgv_frmSP.Rows[e.RowIndex];
            sp = _chiTietSanPhamService.GetChiTietSpFromDB().FirstOrDefault(p => p.IdChiTietSp == (Guid)r.Cells[0].Value);
            tbt_maBarCode.Text = r.Cells[1].Value.ToString();
            cbb_SanPham.Text = r.Cells[2].Value.ToString();
            tbt_gianhap.Text = r.Cells[3].Value.ToString();
            tbt_giaban.Text = r.Cells[4].Value.ToString();
            dtp_NgaySx.Text = r.Cells[5].Value.ToString();
            dtp_HanSd.Text = r.Cells[6].Value.ToString();
            tbt_soLuong.Text = r.Cells[7].Value.ToString();
            cbb_DanhMuc.Text = r.Cells[8].Value.ToString();
            cbb_nhaPhanPhoi.Text = r.Cells[9].Value.ToString();

            rd_kd.Checked = r.Cells[10].Value.ToString() == "Kinh doanh" ? true : false;
            rd_ngungkd.Checked = r.Cells[10].Value.ToString() == "Ngừng kinh doanh" ? true : false;
            LinkAnh = sp.Anh;
         

            if (LinkAnh != null && File.Exists(LinkAnh))
            {
                pcb_anhSP.Image = Image.FromFile(LinkAnh);
                pcb_anhSP.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                pcb_anhSP.Image = null;
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            sp = _chiTietSanPhamService.GetChiTietSpFromDB().FirstOrDefault(p => p.MaQRCode == tbt_maBarCode.Text);
            if (sp == null)
            {
                MessageBox.Show("Không tìm thấy mã sản phẩm", "Cảnh báo");
            }
            else
            {
                //var tsp = _IQLProductServices.GetProductFromDB().FirstOrDefault(p => p.Name == tb_tensp.Text);


                if (checknhap() == false)
                {
                    MessageBox.Show("Không được để trống các trường", "Chú ý");
                }
                //else if (tenSp != cbb_SanPham.Text)
                //{
                //    MessageBox.Show("Tên sản phẩm đã tồn tại", "Chú ý");
                //}
                else if (Convert.ToDecimal(tbt_gianhap.Text) > Convert.ToDecimal(tbt_giaban.Text))
                {
                    MessageBox.Show("Giá bán phải cao hơn giá nhập", "Chú ý");
                }
                else if (pcb_anhSP.Image == null)
                {
                    MessageBox.Show("Bạn chưa thêm ảnh cho sản phẩm", "Chú ý");
                }
                else
                {
                    OpenFileDialog op = new OpenFileDialog();
                    DialogResult dialog = MessageBox.Show("Bạn có muốn cập nhật sản phẩm không?", "Chú ý", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                    {

                        sp.IdDanhMuc = _danhMucService.GetDanhMucFromDB()[cbb_DanhMuc.SelectedIndex].IdDanhMuc;
                        sp.IdNhaPhanPhoi = _nhaPhanPhoiService.GetNhaPhanPhoiFromDB()[cbb_nhaPhanPhoi.SelectedIndex].IdNhaPhanPhoi;
                        sp.IdSanPham = _sanPhamService.GetSanPhamFromDB()[cbb_SanPham.SelectedIndex].IdSanPham;
                        sp.MaQRCode = tbt_maBarCode.Text;
                        sp.SoLuongTon = Convert.ToInt32(tbt_soLuong.Text);
                        sp.GiaBan = Convert.ToDouble(tbt_giaban.Text);
                        sp.GiaNhap = Convert.ToDouble(tbt_gianhap.Text);
                        sp.NgaySX = dtp_NgaySx.Value;
                        sp.HanSD = dtp_HanSd.Value;
                        sp.TrangThai = rd_kd.Checked == true ? 1 : 0;
                        sp.Anh = LinkAnh;

                        _chiTietSanPhamService.UpdateChiTietSp(sp);
                        MessageBox.Show("Cập nhật sản phẩm thành công");
                        Loaddata();
                        //tenSp = cbb_SanPham.Text;
                    }
                }
            }
        }







        private void danhMucToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDanhMuc frmDanhMuc = new FrmDanhMuc();
            frmDanhMuc.ShowDialog();
        }

        private void nhaPhanPhoiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNhaPhanPhoi frmNhaPhanPhoi = new FrmNhaPhanPhoi();
            frmNhaPhanPhoi.ShowDialog();
        }

        private void sanPhamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSanPham frmSanPham = new FrmSanPham();
            frmSanPham.ShowDialog();
        }

        private void tbt_timkSP_TextChanged(object sender, EventArgs e)
        {
            var timkiem = _chiTietSanPhamService.ShowSanPham().Where(p => p.TenSP.Contains(tbt_timkSP.Text) 
                                                                    || p.MaQRCode.Contains(tbt_timkSP.Text));
            if(tbt_timkSP.Text == "")
            {
                Loaddata();
            }
            else
            {
                foreach (var item in timkiem)
                {
                    dtgv_frmSP.Rows.Clear();
                    dtgv_frmSP.Rows.Add(item.IdChiTietSp, item.MaQRCode, item.TenSP, item.GiaNhap, item.GiaBan, item.NgaySX.ToString("dd-MM-yyyy"), item.HanSD.ToString("dd-MM-yyyy"), item.SoLuongTon,
                        item.TenDanhMuc, item.TenNhaPhanPhoi, item.TrangThai == 1 ? "Kinh doanh" : "Ngừng kinh doanh");
                }
            }
            
        }
        private void senderexcel(string path)
        {
            using (ExcelPackage p = new ExcelPackage())
            {
                // đặt tên người tạo file
                p.Workbook.Properties.Author = "";

                // đặt tiêu đề cho file
                p.Workbook.Properties.Title = "Báo cáo thống kê";

                //Tạo một sheet để làm việc trên đó
                p.Workbook.Worksheets.Add("sheet");

                // lấy sheet vừa add ra để thao tác
                ExcelWorksheet ws = p.Workbook.Worksheets[1];

                // đặt tên cho sheet
                ws.Name = "sheet";
                // fontsize mặc định cho cả sheet
                ws.Cells.Style.Font.Size = 11;
                // font family mặc định cho cả sheet
                ws.Cells.Style.Font.Name = "Calibri";

                for (int i = 0; i < dtgv_frmSP.Columns.Count; i++)
                {
                    ws.Cells[1, i + 1].Value = dtgv_frmSP.Columns[i].HeaderText;
                }
                for (int i = 0; i < dtgv_frmSP.Rows.Count; i++)
                {
                    for (int j = 0; j < dtgv_frmSP.Columns.Count; j++)
                    {
                        ws.Cells[i + 2, j + 1].Value = dtgv_frmSP.Rows[i].Cells[j].Value;
                    }
                }
                //Lưu file lại
                Byte[] bin = p.GetAsByteArray();
                File.WriteAllBytes(path, bin);

                /*excel.Application application = new excel.Application();
                application.Application.Workbooks.Add(Type.Missing);
                for (int i = 0; i < dtgv_HDcho.Columns.Count; i++)
                {
                    application.Cells[1, i + 1] = dtgv_HDcho.Columns[i].HeaderText;
                }
                for (int i = 0; i < dtgv_HDcho.Rows.Count; i++)
                {
                    for (int j = 0; j < dtgv_HDcho.Columns.Count; j++)
                    {
                        application.Cells[i + 2, j + 1] = dtgv_HDcho.Rows[i].Cells[j].Value;
                    }
                }
                application.Columns.AutoFit();
                application.ActiveWorkbook.SaveCopyAs(path);
                application.ActiveWorkbook.Saved = true;*/
            };
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string filePath = "";
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Export Excel";
            saveFileDialog.Filter = "Excel | *.xlsx | Excel 2003 | *.xls";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = saveFileDialog.FileName;
                try
                {
                    senderexcel(filePath);
                    MessageBox.Show("Xuất File Excel Thành công");
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Xuất File Excel không  Thành công" + ex.Message);
                }
            }
        }

        private void cbo_loc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbo_loc.Text == "Kinh doanh")
            {
                if(tbt_timkSP.Text != null)
                {
                    var timkiem = _chiTietSanPhamService.ShowSanPham().Where(p => p.TrangThai == 1
                                                                                    && ( p.TenSP.Contains(tbt_timkSP.Text) || p.MaQRCode.Contains(tbt_timkSP.Text)));
                    dtgv_frmSP.Rows.Clear();
                    foreach (var item in timkiem)
                    {
                        dtgv_frmSP.Rows.Add(item.IdChiTietSp, item.MaQRCode, item.TenSP, item.GiaNhap, item.GiaBan, item.NgaySX.ToString("dd-MM-yyyy"), 
                            item.HanSD.ToString("dd-MM-yyyy"), item.SoLuongTon,
                            item.TenDanhMuc, item.TenNhaPhanPhoi, item.TrangThai == 1 ? "Kinh doanh" : "Ngừng kinh doanh");
                    }
                }
                if(tbt_timkSP.Text == null)
                {
                    var timkiem = _chiTietSanPhamService.ShowSanPham().Where(p => p.TrangThai == 1);
                    dtgv_frmSP.Rows.Clear();
                    foreach (var item in timkiem)
                    {
                        dtgv_frmSP.Rows.Add(item.IdChiTietSp, item.MaQRCode, item.TenSP, item.GiaNhap, item.GiaBan, item.NgaySX.ToString("dd-MM-yyyy"),
                            item.HanSD.ToString("dd-MM-yyyy"), item.SoLuongTon,
                            item.TenDanhMuc, item.TenNhaPhanPhoi, item.TrangThai == 1 ? "Kinh doanh" : "Ngừng kinh doanh");
                    }
                }
            }

            if(cbo_loc.Text == "Ngừng kinh doanh")
            {
                if (tbt_timkSP.Text != null)
                {
                    var timkiem = _chiTietSanPhamService.ShowSanPham().Where(p => p.TrangThai == 0
                                                                                    && (p.TenSP.Contains(tbt_timkSP.Text) || p.MaQRCode.Contains(tbt_timkSP.Text)));
                    dtgv_frmSP.Rows.Clear();
                    foreach (var item in timkiem)
                    {
                        dtgv_frmSP.Rows.Add(item.IdChiTietSp, item.MaQRCode, item.TenSP, item.GiaNhap, item.GiaBan, item.NgaySX.ToString("dd-MM-yyyy"),
                            item.HanSD.ToString("dd-MM-yyyy"), item.SoLuongTon,
                            item.TenDanhMuc, item.TenNhaPhanPhoi, item.TrangThai == 1 ? "Kinh doanh" : "Ngừng kinh doanh");
                    }
                }
                if (tbt_timkSP.Text == null)
                {
                    var timkiem = _chiTietSanPhamService.ShowSanPham().Where(p => p.TrangThai == 0);
                    dtgv_frmSP.Rows.Clear();
                    foreach (var item in timkiem)
                    {
                        dtgv_frmSP.Rows.Add(item.IdChiTietSp, item.MaQRCode, item.TenSP, item.GiaNhap, item.GiaBan, item.NgaySX.ToString("dd-MM-yyyy"),
                            item.HanSD.ToString("dd-MM-yyyy"), item.SoLuongTon,
                            item.TenDanhMuc, item.TenNhaPhanPhoi, item.TrangThai == 1 ? "Kinh doanh" : "Ngừng kinh doanh");
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmTaoBarCode taoBarCode = new FrmTaoBarCode();
            taoBarCode.ShowDialog();
        }
    }
}
