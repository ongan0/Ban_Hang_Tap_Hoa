using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
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
using _2.BUS.IServices;
using _2.BUS.Services;
using _2.BUS.ViewModels;
using System.IO;

namespace _3.PL
{
    public partial class FrmBanHang : Form
    {
        private IChiTietSanPhamService _chiTietSanPhamService;
        private ISanPhamService _sanPhamService;
        private IHoaDonChiTietService _hoaDonChiTietService;
        private IHoaDonService _hoaDonService;
        private IKhachHangService _khachHangService;
        private INhanVienService _nhanVienService;
        List<HoaDonChiTietVM> _listHoaDonCT;
        public Guid pID;
        public KhachHang kh;
        public Guid oID;
        public int tang;
        public ChiTietSanPham ctsp;
        public FrmBanHang()
        {
            _chiTietSanPhamService = new ChiTietSanPhamService();
            _sanPhamService = new SanPhamService();
            _hoaDonChiTietService = new HoaDonChiTietService();
            _hoaDonService = new HoaDonService();
            _khachHangService = new KhachHangService();
            _nhanVienService = new NhanVienService();
            _listHoaDonCT = new List<HoaDonChiTietVM>();
            kh = new KhachHang();
            //oID = -1;
            tang = 0;
            InitializeComponent();
            LoadSanPham();
            LoadHdCho();
        }
        public void LoadSanPham()
        {
            dtg_danhsachSP.Rows.Clear();
            dtg_danhsachSP.ColumnCount = 6;
            dtg_danhsachSP.Columns[0].Name = "Mã sản phẩm";
            dtg_danhsachSP.Columns[0].Visible = false; 
            dtg_danhsachSP.Columns[1].Name = "Mã BarCode";
            dtg_danhsachSP.Columns[2].Name = "Tên sản phẩm";
            dtg_danhsachSP.Columns[3].Name = "Danh mục";
            dtg_danhsachSP.Columns[4].Name = "Giá bán";
            dtg_danhsachSP.Columns[5].Name = "Số lượng";
            //dtg_danhsachSP.Columns[6].Name = "Hình anh";



            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn.HeaderText = "Ảnh";
            dtg_danhsachSP.Columns.Add(imageColumn);

            imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
        
            //dtg_danhsachSP.Columns[6].Name = "Hinh anh";

            foreach (var item in _chiTietSanPhamService.ShowSanPham().Where(x => x.TrangThai == 1  && x.SoLuongTon > 0))
            {    
                dtg_danhsachSP.Rows.Add(item.Masp,item.MaQRCode,item.TenSP,item.TenDanhMuc, item.GiaBan, item.SoLuongTon, Image.FromFile(item.LinkAnh));
            }
        }
        public void LoadGioHang()
        {

            dtg_giohang.Rows.Clear();
            dtg_giohang.ColumnCount = 4;
            dtg_giohang.Columns[0].Name = "Mã sản phẩm";
            dtg_giohang.Columns[1].Name = "Tên sản phẩm";
            dtg_giohang.Columns[2].Name = "Số lượng";
            dtg_giohang.Columns[3].Name = "Giá";
            foreach (var item in _listHoaDonCT)
            {
                dtg_giohang.Rows.Add(item.MaSp, item.TenSP, item.SoLuong, item.GiaBan);
            }
            totalCart();
        }
        public void addGioHang(Guid pID)
        {
            var p = _chiTietSanPhamService.ShowSanPham().FirstOrDefault(x => x.IdChiTietSp == pID);
            var data = _listHoaDonCT.FirstOrDefault(x => x.IdChiTietSp == p.IdChiTietSp);
            if (data == null)
            {
                HoaDonChiTietVM hoaDonChiTietVM = new HoaDonChiTietVM()
                {
                    IdChiTietSp = p.IdChiTietSp,
                    TenSP = p.TenSP,
                    GiaBan = p.GiaBan,
                    SoLuong = 1,
                    MaSp = p.Masp,
                    MaQR = p.MaQRCode

                };
                _listHoaDonCT.Add(hoaDonChiTietVM);
            }
            else
            {
                if(data.SoLuong == p.SoLuongTon) 
                {
                    MessageBox.Show("Sản phẩm trong giỏ hàng đã vượt quá số lượng cho phép");
                }
                else
                {
                    data.SoLuong++;
                }
            }
            LoadGioHang();
        }

