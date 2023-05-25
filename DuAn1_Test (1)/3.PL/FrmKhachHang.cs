using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _2.BUS.Services;
using _2.BUS.IServices;
using _1.DAL.Models;
namespace _3.PL
{
    public partial class FrmKhachHang : Form
    {
        IKhachHangService iKhachHang;
        KhachHang _customer;
        IHoaDonService iHoaDonServiec;
        Guid _id;
        public FrmKhachHang()
        {
            iHoaDonServiec = new HoaDonService();
            _customer = new KhachHang();
            iKhachHang = new KhachHangService();
            InitializeComponent();
            loaddata();
        }
        private bool checknhap()
        {
            if (txt_MaKhachHang.Text == "" || txt_TenKhachHang.Text == "" || txt_DiaChi.Text == "" || txt_Sdt.Text == "")
            {
                return false;
            }
            return true;
        }
        private void loaddata()
        {
            dgv_Khachhang.Rows.Clear();
            dgv_Khachhang.ColumnCount = 7;
            dgv_Khachhang.Columns[0].Name = "ID ";
            dgv_Khachhang.Columns[0].Visible = false;
            dgv_Khachhang.Columns[1].Name = "STT ";
            dgv_Khachhang.Columns[2].Name = "Mã Khách Hàng";
            dgv_Khachhang.Columns[3].Name = "Tên Khách Hàng";
            dgv_Khachhang.Columns[4].Name = "Ngày Sinh ";
            dgv_Khachhang.Columns[5].Name = "Đia Chỉ ";
            dgv_Khachhang.Columns[6].Name = "Số Điện Thoại ";
            int stt = 1;


            var khachhang = iKhachHang.GetKhachHangFromDB();
            if (tbx_TimKiem.Text != "")
            {
                khachhang = khachhang.Where(a => a.TenKH.ToLower().Contains(tbx_TimKiem.Text)).ToList();
            }

            foreach (var item in khachhang)
            {
                dgv_Khachhang.Rows.Add(item.IdKhachHang, stt++, item.MaKH, item.TenKH, item.NgaySinh, item.DiaChi, item.SDT);
            }
        }

        private void dgv_Khachhang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow r = dgv_Khachhang.Rows[e.RowIndex];
                _customer = iKhachHang.GetKhachHangFromDB().FirstOrDefault(p => p.IdKhachHang.ToString() == r.Cells[0].Value.ToString());
                _id = Guid.Parse(r.Cells[0].Value.ToString());
                if (_customer != null)
                {

                    txt_MaKhachHang.Text = _customer.MaKH;
                    txt_TenKhachHang.Text = _customer.TenKH;
                    txt_DiaChi.Text = _customer.DiaChi;
                    txt_Sdt.Text = _customer.SDT;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var sdt = iKhachHang.GetKhachHangFromDB().FirstOrDefault(p => p.SDT == txt_Sdt.Text);
            if (checknhap() == false)
            {
                MessageBox.Show("Không được để trống các trường", "Chú ý");
            }
            else if (txt_Sdt.Text.Length < 10)
            {
                MessageBox.Show("Số điện thoại phải có ít nhất 10 kí tự");

            }
            else if (sdt != null)
            {
                MessageBox.Show("Số điện thoại đã được sử dụng", "Chú ý");
            }
            else
            {
                OpenFileDialog op = new OpenFileDialog();
                DialogResult dialog = MessageBox.Show("Bạn có muốn cập nhật sản phẩm không?", "Chú ý", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    _customer.IdKhachHang = new Guid();
                    _customer.TenKH = txt_TenKhachHang.Text;
                    _customer.SDT = txt_Sdt.Text;
                    _customer.NgaySinh = dtp_ngaysinh.Value;
                    _customer.DiaChi = txt_DiaChi.Text;
                    _customer.MaKH = txt_MaKhachHang.Text;
                    iKhachHang.AddKhachHang(_customer);
                    loaddata();
                    MessageBox.Show("Thêm khách hàng thành công");
                }


            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {

            if (checknhap() == false)
            {
                MessageBox.Show("Không được để trống các trường", "Chú ý");
            }
            else if (txt_Sdt.Text.Length < 10)
            {
                MessageBox.Show("Số điện thoại phải có ít nhất 10 kí tự");

            }
            else
            {

                OpenFileDialog op = new OpenFileDialog();
                DialogResult dialog = MessageBox.Show("Bạn có muốn cập nhật sản phẩm không?", "Chú ý", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    _customer.IdKhachHang = _id;
                    _customer.TenKH = txt_TenKhachHang.Text;
                    _customer.SDT = txt_Sdt.Text;
                    _customer.DiaChi = txt_DiaChi.Text;

                    iKhachHang.UpdateKhachHang(_customer);
                    loaddata();

                    MessageBox.Show("Sửa khách hàng thành công");
                }
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            dgv_Khachhang.Rows.Clear();
            dgv_Khachhang.ColumnCount = 7;
            dgv_Khachhang.Columns[0].Name = "ID ";
            dgv_Khachhang.Columns[0].Visible = false;
            dgv_Khachhang.Columns[1].Name = "STT ";
            dgv_Khachhang.Columns[2].Name = "Mã Khách Hàng";
            dgv_Khachhang.Columns[3].Name = "Tên Khách Hàng";
            dgv_Khachhang.Columns[4].Name = "Ngày Sinh ";
            dgv_Khachhang.Columns[5].Name = "Đia Chỉ ";
            dgv_Khachhang.Columns[6].Name = "Số Điện Thoại ";
            int stt = 1;


            var khachhang = iKhachHang.GetKhachHangFromDB();
            if (tbx_TimKiem.Text != "")
            {
                khachhang = khachhang.Where(a => a.TenKH.ToLower().Contains(tbx_TimKiem.Text)).ToList();
            }
            foreach (var item in khachhang)
            {
                dgv_Khachhang.Rows.Add(item.IdKhachHang, stt++, item.MaKH, item.TenKH, item.NgaySinh, item.DiaChi, item.SDT);
            }
        }
    }

}
