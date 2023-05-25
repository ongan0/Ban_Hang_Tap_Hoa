namespace _3.PL
{
    partial class FrmMenuNv
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenuNv));
            this.panel_Left = new System.Windows.Forms.Panel();
            this.btn_DangXuat = new System.Windows.Forms.Button();
            this.btn_KhachHang = new System.Windows.Forms.Button();
            this.btn_HoaDon = new System.Windows.Forms.Button();
            this.btn_BanHang = new System.Windows.Forms.Button();
            this.lb_ChucVu = new System.Windows.Forms.Label();
            this.lb_TenDn = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_DoiMk = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tbt_XacNhanMK = new System.Windows.Forms.TextBox();
            this.tbt_MkMoi = new System.Windows.Forms.TextBox();
            this.tbt_Mk = new System.Windows.Forms.TextBox();
            this.lb_Ngay = new System.Windows.Forms.Label();
            this.lb_Gio = new System.Windows.Forms.Label();
            this.panel_Body = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lb_Email = new System.Windows.Forms.Label();
            this.lb_DiaChi = new System.Windows.Forms.Label();
            this.lb_Sdt = new System.Windows.Forms.Label();
            this.lb_GioiTinh = new System.Windows.Forms.Label();
            this.lb_TenNv = new System.Windows.Forms.Label();
            this.lb_MaNv = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.sqlConnection1 = new Microsoft.Data.SqlClient.SqlConnection();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel_Top = new System.Windows.Forms.Panel();
            this.lb_TenTrang = new System.Windows.Forms.Label();
            this.panel_Left.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel_Body.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel_Top.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Left
            // 
            this.panel_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.panel_Left.Controls.Add(this.btn_DangXuat);
            this.panel_Left.Controls.Add(this.btn_KhachHang);
            this.panel_Left.Controls.Add(this.btn_HoaDon);
            this.panel_Left.Controls.Add(this.btn_BanHang);
            this.panel_Left.Controls.Add(this.lb_ChucVu);
            this.panel_Left.Controls.Add(this.lb_TenDn);
            this.panel_Left.Controls.Add(this.pictureBox1);
            this.panel_Left.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_Left.Location = new System.Drawing.Point(0, 0);
            this.panel_Left.Name = "panel_Left";
            this.panel_Left.Size = new System.Drawing.Size(200, 1055);
            this.panel_Left.TabIndex = 1;
            // 
            // btn_DangXuat
            // 
            this.btn_DangXuat.FlatAppearance.BorderSize = 0;
            this.btn_DangXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DangXuat.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_DangXuat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btn_DangXuat.Image = ((System.Drawing.Image)(resources.GetObject("btn_DangXuat.Image")));
            this.btn_DangXuat.Location = new System.Drawing.Point(2, 1003);
            this.btn_DangXuat.Name = "btn_DangXuat";
            this.btn_DangXuat.Size = new System.Drawing.Size(194, 45);
            this.btn_DangXuat.TabIndex = 14;
            this.btn_DangXuat.Text = "Đăng xuất";
            this.btn_DangXuat.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_DangXuat.UseVisualStyleBackColor = true;
            this.btn_DangXuat.Click += new System.EventHandler(this.btn_DangXuat_Click);
            // 
            // btn_KhachHang
            // 
            this.btn_KhachHang.FlatAppearance.BorderSize = 0;
            this.btn_KhachHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_KhachHang.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_KhachHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btn_KhachHang.Image = ((System.Drawing.Image)(resources.GetObject("btn_KhachHang.Image")));
            this.btn_KhachHang.Location = new System.Drawing.Point(3, 260);
            this.btn_KhachHang.Name = "btn_KhachHang";
            this.btn_KhachHang.Size = new System.Drawing.Size(194, 45);
            this.btn_KhachHang.TabIndex = 10;
            this.btn_KhachHang.Text = "Khách hàng";
            this.btn_KhachHang.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_KhachHang.UseVisualStyleBackColor = true;
            this.btn_KhachHang.Click += new System.EventHandler(this.btn_KhachHang_Click);
            // 
            // btn_HoaDon
            // 
            this.btn_HoaDon.FlatAppearance.BorderSize = 0;
            this.btn_HoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_HoaDon.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_HoaDon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btn_HoaDon.Image = ((System.Drawing.Image)(resources.GetObject("btn_HoaDon.Image")));
            this.btn_HoaDon.Location = new System.Drawing.Point(3, 202);
            this.btn_HoaDon.Name = "btn_HoaDon";
            this.btn_HoaDon.Size = new System.Drawing.Size(194, 45);
            this.btn_HoaDon.TabIndex = 9;
            this.btn_HoaDon.Text = "Hóa đơn";
            this.btn_HoaDon.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_HoaDon.UseVisualStyleBackColor = true;
            this.btn_HoaDon.Click += new System.EventHandler(this.btn_HoaDon_Click);
            // 
            // btn_BanHang
            // 
            this.btn_BanHang.FlatAppearance.BorderSize = 0;
            this.btn_BanHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_BanHang.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_BanHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btn_BanHang.Image = global::_3.PL.Properties.Resources.shopping_cart__2_;
            this.btn_BanHang.Location = new System.Drawing.Point(3, 145);
            this.btn_BanHang.Name = "btn_BanHang";
            this.btn_BanHang.Size = new System.Drawing.Size(194, 45);
            this.btn_BanHang.TabIndex = 3;
            this.btn_BanHang.Text = "Bán hàng";
            this.btn_BanHang.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_BanHang.UseVisualStyleBackColor = true;
            this.btn_BanHang.Click += new System.EventHandler(this.btn_BanHang_Click);
            // 
            // lb_ChucVu
            // 
            this.lb_ChucVu.AutoSize = true;
            this.lb_ChucVu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lb_ChucVu.ForeColor = System.Drawing.Color.White;
            this.lb_ChucVu.Location = new System.Drawing.Point(61, 98);
            this.lb_ChucVu.Name = "lb_ChucVu";
            this.lb_ChucVu.Size = new System.Drawing.Size(65, 20);
            this.lb_ChucVu.TabIndex = 2;
            this.lb_ChucVu.Text = "Chức vụ ";
            // 
            // lb_TenDn
            // 
            this.lb_TenDn.AutoSize = true;
            this.lb_TenDn.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lb_TenDn.ForeColor = System.Drawing.Color.White;
            this.lb_TenDn.Location = new System.Drawing.Point(42, 72);
            this.lb_TenDn.Name = "lb_TenDn";
            this.lb_TenDn.Size = new System.Drawing.Size(65, 23);
            this.lb_TenDn.TabIndex = 1;
            this.lb_TenDn.Text = "Tên NV";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(68, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(65, 66);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(268, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(801, 41);
            this.label3.TabIndex = 4;
            this.label3.Text = "Chào mừng bạn đến với phần mềm bán hàng của chúng tôi.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(1309, 874);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 25);
            this.label4.TabIndex = 17;
            this.label4.Text = "Nhà phát hành: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(1453, 874);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 25);
            this.label5.TabIndex = 18;
            this.label5.Text = "Nhóm Bar";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_DoiMk);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.tbt_XacNhanMK);
            this.groupBox2.Controls.Add(this.tbt_MkMoi);
            this.groupBox2.Controls.Add(this.tbt_Mk);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(797, 244);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(568, 396);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Đổi mật khẩu";
            // 
            // btn_DoiMk
            // 
            this.btn_DoiMk.ForeColor = System.Drawing.Color.Black;
            this.btn_DoiMk.Location = new System.Drawing.Point(179, 287);
            this.btn_DoiMk.Name = "btn_DoiMk";
            this.btn_DoiMk.Size = new System.Drawing.Size(211, 32);
            this.btn_DoiMk.TabIndex = 55;
            this.btn_DoiMk.Text = "Đổi mật khẩu";
            this.btn_DoiMk.UseVisualStyleBackColor = true;
            this.btn_DoiMk.Click += new System.EventHandler(this.btn_DoiMk_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(37, 181);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(177, 28);
            this.label16.TabIndex = 54;
            this.label16.Text = "Xác nhận mật khẩu";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(37, 124);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(133, 28);
            this.label15.TabIndex = 53;
            this.label15.Text = "Mật khẩu mới";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(37, 65);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(119, 28);
            this.label14.TabIndex = 49;
            this.label14.Text = "Mật khẩu củ";
            // 
            // tbt_XacNhanMK
            // 
            this.tbt_XacNhanMK.Location = new System.Drawing.Point(288, 181);
            this.tbt_XacNhanMK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbt_XacNhanMK.Name = "tbt_XacNhanMK";
            this.tbt_XacNhanMK.Size = new System.Drawing.Size(214, 34);
            this.tbt_XacNhanMK.TabIndex = 52;
            // 
            // tbt_MkMoi
            // 
            this.tbt_MkMoi.Location = new System.Drawing.Point(288, 117);
            this.tbt_MkMoi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbt_MkMoi.Name = "tbt_MkMoi";
            this.tbt_MkMoi.Size = new System.Drawing.Size(214, 34);
            this.tbt_MkMoi.TabIndex = 51;
            // 
            // tbt_Mk
            // 
            this.tbt_Mk.Location = new System.Drawing.Point(288, 62);
            this.tbt_Mk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbt_Mk.Name = "tbt_Mk";
            this.tbt_Mk.Size = new System.Drawing.Size(214, 34);
            this.tbt_Mk.TabIndex = 50;
            // 
            // lb_Ngay
            // 
            this.lb_Ngay.AutoSize = true;
            this.lb_Ngay.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lb_Ngay.ForeColor = System.Drawing.Color.White;
            this.lb_Ngay.Location = new System.Drawing.Point(210, 131);
            this.lb_Ngay.Name = "lb_Ngay";
            this.lb_Ngay.Size = new System.Drawing.Size(79, 29);
            this.lb_Ngay.TabIndex = 23;
            this.lb_Ngay.Text = "label9";
            // 
            // lb_Gio
            // 
            this.lb_Gio.AutoSize = true;
            this.lb_Gio.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lb_Gio.ForeColor = System.Drawing.Color.White;
            this.lb_Gio.Location = new System.Drawing.Point(66, 131);
            this.lb_Gio.Name = "lb_Gio";
            this.lb_Gio.Size = new System.Drawing.Size(79, 29);
            this.lb_Gio.TabIndex = 24;
            this.lb_Gio.Text = "label9";
            // 
            // panel_Body
            // 
            this.panel_Body.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel_Body.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.panel_Body.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_Body.Controls.Add(this.groupBox1);
            this.panel_Body.Controls.Add(this.lb_Gio);
            this.panel_Body.Controls.Add(this.lb_Ngay);
            this.panel_Body.Controls.Add(this.groupBox2);
            this.panel_Body.Controls.Add(this.label5);
            this.panel_Body.Controls.Add(this.label4);
            this.panel_Body.Controls.Add(this.label3);
            this.panel_Body.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel_Body.Location = new System.Drawing.Point(202, 111);
            this.panel_Body.Name = "panel_Body";
            this.panel_Body.Size = new System.Drawing.Size(1585, 928);
            this.panel_Body.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lb_Email);
            this.groupBox1.Controls.Add(this.lb_DiaChi);
            this.groupBox1.Controls.Add(this.lb_Sdt);
            this.groupBox1.Controls.Add(this.lb_GioiTinh);
            this.groupBox1.Controls.Add(this.lb_TenNv);
            this.groupBox1.Controls.Add(this.lb_MaNv);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(66, 244);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(673, 396);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // lb_Email
            // 
            this.lb_Email.AutoSize = true;
            this.lb_Email.ForeColor = System.Drawing.Color.White;
            this.lb_Email.Location = new System.Drawing.Point(500, 130);
            this.lb_Email.Name = "lb_Email";
            this.lb_Email.Size = new System.Drawing.Size(152, 28);
            this.lb_Email.TabIndex = 59;
            this.lb_Email.Text = "...................................";
            // 
            // lb_DiaChi
            // 
            this.lb_DiaChi.AutoSize = true;
            this.lb_DiaChi.ForeColor = System.Drawing.Color.White;
            this.lb_DiaChi.Location = new System.Drawing.Point(500, 179);
            this.lb_DiaChi.Name = "lb_DiaChi";
            this.lb_DiaChi.Size = new System.Drawing.Size(152, 28);
            this.lb_DiaChi.TabIndex = 58;
            this.lb_DiaChi.Text = "...................................";
            // 
            // lb_Sdt
            // 
            this.lb_Sdt.AutoSize = true;
            this.lb_Sdt.ForeColor = System.Drawing.Color.White;
            this.lb_Sdt.Location = new System.Drawing.Point(501, 77);
            this.lb_Sdt.Name = "lb_Sdt";
            this.lb_Sdt.Size = new System.Drawing.Size(152, 28);
            this.lb_Sdt.TabIndex = 57;
            this.lb_Sdt.Text = "...................................";
            // 
            // lb_GioiTinh
            // 
            this.lb_GioiTinh.AutoSize = true;
            this.lb_GioiTinh.ForeColor = System.Drawing.Color.White;
            this.lb_GioiTinh.Location = new System.Drawing.Point(169, 181);
            this.lb_GioiTinh.Name = "lb_GioiTinh";
            this.lb_GioiTinh.Size = new System.Drawing.Size(152, 28);
            this.lb_GioiTinh.TabIndex = 56;
            this.lb_GioiTinh.Text = "...................................";
            // 
            // lb_TenNv
            // 
            this.lb_TenNv.AutoSize = true;
            this.lb_TenNv.ForeColor = System.Drawing.Color.White;
            this.lb_TenNv.Location = new System.Drawing.Point(171, 130);
            this.lb_TenNv.Name = "lb_TenNv";
            this.lb_TenNv.Size = new System.Drawing.Size(152, 28);
            this.lb_TenNv.TabIndex = 55;
            this.lb_TenNv.Text = "...................................";
            // 
            // lb_MaNv
            // 
            this.lb_MaNv.AutoSize = true;
            this.lb_MaNv.ForeColor = System.Drawing.Color.White;
            this.lb_MaNv.Location = new System.Drawing.Point(172, 76);
            this.lb_MaNv.Name = "lb_MaNv";
            this.lb_MaNv.Size = new System.Drawing.Size(152, 28);
            this.lb_MaNv.TabIndex = 54;
            this.lb_MaNv.Text = "...................................";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(32, 181);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 28);
            this.label9.TabIndex = 53;
            this.label9.Text = "Giới tính: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(32, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 28);
            this.label7.TabIndex = 52;
            this.label7.Text = "Mã nhân viên: ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(366, 77);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(137, 28);
            this.label10.TabIndex = 46;
            this.label10.Text = "Số điện thoại: ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(366, 181);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 28);
            this.label11.TabIndex = 45;
            this.label11.Text = "Địa chỉ:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(32, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 28);
            this.label6.TabIndex = 44;
            this.label6.Text = "Tên nhân viên:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(366, 132);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 28);
            this.label8.TabIndex = 43;
            this.label8.Text = "Email: ";
            // 
            // sqlConnection1
            // 
            this.sqlConnection1.AccessToken = null;
            this.sqlConnection1.Credential = null;
            this.sqlConnection1.FireInfoMessageEventOnUserErrors = false;
            this.sqlConnection1.StatisticsEnabled = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel_Top
            // 
            this.panel_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.panel_Top.Controls.Add(this.lb_TenTrang);
            this.panel_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Top.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel_Top.Location = new System.Drawing.Point(200, 0);
            this.panel_Top.Name = "panel_Top";
            this.panel_Top.Size = new System.Drawing.Size(1640, 110);
            this.panel_Top.TabIndex = 4;
            // 
            // lb_TenTrang
            // 
            this.lb_TenTrang.AutoSize = true;
            this.lb_TenTrang.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lb_TenTrang.ForeColor = System.Drawing.Color.White;
            this.lb_TenTrang.Location = new System.Drawing.Point(40, 46);
            this.lb_TenTrang.Name = "lb_TenTrang";
            this.lb_TenTrang.Size = new System.Drawing.Size(100, 28);
            this.lb_TenTrang.TabIndex = 3;
            this.lb_TenTrang.Text = "Trang chủ";
            // 
            // FrmMenuNv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1840, 1055);
            this.Controls.Add(this.panel_Top);
            this.Controls.Add(this.panel_Body);
            this.Controls.Add(this.panel_Left);
            this.Name = "FrmMenuNv";
            this.Text = "FrmMenuNv";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMenuNv_Load);
            this.panel_Left.ResumeLayout(false);
            this.panel_Left.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel_Body.ResumeLayout(false);
            this.panel_Body.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel_Top.ResumeLayout(false);
            this.panel_Top.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Left;
        private System.Windows.Forms.Button btn_DangXuat;
        private System.Windows.Forms.Button btn_KhachHang;
        private System.Windows.Forms.Button btn_HoaDon;
        private System.Windows.Forms.Button btn_BanHang;
        private System.Windows.Forms.Label lb_ChucVu;
        private System.Windows.Forms.Label lb_TenDn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_DoiMk;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbt_XacNhanMK;
        private System.Windows.Forms.TextBox tbt_MkMoi;
        private System.Windows.Forms.TextBox tbt_Mk;
        private System.Windows.Forms.Label lb_Ngay;
        private System.Windows.Forms.Label lb_Gio;
        private System.Windows.Forms.Panel panel_Body;
        private Microsoft.Data.SqlClient.SqlConnection sqlConnection1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel_Top;
        private System.Windows.Forms.Label lb_TenTrang;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lb_Email;
        private System.Windows.Forms.Label lb_DiaChi;
        private System.Windows.Forms.Label lb_Sdt;
        private System.Windows.Forms.Label lb_GioiTinh;
        private System.Windows.Forms.Label lb_TenNv;
        private System.Windows.Forms.Label lb_MaNv;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
    }
}