        private void dtg_giohang_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow r = dtg_giohang.Rows[e.RowIndex];
                if(int.TryParse(dtg_giohang.Rows[r.Index].Cells[2].Value.ToString(), out int x))
                {
                    if(dtg_giohang.Rows[r.Index].Cells[2].Value != _listHoaDonCT[r.Index].SoLuong.ToString())
                    {
                        if (Convert.ToInt32(dtg_giohang.Rows[r.Index].Cells[2].Value) <= 0)
                        {
                            MessageBox.Show("Nhập sai số lượng");
                            dtg_giohang.Rows[r.Index].Cells[2].Value = _listHoaDonCT[r.Index].SoLuong;
                        }
                        else
                        {
                            var p = _chiTietSanPhamService.GetChiTietSpFromDB().FirstOrDefault(x => x.IdChiTietSp == _listHoaDonCT[r.Index].IdChiTietSp);
                            if (p.SoLuongTon < Convert.ToInt32(dtg_giohang.Rows[r.Index].Cells[2].Value))
                            {
                                MessageBox.Show("Sản phẩm trong giỏ hàng đã vượt quá số lượng cho phép");
                                dtg_giohang.Rows[r.Index].Cells[2].Value = _listHoaDonCT[r.Index].SoLuong;
                            }
                            else
                            {
                                _listHoaDonCT[r.Index].SoLuong = Convert.ToInt32(dtg_giohang.Rows[r.Index].Cells[2].Value);
                                totalCart();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Nhập sai số lượng");
                    dtg_giohang.Rows[r.Index].Cells[3].Value = _listHoaDonCT[r.Index].SoLuong;
                }
            }
        }
        private void dtg_danhsachSP_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow r = dtg_danhsachSP.Rows[e.RowIndex];
                pID = _chiTietSanPhamService.ShowSanPham().FirstOrDefault(x => x.Masp == r.Cells[0].Value.ToString()).IdChiTietSp;
                addGioHang(pID);
            }
        }

      

