using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using _2.BUS.IServices;
using _2.BUS.Services;
using System.Net.Mail;
using System.Net;

namespace _3.PL
{
    public partial class FrmQuenMK : Form
    {
        private INhanVienService _nhanvienService;
        private static Random random = new Random();
        public FrmQuenMK()
        {
            _nhanvienService = new NhanVienService();
            InitializeComponent();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
        private void MailSendThuGmail(string email, string pw)
        {
            MailAddress fromAddress = new MailAddress("buiminhquang332003@gmail.com", "Quản lí");
            MailAddress toAddress = new MailAddress(email, "Nhân viên");
            const string subject = "Reset mật khẩu App BarMart";
            string body = @"Bạn đã yêu cầu đổi mật khẩu. Mật khẩu mới của bạn là: <b>" + pw + "</b>";

            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage(fromAddress.Address, toAddress.Address, subject, body);
            msg.IsBodyHtml = true;

            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("buiminhquang332003@gmail.com", "rrczdxiqsvmgctvv"),
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false
                
            };
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            try
            {
                client.Send(msg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_LayMK_Click(object sender, EventArgs e)
        {
            var em = _nhanvienService.GetNhanVienFromDB().FirstOrDefault(x => x.Gmail == tbt_Email.Text && x.SDT == tbt_Sdt.Text);
            if(tbt_Email.Text != "")
            {
                if (em == null)
                {
                    MessageBox.Show("Khum tìm thấy email trùng khớp. Vui lòng kiểm tra lại");
                }
                else
                {
                    string random = RandomString(6);
                    em.MatKhau = random;
                    _nhanvienService.UpdateNhanVien(em);
                    MailSendThuGmail(tbt_Email.Text, random);
                    MessageBox.Show($"Reset mật khẩu thành công đến {tbt_Email.Text}. Vui lòng kiểm tra email");
                    //MessageBox.Show($"Reset mật khẩu thành công: {random}");
                    this.Close();
                }
            }
            else if(tbt_Email.Text != "" && tbt_Sdt.Text != "")
            {
                string random = RandomString(6);
                em.MatKhau = random;
                _nhanvienService.UpdateNhanVien(em);
                MessageBox.Show($"Mật khẩu mới của bạn là {random}");
                this.Close();
            }
            else
            {
                MessageBox.Show("Không được để trống gmail và số điện thoại");
            }
            //if (em == null)
            //{
            //    MessageBox.Show("Khum tìm thấy email và số điện thoại trùng khớp. Vui lòng kiểm tra lại");
            //}
            //else
            //{
            //    string random = RandomString(1);
            //    em.MatKhau = random;
            //    _nhanvienService.UpdateNhanVien(em);
            //    MailSendThuGmail(tbt_Email.Text, random);
            //    MessageBox.Show($"Reset mật khẩu thành công đến {tbt_Email.Text}. Vui lòng kiểm tra email");
                
            //    //MessageBox.Show($"Reset mật khẩu thành công: {random}");
            //    this.Close();
            //}
        }
    }
}
