using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _2.BUS.IServices;
using _2.BUS.Services;
using _1.DAL.Models;
using System.Text.RegularExpressions;

namespace _3.PL
{
    public partial class FrmNhanVien : Form
    {
        NhanVienService _nhanVienService;
        ChucVuService _chucVuService;
        string linkAnh = "" ;
        string layEmail = "";
        NhanVien nhanVien;
        public FrmNhanVien()
        {
            InitializeComponent();
            _nhanVienService = new NhanVienService();
            _chucVuService = new ChucVuService();
            foreach (var item in _chucVuService.GetChucVuFromDB())
            {
                cbb_chucvu.Items.Add(item.TenCV);
            }
            rad_hd.Checked = true;
            rb_nam.Checked = true;
            foreach (var item in _chucVuService.GetChucVuFromDB())
            {
                cbb_locChucVu.Items.Add(item.TenCV);
            }
            cbb_locTrangThai.Items.Add("Hoạt Động");
            cbb_locTrangThai.Items.Add("Không hoạt Động");
            dtp_ngaysinh.CustomFormat = "dd-MM-yyyy";
            loadNhanVien();

        }

        public void loadNhanVien()
        {
            dgv_nhanvien.Rows.Clear();
            dgv_nhanvien.ColumnCount = 9;
            dgv_nhanvien.Columns[0].Name = "Mã nhân viên";
            dgv_nhanvien.Columns[1].Name = "Tên nhân viên";
            dgv_nhanvien.Columns[2].Name = "SDT";
            dgv_nhanvien.Columns[3].Name = "Gmail";
            dgv_nhanvien.Columns[4].Name = "Địa chỉ";
            dgv_nhanvien.Columns[5].Name = "Giới tính";
            dgv_nhanvien.Columns[6].Name = "Chức vụ";
            dgv_nhanvien.Columns[7].Name = "Trạng thái";
            dgv_nhanvien.Columns[8].Name = "Ngày sinh";
            foreach (var item in _nhanVienService.GetNhanVienFromDB())
            {
                string formattedDate = item.NgaySinh.ToString("dd-MM-yyyy");  //chuyển đổi sang dd/mm/yyyy 

                dgv_nhanvien.Rows.Add(item.MaNhanVien, item.TenNhanVien, item.SDT,item.Gmail ,item.DiaChi, item.GioiTinh == 1 ? "Nam" : "Nữ",
                    _chucVuService.GetChucVuFromDB().Where(p => p.IdChucVu == item.IdChucVu).Select(p => p.TenCV).FirstOrDefault(),
                    item.TrangThai == true ? "Hoạt Động" : "Không hoạt động",
                    item.NgaySinh.ToString("dd-MM-yyyy"));
            }
            cbb_chucvu.SelectedIndex = 1;
        }