        private void dtg_giohang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow r = dtg_giohang.Rows[e.RowIndex];
                pID = _chiTietSanPhamService.ShowSanPham().FirstOrDefault(x => x.Masp == r.Cells[0].Value.ToString()).IdChiTietSp;
            }
        }

        private void tbt_tienkhachdua_TextChanged(object sender, EventArgs e)
        {
            loadTienThua();
        }


        private void tbt_giamgia_TextChanged(object sender, EventArgs e)
        {
            loadTienThua();
        }




        private void btn_thanhtoan_Click(object sender, EventArgs e)
        {
            if(tbt_mahd.Text != "")
            {
                HoaDon o = _hoaDonService.GetHoaDonFromDB().FirstOrDefault(x => x.MaHD == tbt_mahd.Text && x.TrangThai == 0);
                if(o == null)
                {
                    MessageBox.Show("Đơn hàng không tồn tại hoặc đã thanh toán");
                    lb_tongtien.Text = "0";
                }
                else
                {
                    var khachHang = _khachHangService.GetKhachHangFromDB().FirstOrDefault(x => x.IdKhachHang == o.IdKhachHang);
                    int x;
                    if (tbt_giamgia.Text == "" || Convert.ToDecimal(lb_tienthua.Text) < 0 || tbt_tienkhachdua.Text == "" ||
                        (!int.TryParse(tbt_giamgia.Text, out x) && tbt_giamgia.Text != "") ||
                        !int.TryParse(tbt_tienkhachdua.Text, out int y) || x > khachHang.DiemTieuDung
                        || x < 0 || Convert.ToDouble(tbt_giamgia.Text) > Convert.ToDouble(lb_tongtien.Text) || x > khachHang.DiemTieuDung)
                    {
                        MessageBox.Show("Vui lòng nhập đúng số tiền");
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Bạn có muốn in hóa đơn không?", "Thanh toán", MessageBoxButtons.YesNo);
                        if(dialogResult == DialogResult.Yes)
                        {
                            o.TrangThai = 1;
                            o.NgayThanhToan = DateTime.Now;
                            _hoaDonService.UpdateHoaDon(o);
                            if(tbt_tienkhachdua.Text == "0" && Convert.ToDouble(tbt_giamgia.Text) > o.TongTien)
                            {
                                lb_tienthua.Text = "0";
                                khachHang.DiemTieuDung -= Convert.ToInt32(o.TongTien);
                            }
                            else
                            {
                                if(tbt_giamgia.Text != "")
                                {
                                    khachHang.DiemTieuDung = khachHang.DiemTieuDung + Convert.ToInt32(o.TongTien / 100) - Convert.ToInt32(tbt_giamgia.Text);
                                }
                                else
                                {
                                    khachHang.DiemTieuDung += Convert.ToInt32(o.TongTien/100);
                                }
                            }
                            _khachHangService.UpdateKhachHang(khachHang);
                            MessageBox.Show("Thanh toán thành công");
                            ihd();

                            //SaveFileDialog of = new SaveFileDialog()
                            //{
                            //    Filter = "PDF flie|*.pdf",
                            //    ValidateNames = true,


                            //};
                            //if (of.ShowDialog() == DialogResult.OK)
                            //{
                            //    iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A7.Rotate());
                            //    iTextSharp.text.pdf.PdfWriter.GetInstance(doc, new FileStream(of.FileName, FileMode.Create));
                            //    doc.Open();
                            //    //doc.Add();
                            //}

                            tbt_giamgia.Text = "";
                            tbt_tienkhachdua.Text = "";
                            lb_tongtien.Text = "0";
                            lb_tienthua.Text = "0";
                            rtb_ghichu.Text = "";
                            LoadHdCho();

                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập mã hóa đơn");
            }
        }

        private void tbt_mahd_TextChanged(object sender, EventArgs e)
        {
            HoaDon o = _hoaDonService.GetHoaDonFromDB().FirstOrDefault(x => x.MaHD == tbt_mahd.Text && x.TrangThai == 0);
            if(o != null)
            {
                lb_tongtien.Text = o.TongTien.ToString();
                var khachHang = _khachHangService.GetKhachHangFromDB().FirstOrDefault(x => x.IdKhachHang == o.IdKhachHang);
                lb_giamgia.Text = $"(Tối đa : {khachHang.DiemTieuDung})";
            }
            else
            {
                lb_tongtien.Text = "0";
                lb_giamgia.Text = "(Tối đa : 0)";
            }
        }

        public void totalCart()
        {
            if (_listHoaDonCT != null)
            {
                double total = 0;
                foreach (var item in _listHoaDonCT)
                {
                    total += item.GiaBan * item.SoLuong;
                }
                lb_totalcart.Text = total.ToString();
            }
            else
            {
                lb_totalcart.Text = "";
            }
        }





        public void loadTienThua()
        {
            if(!(tbt_tienkhachdua.Text == "" && tbt_giamgia.Text == ""))
            {
                if(tbt_giamgia.Text == "")
                {
                    if(decimal.TryParse(tbt_tienkhachdua.Text, out decimal x))
                    {
                        lb_tienthua.Text =(Convert.ToDecimal(tbt_tienkhachdua.Text) - Convert.ToDecimal(lb_tongtien.Text)).ToString();
                    }
                }
                else
                {
                    if(decimal.TryParse(tbt_tienkhachdua.Text, out decimal x) && decimal.TryParse(tbt_giamgia.Text, out decimal y))
                    {
                        lb_tienthua.Text = (Convert.ToDecimal(tbt_tienkhachdua.Text) - Convert.ToDecimal(lb_tongtien.Text)
                            + Convert.ToDecimal(tbt_giamgia.Text)).ToString();
                    }
                }
            }
        }

        private void btn_xoaGioHang_Click(object sender, EventArgs e)
        {
            if (_listHoaDonCT.Any())
            {
                var item = _listHoaDonCT.FirstOrDefault(x => x.IdChiTietSp == pID);
                _listHoaDonCT.Remove(item);
                LoadGioHang();
            }
            else
            {
                MessageBox.Show("Chưa có sản phẩm nào trong giỏ hàng");
            }
        }

        private void btn_XoaSP_Click(object sender, EventArgs e)
        {
            if (_listHoaDonCT.Any())
            {
                var item = _listHoaDonCT.FirstOrDefault(x => x.IdChiTietSp == pID);
                _listHoaDonCT.Remove(item);
                LoadGioHang();
            }
            else
            {
                MessageBox.Show("Chưa có sản phẩm nào trong giỏ hàng");
            }
        }

        public void LoadHdCho()
        {
            dgv_hdcho.Rows.Clear();
            dgv_hdcho.ColumnCount = 3;
            dgv_hdcho.Columns[0].Name = "ID";
            dgv_hdcho.Columns[1].Name = "Mã HD";
            dgv_hdcho.Columns[2].Name = "Tên khách hàng";
            dgv_hdcho.Columns[0].Visible = false;
            var hdCho = (from a in _hoaDonService.GetHoaDonFromDB()
                         join b in _khachHangService.GetKhachHangFromDB() on a.IdKhachHang equals b.IdKhachHang
                         where a.TrangThai == 0
                         select new { a, b });
            foreach(var item in hdCho)
            {
                dgv_hdcho.Rows.Add(item.a.IdHoaDon,item.a.MaHD, item.b.TenKH);
            }
        }

        private void btn_TaoHd_Click(object sender, EventArgs e)
        {
            //tang++;
            
            if (_listHoaDonCT.Any())
            {
                double total = 0;
                
                foreach (var item in _listHoaDonCT)
                {
                    total += item.GiaBan * item.SoLuong;
                }
                Guid eID = _nhanVienService.GetNhanVienFromDB().FirstOrDefault(x => x.Gmail == Properties.Settings.Default.TKdaLogin).IdNhanVien;
                kh = _khachHangService.GetKhachHangFromDB().FirstOrDefault(x => x.SDT == tb_sdt.Text);
                if(kh != null)
                {
                    HoaDon hd = new HoaDon()
                    {
                        
                        NgayTao = DateTime.Now,
                        NgayThanhToan = DateTime.Now,
                        MaHD = "HD" + DateTime.Now.ToString("ddMMyyHHmmss"),
                        IdNhanVien = eID,
                        IdKhachHang = kh.IdKhachHang,
                        TongTien = total,
                        TrangThai = 0,

                    };
                    _hoaDonService.AddHoaDon(hd);
                    
                    foreach(var item in _listHoaDonCT)
                    {
                        HoaDonChiTiet hdct = new HoaDonChiTiet() 
                        {
                            IdHoaDon = hd.IdHoaDon,
                            IdChiTietSp = item.IdChiTietSp,
                            TenSP = item.TenSP,
                            GiaBan = item.GiaBan,
                            SoLuong = item.SoLuong,
                        };
                        _hoaDonChiTietService.AddHoaDonChiTiet(hdct);
                        var sp = _chiTietSanPhamService.GetChiTietSpFromDB().FirstOrDefault(x => x.IdChiTietSp == item.IdChiTietSp);
                        sp.SoLuongTon -= item.SoLuong;
                        _chiTietSanPhamService.UpdateChiTietSp(sp);
                    }
                    oID = hd.IdHoaDon;
                    tbt_mahd.Text = hd.MaHD;
                    lb_tongtien.Text = hd.TongTien.ToString();
                    tb_sdt.Text = "";
                    lb_totalcart.Text = "";
                    MessageBox.Show($"Tạo hóa đơn thành công. Mã hóa đơn: {hd.MaHD}");
                    LoadSanPham();
                    LoadHdCho();
                    _listHoaDonCT = new List<HoaDonChiTietVM>();
                    dtg_giohang.Rows.Clear();
                }

                else
                {
                    MessageBox.Show("Vui lòng nhập khách hàng");
                }
                
            }
            else
            {
                MessageBox.Show("Chưa có sản phẩm nào trong giỏ hàng");
            }
        }

        private void tb_sdt_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(tb_sdt.Text, out int x))
            {
                kh = _khachHangService.GetKhachHangFromDB().FirstOrDefault(x => x.SDT == tb_sdt.Text);
                if (kh != null)
                {
                    lb_tenkh.Text = kh.TenKH;
                    lb_point.Text = kh.DiemTieuDung.ToString();
                }
                else
                {
                    lb_tenkh.Text = "";
                    lb_point.Text = "";
                }
            }
            else
            {
                lb_tenkh.Text = "";
                lb_point.Text = "";
            }
        }

        private void dgv_hdcho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow r = dgv_hdcho.Rows[e.RowIndex];
                oID = Guid.Parse(r.Cells[0].Value.ToString());
                tbt_mahd.Text = dgv_hdcho.CurrentRow.Cells[1].Value.ToString();
                //oID.ToString();
                var od = _hoaDonChiTietService.GetHoaDonChiTietFromDB().Where(x => x.IdHoaDon == oID);
                var cid = _hoaDonService.GetHoaDonFromDB().FirstOrDefault(x => x.IdHoaDon == oID).IdKhachHang;
                var c = _khachHangService.GetKhachHangFromDB().FirstOrDefault(x =>x.IdKhachHang == cid);
                tb_sdt.Text = c.SDT;

                _listHoaDonCT = new List<HoaDonChiTietVM>();
                foreach (var item in od) 
                { 
                    var p = _chiTietSanPhamService.ShowSanPham().FirstOrDefault(x => x.IdChiTietSp == item.IdChiTietSp);
                    HoaDonChiTietVM hdct = new HoaDonChiTietVM()
                    {
                        IdChiTietSp = p.IdChiTietSp,
                        TenSP = p.TenSP,
                        GiaBan = p.GiaBan,
                        SoLuong = od.FirstOrDefault(x => x.IdChiTietSp == p.IdChiTietSp).SoLuong,
                        MaSp = p.Masp,
                        MaQR = p.MaQRCode

                    };
                    _listHoaDonCT.Add(hdct);
                    LoadGioHang();
                }
            }
        }

        private void btn_capNhapHĐ_Click(object sender, EventArgs e)
        {
            if (oID != null)
            {
                if (_listHoaDonCT.Any())
                {
                    int total = 0;
                    kh = _khachHangService.GetKhachHangFromDB().FirstOrDefault(x => x.SDT == tb_sdt.Text);
                    if (kh != null)
                    {
                        var hd = _hoaDonService.GetHoaDonFromDB().FirstOrDefault(x => x.IdHoaDon == oID);
                        var hdct = _hoaDonChiTietService.GetHoaDonChiTietFromDB().Where(x => x.IdHoaDon == oID);
                        foreach (var item in hdct)
                        {
                            _hoaDonChiTietService.DeleteHoaDonChiTiet(item);
                        }
                        foreach (var item in _listHoaDonCT)
                        {
                            HoaDonChiTiet od = new HoaDonChiTiet()
                            {
                                IdHoaDon = oID,
                                IdChiTietSp = item.IdChiTietSp,
                                TenSP = item.TenSP, 
                                GiaBan = item.GiaBan,
                                SoLuong = item.SoLuong
                            };
                            total += Convert.ToInt32(item.SoLuong * item.GiaBan);
                            _hoaDonChiTietService.AddHoaDonChiTiet(od);
                            var p = _chiTietSanPhamService.GetChiTietSpFromDB().FirstOrDefault(x => x.IdChiTietSp == item.IdChiTietSp);
                            p.SoLuongTon -= item.SoLuong;
                            _chiTietSanPhamService.UpdateChiTietSp(p);
                        }
                        Guid eID = _nhanVienService.GetNhanVienFromDB().FirstOrDefault(x => x.Gmail == Properties.Settings.Default.TKdaLogin).IdNhanVien;
                        hd.NgayTao = DateTime.Now;
                        hd.IdNhanVien = eID;
                        hd.IdKhachHang = kh.IdKhachHang;
                        hd.TongTien = total;
                        _hoaDonService.UpdateHoaDon(hd);

                        tbt_mahd.Text = hd.MaHD;
                        lb_tongtien.Text = total.ToString();
                        tb_sdt.Text = "";
                        lb_totalcart.Text = "";
                        MessageBox.Show($"Cập nhật đơn thành công.Mã hóa đơn: { hd.MaHD}");

                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập khách hàng");
                    }
                }
                else
                {
                    MessageBox.Show("Chưa có sản phẩm nào trong giỏ hàng");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hóa đơn chưa thanh toán");
            }
        }




        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;
        private void button1_Click(object sender, EventArgs e)
        {
            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cbb_Camera.SelectedIndex].MonikerString);
            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            videoCaptureDevice.Start();
        }

        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            BarcodeReader reader = new BarcodeReader();
            var result = reader.Decode(bitmap);
            if(result != null)
            {
                tbt_timkiemSP.Invoke(new MethodInvoker(delegate ()
                {
                    tbt_timkiemSP.Text = result.ToString();
                }));
            }
            pictureBox1.Image = bitmap;
        }

        private void FrmBanHang_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach(FilterInfo device in filterInfoCollection)
                cbb_Camera.Items.Add(device.Name);
            cbb_Camera.SelectedIndex = 0;
        }

    

        private void tbt_timkiemSP_TextChanged(object sender, EventArgs e)
        {
            var timkiem = _chiTietSanPhamService.ShowSanPham().Where(p => p.TenSP.Contains(tbt_timkiemSP.Text)
                                                                    || p.MaQRCode.Contains(tbt_timkiemSP.Text));
            if (tbt_timkiemSP.Text == "")
            {
                LoadSanPham();
            }
            else
            {
                foreach (var item in timkiem.Where(x => x.TrangThai == 1 && x.SoLuongTon > 0))
                {
                    dtg_danhsachSP.Rows.Clear();
                    dtg_danhsachSP.Rows.Add(item.Masp, item.MaQRCode, item.TenSP, item.TenDanhMuc, item.GiaBan, item.SoLuongTon);
                }


            }
            LoadGioHang();
            //LoadSanPham();
        }

        private void FrmBanHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(videoCaptureDevice != null)
            {
                if(videoCaptureDevice.IsRunning)
                    videoCaptureDevice.Stop();
            }
        }

        private void ihd()
        {
            pphd.Document = phd;
            pphd.ShowDialog();

        }
        private void phd_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var hd = _hoaDonService.GetHoaDonFromDB().FirstOrDefault(c => c.IdHoaDon == oID);
            var kh = _khachHangService.GetKhachHangFromDB().FirstOrDefault(c => c.IdKhachHang == hd.IdKhachHang);
            var nv = _nhanVienService.GetNhanVienFromDB().FirstOrDefault(c => c.IdNhanVien == hd.IdNhanVien);

            //lấy chiều rộng của giấy
            var w = phd.DefaultPageSettings.PaperSize.Width;
            //
            e.Graphics.DrawString("BarMart", new System.Drawing.Font("Times New Roman", 15, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(100, 20));

            e.Graphics.DrawString(String.Format("Mã Hóa Đơn : {0}", hd.MaHD), new System.Drawing.Font("Times New Roman", 15, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(w / 2 + 200, 20));
            e.Graphics.DrawString(String.Format(" {0}", DateTime.Now.ToString()), new System.Drawing.Font("Times New Roman", 15, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(w / 2 + 200, 45));

            //
            Pen pn = new Pen(Color.Black, 1);

            var y = 70;
            Point p1 = new Point(10, y);
            Point p2 = new Point(w - 10, y);
            e.Graphics.DrawLine(pn, p1, p2);
            y += 10;
            e.Graphics.DrawString(String.Format("HÓA ĐƠN BÁN HÀNG"), new System.Drawing.Font("Times New Roman", 15, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(w / 2 - 100, y));
            y += 20;
            e.Graphics.DrawString(String.Format("Ngày Mua : {0}", hd.NgayTao), new System.Drawing.Font("Times New Roman", 15, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(w / 2 + 200, y));
            e.Graphics.DrawString(String.Format("Tên Khách Hàng : {0}", kh.TenKH), new System.Drawing.Font("Times New Roman", 15, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(10, y));
            e.Graphics.DrawString(String.Format("SDT : {0}", kh.SDT), new System.Drawing.Font("Times New Roman", 15, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(10, y + 30));
            y += 70;
            e.Graphics.DrawString(String.Format("STT"), new System.Drawing.Font("Times New Roman", 15, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(10, y));
            e.Graphics.DrawString(String.Format("Tên Sản Phẩm"), new System.Drawing.Font("Times New Roman", 15, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(100, y));
            e.Graphics.DrawString(String.Format("Số Lượng"), new System.Drawing.Font("Times New Roman", 15, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(w / 2, y));
            e.Graphics.DrawString(String.Format("Đơn Giá"), new System.Drawing.Font("Times New Roman", 15, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(w / 2 + 100, y));
            e.Graphics.DrawString(String.Format("Thành Tiền"), new System.Drawing.Font("Times New Roman", 15, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(w / 2 + 200, y));
            /////
            ///
            int stt = 1;
            y += 20;

            foreach (var x in _hoaDonChiTietService.GetHoaDonChiTietFromDB().Where(c => c.IdHoaDon == oID))
            {
                var thanhtien = x.SoLuong * x.GiaBan;
                e.Graphics.DrawString(String.Format("{0}", stt++), new System.Drawing.Font("Times New Roman", 15, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(10, y));
                e.Graphics.DrawString(String.Format("{0}", x.TenSP), new System.Drawing.Font("Times New Roman", 15, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(100, y));
                e.Graphics.DrawString(String.Format("{0}", x.SoLuong), new System.Drawing.Font("Times New Roman", 15, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(w / 2, y));
                e.Graphics.DrawString(String.Format("{0}", x.GiaBan), new System.Drawing.Font("Times New Roman", 15, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(w / 2 + 100, y));
                e.Graphics.DrawString(String.Format("{0}", thanhtien), new System.Drawing.Font("Times New Roman", 15, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(w / 2 + 200, y));
                y += 20;
            }
            y += 20;
            e.Graphics.DrawLine(pn, p1, p2);
            y += 20;
            e.Graphics.DrawString(String.Format("Tổng Tiền : {0}", hd.TongTien), new System.Drawing.Font("Times New Roman", 15, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(w / 2 + 200, y));
        }
    }
}