        public bool checkInput()
        {
            string email = tbt_Email.Text;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,10})+)$");
            Match match = regex.Match(email);
            if (!match.Success)
            {
                MessageBox.Show("Email không hợp lệ!!!");
                tbt_Email.Text = "";
                return false;
            }
            else if (tbt_tenNV.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập Tên nhân viên");
                return false;
            }
            else if (tbt_tenNV.Text.Length < 8)
            {
                MessageBox.Show("Tên nhân viên phải có ít nhất 8 kí tự");
                return false;
            }
            else if (tbt_sdt.Text.Length < 10)
            {
                MessageBox.Show("Số điện thoại phải có ít nhất 10 kí tự");
                return false;
            }
            else if (!tbt_sdt.Text.All(char.IsNumber))
            {
                MessageBox.Show("Số điện thoại phải là số !");
                return false;
            }
            else if (tbt_diachi.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ !");
                return false;
            }
            else if (pictureBox_avt.Image == null)
            {
                MessageBox.Show("Bạn chưa tải ảnh đại diện !");
                return false;
            }

            return true;
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            var checkEmail = _nhanVienService.GetNhanVienFromDB().FirstOrDefault(p => p.Gmail == tbt_Email.Text);
            if (!checkInput())
            {

            }
            else
            {
                if (checkEmail != null)
                {
                    MessageBox.Show("Email đã được sử dụng, hãy chọn Email khác");
                }
                else
                {
                    int idss = _nhanVienService.GetNhanVienFromDB().Count() + 1;


                    NhanVien nv = new NhanVien()
                    {

                        MaNhanVien = "NV" + idss,
                        Gmail = tbt_Email.Text,
                        MatKhau = tbt_MatKhau.Text,
                        TenNhanVien = tbt_tenNV.Text,
                        TrangThai = rad_hd.Checked,
                        GioiTinh = rb_nam.Checked == true ? 1 : 0,
                        NgaySinh = dtp_ngaysinh.Value,
                        DiaChi = tbt_diachi.Text,
                        SDT = tbt_sdt.Text,
                        IdChucVu = _chucVuService.GetChucVuFromDB()[cbb_chucvu.SelectedIndex].IdChucVu,
                        LinkAnh = linkAnh
                };
                    _nhanVienService.AddNhanVien(nv);
                    MessageBox.Show("Thêm Nhân Viên thành công");
                    loadNhanVien();
                }
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            var up = _nhanVienService.GetNhanVienFromDB().FirstOrDefault(p => p.Gmail == layEmail);
            if (tbt_Email.Text != layEmail)
            {
                MessageBox.Show("Bạn không được thay đổi Email");
                tbt_Email.Text = layEmail;
            }
            else
            {
                if (!checkInput())
                {

                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Bạn có muốn cập nhật thông tin không ?", "Thông Báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {

                 

                        nhanVien.TenNhanVien = tbt_tenNV.Text;
                        nhanVien.GioiTinh = rb_nam.Checked == true ? 1 : 0;
                        nhanVien.NgaySinh = dtp_ngaysinh.Value;
                        nhanVien.IdChucVu = _chucVuService.GetChucVuFromDB()[cbb_chucvu.SelectedIndex].IdChucVu;
                        nhanVien.DiaChi = tbt_diachi.Text;
                        nhanVien.SDT = tbt_sdt.Text;
                        nhanVien.TrangThai = rad_hd.Checked;
                        nhanVien.LinkAnh = linkAnh;
                        if (nhanVien.Gmail == tbt_Email.Text)
                        {
                            _nhanVienService.UpdateNhanVien(nhanVien);
                            MessageBox.Show("Cập nhật thông tin thành công");


                            loadNhanVien();
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật thông tin thất bại");
                        }
                    }

                }
            }
        }

        private void dgv_nhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow r = dgv_nhanvien.Rows[e.RowIndex];
            nhanVien = _nhanVienService.GetNhanVienFromDB().FirstOrDefault(p => p.MaNhanVien == r.Cells[0].Value.ToString());
            tbt_MaNV.Text  = r.Cells[0].Value.ToString();
            tbt_tenNV.Text = r.Cells[1].Value.ToString();
            tbt_sdt.Text = r.Cells[2].Value.ToString();
            tbt_Email.Text = r.Cells[3].Value.ToString();
            tbt_diachi.Text = r.Cells[4].Value.ToString();

            rb_nam.Checked = r.Cells[5].Value.ToString() == "Nam" ? true : false;
            rb_nu.Checked = r.Cells[5].Value.ToString() == "Nữ" ? true : false;
            dtp_ngaysinh.Value = nhanVien.NgaySinh;
            cbb_chucvu.Text = r.Cells[6].Value.ToString();
            
            rad_hd.Checked = r.Cells[7].Value.ToString() == "Hoạt Động" ? true : false;
            rad_khd.Checked = r.Cells[7].Value.ToString() == "Không hoạt động" ? true : false;
            linkAnh = nhanVien.LinkAnh;
            layEmail = tbt_Email.Text;
            
            if (linkAnh != null && File.Exists(linkAnh))
            {
                pictureBox_avt.Image = Image.FromFile(linkAnh);
                pictureBox_avt.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                pictureBox_avt.Image = null;
            }



        }

        private void btn_AddAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
                linkAnh = op.FileName;
                pictureBox_avt.Image = Image.FromFile(op.FileName);
                pictureBox_avt.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void textBox_timKiem_TextChanged(object sender, EventArgs e)
        {
            if (cbb_locChucVu.Text != "")
            {
                if (cbb_locTrangThai.Text == "Hoạt Động")
                {
                    var timkiem = _nhanVienService.GetNhanVienFromDB().Where(p => p.TenNhanVien.Contains(textBox_timKiem.Text)
                                                                      && p.IdChucVu == _chucVuService.GetChucVuFromDB()[cbb_chucvu.SelectedIndex].IdChucVu && p.TrangThai == true);
                    dgv_nhanvien.Rows.Clear();
                    foreach (var item in timkiem)
                    {
                        dgv_nhanvien.Rows.Add(item.MaNhanVien, item.TenNhanVien, item.SDT, item.Gmail, item.DiaChi, item.GioiTinh == 1 ? "Nam" : "Nữ",
                            _chucVuService.GetChucVuFromDB().Where(p => p.IdChucVu == item.IdChucVu).Select(p => p.TenCV).FirstOrDefault(),
                            item.TrangThai == true ? "Hoạt Động" : "Không hoạt động",
                            item.NgaySinh.ToString("dd-MM-yyyy"));
                    }
                }
                if (cbb_locTrangThai.Text == "Không koạt Động")
                {
                    var timkiem = _nhanVienService.GetNhanVienFromDB().Where(p => p.TenNhanVien.Contains(textBox_timKiem.Text)
                                                                           && p.IdChucVu == _chucVuService.GetChucVuFromDB()[cbb_chucvu.SelectedIndex].IdChucVu && p.TrangThai == false);
                    dgv_nhanvien.Rows.Clear();
                    foreach (var item in timkiem)
                    {
                        dgv_nhanvien.Rows.Add(item.MaNhanVien, item.TenNhanVien, item.SDT, item.Gmail, item.DiaChi, item.GioiTinh == 1 ? "Nam" : "Nữ",
                            _chucVuService.GetChucVuFromDB().Where(p => p.IdChucVu == item.IdChucVu).Select(p => p.TenCV).FirstOrDefault(),
                            item.TrangThai == true ? "Hoạt Động" : "Không hoạt động",
                            item.NgaySinh.ToString("dd-MM-yyyy"));
                    }
                }
                if (cbb_locTrangThai.Text == "")
                {
                    var timkiem = _nhanVienService.GetNhanVienFromDB().Where(p => p.TenNhanVien.Contains(textBox_timKiem.Text)
                                                                      && p.IdChucVu == _chucVuService.GetChucVuFromDB()[cbb_chucvu.SelectedIndex].IdChucVu);
                    dgv_nhanvien.Rows.Clear();
                    foreach (var item in timkiem)
                    {
                        dgv_nhanvien.Rows.Add(item.MaNhanVien, item.TenNhanVien, item.SDT, item.Gmail, item.DiaChi, item.GioiTinh == 1 ? "Nam" : "Nữ",
                            _chucVuService.GetChucVuFromDB().Where(p => p.IdChucVu == item.IdChucVu).Select(p => p.TenCV).FirstOrDefault(),
                            item.TrangThai == true ? "Hoạt Động" : "Không hoạt động",
                            item.NgaySinh.ToString("dd-MM-yyyy"));
                    }
                }


            }
            if (cbb_locChucVu.Text == "")
            {
                if (cbb_locTrangThai.Text == "Hoạt Động")
                {
                    var timkiem = _nhanVienService.GetNhanVienFromDB().Where(p => p.TenNhanVien.Contains(textBox_timKiem.Text)
                                                                      && p.TrangThai == true);
                    dgv_nhanvien.Rows.Clear();
                    foreach (var item in timkiem)
                    {
                        dgv_nhanvien.Rows.Add(item.MaNhanVien, item.TenNhanVien, item.SDT, item.Gmail, item.DiaChi, item.GioiTinh == 1 ? "Nam" : "Nữ",
                            _chucVuService.GetChucVuFromDB().Where(p => p.IdChucVu == item.IdChucVu).Select(p => p.TenCV).FirstOrDefault(),
                            item.TrangThai == true ? "Hoạt Động" : "Không hoạt động",
                            item.NgaySinh.ToString("dd-MM-yyyy"));
                    }
                }
                if (cbb_locTrangThai.Text == "Không koạt Động")
                {
                    var timkiem = _nhanVienService.GetNhanVienFromDB().Where(p => p.TenNhanVien.Contains(textBox_timKiem.Text)
                                                                            && p.TrangThai == false);
                    dgv_nhanvien.Rows.Clear();
                    foreach (var item in timkiem)
                    {
                        dgv_nhanvien.Rows.Add(item.MaNhanVien, item.TenNhanVien, item.SDT, item.Gmail, item.DiaChi, item.GioiTinh == 1 ? "Nam" : "Nữ",
                            _chucVuService.GetChucVuFromDB().Where(p => p.IdChucVu == item.IdChucVu).Select(p => p.TenCV).FirstOrDefault(),
                            item.TrangThai == true ? "Hoạt Động" : "Không hoạt động",
                            item.NgaySinh.ToString("dd-MM-yyyy"));
                    }
                }

                if (cbb_locTrangThai.Text == "")
                {
                    var timkiem = _nhanVienService.GetNhanVienFromDB().Where(p => p.TenNhanVien.Contains(textBox_timKiem.Text));
                    dgv_nhanvien.Rows.Clear();
                    foreach (var item in timkiem)
                    {
                        dgv_nhanvien.Rows.Add(item.MaNhanVien, item.TenNhanVien, item.SDT, item.Gmail, item.DiaChi, item.GioiTinh == 1 ? "Nam" : "Nữ",
                            _chucVuService.GetChucVuFromDB().Where(p => p.IdChucVu == item.IdChucVu).Select(p => p.TenCV).FirstOrDefault(),
                            item.TrangThai == true ? "Hoạt Động" : "Không hoạt động",
                            item.NgaySinh.ToString("dd-MM-yyyy"));
                    }
                }

            }
            if (cbb_locTrangThai.Text == "Hoạt Động")
            {
                if (cbb_chucvu.Text == "")
                {
                    var timkiem = _nhanVienService.GetNhanVienFromDB().Where(p => p.TenNhanVien.Contains(textBox_timKiem.Text)
                                                                      && p.TrangThai == true);
                    dgv_nhanvien.Rows.Clear();
                    foreach (var item in timkiem)
                    {
                        dgv_nhanvien.Rows.Add(item.MaNhanVien, item.TenNhanVien, item.SDT, item.Gmail, item.DiaChi, item.GioiTinh == 1 ? "Nam" : "Nữ",
                            _chucVuService.GetChucVuFromDB().Where(p => p.IdChucVu == item.IdChucVu).Select(p => p.TenCV).FirstOrDefault(),
                            item.TrangThai == true ? "Hoạt Động" : "Không hoạt động",
                            item.NgaySinh.ToString("dd-MM-yyyy"));
                    }
                }
            }
            if (cbb_locTrangThai.Text == "Không hoạt Động")
            {
                var timkiem = _nhanVienService.GetNhanVienFromDB().Where(p => p.TenNhanVien.Contains(textBox_timKiem.Text)
                                                                            && p.TrangThai == false);
                dgv_nhanvien.Rows.Clear();
                foreach (var item in timkiem)
                {
                    dgv_nhanvien.Rows.Add(item.MaNhanVien, item.TenNhanVien, item.SDT, item.Gmail, item.DiaChi, item.GioiTinh == 1 ? "Nam" : "Nữ",
                        _chucVuService.GetChucVuFromDB().Where(p => p.IdChucVu == item.IdChucVu).Select(p => p.TenCV).FirstOrDefault(),
                        item.TrangThai == true ? "Hoạt Động" : "Không hoạt động",
                        item.NgaySinh.ToString("dd-MM-yyyy"));
                }
            }
        }

        private void cbb_locTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_locTrangThai.Text == "Hoạt Động" && cbb_locChucVu.Text != "")
            {
                if (textBox_timKiem.Text != "")
                {
                    var timkiem = _nhanVienService.GetNhanVienFromDB().Where(p => p.TrangThai == true
                                                                              && p.IdChucVu == _chucVuService.GetChucVuFromDB()[cbb_chucvu.SelectedIndex].IdChucVu
                                                                              && p.TenNhanVien.Contains(textBox_timKiem.Text));
                    dgv_nhanvien.Rows.Clear();
                    foreach (var item in timkiem)
                    {
                        dgv_nhanvien.Rows.Add(item.MaNhanVien, item.TenNhanVien, item.SDT, item.Gmail, item.DiaChi, item.GioiTinh == 1 ? "Nam" : "Nữ",
                            _chucVuService.GetChucVuFromDB().Where(p => p.IdChucVu == item.IdChucVu).Select(p => p.TenCV).FirstOrDefault(),
                            item.TrangThai == true ? "Hoạt Động" : "Không hoạt động",
                            item.NgaySinh.ToString("dd-MM-yyyy"));
                    }
                }
                if (textBox_timKiem.Text == "")
                {
                    var timkiem = _nhanVienService.GetNhanVienFromDB().Where(p => p.TrangThai == true
                                                                           && p.IdChucVu == _chucVuService.GetChucVuFromDB()[cbb_chucvu.SelectedIndex].IdChucVu);
                    dgv_nhanvien.Rows.Clear();
                    foreach (var item in timkiem)
                    {
                        dgv_nhanvien.Rows.Add(item.MaNhanVien, item.TenNhanVien, item.SDT, item.Gmail, item.DiaChi, item.GioiTinh == 1 ? "Nam" : "Nữ",
                            _chucVuService.GetChucVuFromDB().Where(p => p.IdChucVu == item.IdChucVu).Select(p => p.TenCV).FirstOrDefault(),
                            item.TrangThai == true ? "Hoạt Động" : "Không hoạt động",
                            item.NgaySinh.ToString("dd-MM-yyyy"));
                    }
                }

            }
            if (cbb_locTrangThai.Text == "Không hoạt Động" && cbb_locChucVu.Text != "")
            {
                if (textBox_timKiem.Text != "")
                {
                    var timkiem = _nhanVienService.GetNhanVienFromDB().Where(p => p.TrangThai == false
                                                                              && p.IdChucVu == _chucVuService.GetChucVuFromDB()[cbb_chucvu.SelectedIndex].IdChucVu
                                                                              && p.TenNhanVien.Contains(textBox_timKiem.Text));
                    dgv_nhanvien.Rows.Clear();
                    foreach (var item in timkiem)
                    {
                        dgv_nhanvien.Rows.Add(item.MaNhanVien, item.TenNhanVien, item.SDT, item.Gmail, item.DiaChi, item.GioiTinh == 1 ? "Nam" : "Nữ",
                             _chucVuService.GetChucVuFromDB().Where(p => p.IdChucVu == item.IdChucVu).Select(p => p.TenCV).FirstOrDefault(),
                             item.TrangThai == true ? "Hoạt Động" : "Không hoạt động",
                             item.NgaySinh.ToString("dd-MM-yyyy"));
                    }
                }
                if (textBox_timKiem.Text == "")
                {
                    var timkiem = _nhanVienService.GetNhanVienFromDB().Where(p => p.TrangThai == false
                                                                              && p.IdChucVu == _chucVuService.GetChucVuFromDB()[cbb_chucvu.SelectedIndex].IdChucVu);
                    dgv_nhanvien.Rows.Clear();
                    foreach (var item in timkiem)
                    {
                        dgv_nhanvien.Rows.Add(item.MaNhanVien, item.TenNhanVien, item.SDT, item.Gmail, item.DiaChi, item.GioiTinh == 1 ? "Nam" : "Nữ",
                            _chucVuService.GetChucVuFromDB().Where(p => p.IdChucVu == item.IdChucVu).Select(p => p.TenCV).FirstOrDefault(),
                            item.TrangThai == true ? "Hoạt Động" : "Không hoạt động",
                            item.NgaySinh.ToString("dd-MM-yyyy"));
                    }
                }
            }

            if (cbb_locTrangThai.Text == "Hoạt Động" && cbb_locChucVu.Text == "")
            {
                if (textBox_timKiem.Text != "")
                {
                    var timkiem = _nhanVienService.GetNhanVienFromDB().Where(p => p.TrangThai == true
                                                                              && p.TenNhanVien.Contains(textBox_timKiem.Text));
                    dgv_nhanvien.Rows.Clear();
                    foreach (var item in timkiem)
                    {
                        dgv_nhanvien.Rows.Add(item.MaNhanVien, item.TenNhanVien, item.SDT, item.Gmail, item.DiaChi, item.GioiTinh == 1 ? "Nam" : "Nữ",
                            _chucVuService.GetChucVuFromDB().Where(p => p.IdChucVu == item.IdChucVu).Select(p => p.TenCV).FirstOrDefault(),
                            item.TrangThai == true ? "Hoạt Động" : "Không hoạt động",
                            item.NgaySinh.ToString("dd-MM-yyyy"));
                    }
                }
                if (textBox_timKiem.Text == "")
                {
                    var timkiem = _nhanVienService.GetNhanVienFromDB().Where(p => p.TrangThai == true);
                    dgv_nhanvien.Rows.Clear();
                    foreach (var item in timkiem)
                    {
                        dgv_nhanvien.Rows.Add(item.MaNhanVien, item.TenNhanVien, item.SDT, item.Gmail, item.DiaChi, item.GioiTinh == 1 ? "Nam" : "Nữ",
                            _chucVuService.GetChucVuFromDB().Where(p => p.IdChucVu == item.IdChucVu).Select(p => p.TenCV).FirstOrDefault(),
                            item.TrangThai == true ? "Hoạt Động" : "Không hoạt động",
                            item.NgaySinh.ToString("dd-MM-yyyy"));
                    }
                }
            }
            if (cbb_locTrangThai.Text == "Không hoạt Động" && cbb_locChucVu.Text == "")
            {
                if (textBox_timKiem.Text != "")
                {
                    var timkiem = _nhanVienService.GetNhanVienFromDB().Where(p => p.TrangThai == false
                                                                              && p.TenNhanVien.Contains(textBox_timKiem.Text));
                    dgv_nhanvien.Rows.Clear();
                    foreach (var item in timkiem)
                    {
                        dgv_nhanvien.Rows.Add(item.MaNhanVien, item.TenNhanVien, item.SDT, item.Gmail, item.DiaChi, item.GioiTinh == 1 ? "Nam" : "Nữ",
                            _chucVuService.GetChucVuFromDB().Where(p => p.IdChucVu == item.IdChucVu).Select(p => p.TenCV).FirstOrDefault(),
                            item.TrangThai == true ? "Hoạt Động" : "Không hoạt động",
                            item.NgaySinh.ToString("dd-MM-yyyy"));
                    }
                }
                if (textBox_timKiem.Text == "")
                {
                    var timkiem = _nhanVienService.GetNhanVienFromDB().Where(p => p.TrangThai == false);
                    dgv_nhanvien.Rows.Clear();
                    foreach (var item in timkiem)
                    {
                        dgv_nhanvien.Rows.Add(item.MaNhanVien, item.TenNhanVien, item.SDT, item.Gmail, item.DiaChi, item.GioiTinh == 1 ? "Nam" : "Nữ",
                            _chucVuService.GetChucVuFromDB().Where(p => p.IdChucVu == item.IdChucVu).Select(p => p.TenCV).FirstOrDefault(),
                            item.TrangThai == true ? "Hoạt Động" : "Không hoạt động",
                            item.NgaySinh.ToString("dd-MM-yyyy"));
                    }
                }

            }
        }

        private void cbb_locChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (textBox_timKiem.Text == "")
            {

                var timkiem = _nhanVienService.GetNhanVienFromDB().Where(p => p.IdChucVu == _chucVuService.GetChucVuFromDB()[cbb_chucvu.SelectedIndex].IdChucVu);

                dgv_nhanvien.Rows.Clear();
                foreach (var item in timkiem)
                {
                    dgv_nhanvien.Rows.Add(item.MaNhanVien, item.TenNhanVien, item.SDT, item.Gmail, item.DiaChi, item.GioiTinh == 1 ? "Nam" : "Nữ",
                            _chucVuService.GetChucVuFromDB().Where(p => p.IdChucVu == item.IdChucVu).Select(p => p.TenCV).FirstOrDefault(),
                            item.TrangThai == true ? "Hoạt Động" : "Không hoạt động",
                            item.NgaySinh.ToString("dd-MM-yyyy"));
                }
            }
            if (textBox_timKiem.Text != "")
            {
                var timkiem = _nhanVienService.GetNhanVienFromDB().Where(p => p.IdChucVu == _chucVuService.GetChucVuFromDB()[cbb_chucvu.SelectedIndex].IdChucVu && p.TenNhanVien.Contains(textBox_timKiem.Text));

                dgv_nhanvien.Rows.Clear();
                foreach (var item in timkiem)
                {
                    dgv_nhanvien.Rows.Add(item.MaNhanVien, item.TenNhanVien, item.SDT, item.Gmail, item.DiaChi, item.GioiTinh == 1 ? "Nam" : "Nữ",
                            _chucVuService.GetChucVuFromDB().Where(p => p.IdChucVu == item.IdChucVu).Select(p => p.TenCV).FirstOrDefault(),
                            item.TrangThai == true ? "Hoạt Động" : "Không hoạt động",
                            item.NgaySinh.ToString("dd-MM-yyyy"));
                }
            }
        }

        private void button_rset_Click(object sender, EventArgs e)
        {
            loadNhanVien();
            cbb_locChucVu.Text = "";
            cbb_locTrangThai.Text = "";
            textBox_timKiem.Text = "";
            tbt_MaNV.Text = "";
            tbt_tenNV.Text = "";
            tbt_sdt.Text = "";
            tbt_Email.Text = "";
            tbt_diachi.Text = "";
        }
    }
}
