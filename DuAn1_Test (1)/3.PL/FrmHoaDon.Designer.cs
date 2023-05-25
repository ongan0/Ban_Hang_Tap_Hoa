namespace _3.PL
{
    partial class FrmHoaDon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHoaDon));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtp_NgayKT = new System.Windows.Forms.DateTimePicker();
            this.dtp_NgayBD = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_XuatExcel = new System.Windows.Forms.Button();
            this.btn_XoaHD = new System.Windows.Forms.Button();
            this.btn_timk = new System.Windows.Forms.Button();
            this.dtg_hoadon = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbt_timk = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtg_hoadonchitiet = new System.Windows.Forms.DataGridView();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_rset = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_hoadon)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_hoadonchitiet)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_rset);
            this.groupBox1.Controls.Add(this.dtp_NgayKT);
            this.groupBox1.Controls.Add(this.dtp_NgayBD);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btn_XuatExcel);
            this.groupBox1.Controls.Add(this.btn_XoaHD);
            this.groupBox1.Controls.Add(this.btn_timk);
            this.groupBox1.Controls.Add(this.dtg_hoadon);
            this.groupBox1.Controls.Add(this.tbt_timk);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.Color.IndianRed;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(1193, 479);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hóa đơn";
            // 
            // dtp_NgayKT
            // 
            this.dtp_NgayKT.Location = new System.Drawing.Point(466, 84);
            this.dtp_NgayKT.Name = "dtp_NgayKT";
            this.dtp_NgayKT.Size = new System.Drawing.Size(219, 27);
            this.dtp_NgayKT.TabIndex = 19;
            this.dtp_NgayKT.ValueChanged += new System.EventHandler(this.dtp_NgayKT_ValueChanged);
            // 
            // dtp_NgayBD
            // 
            this.dtp_NgayBD.Location = new System.Drawing.Point(196, 84);
            this.dtp_NgayBD.Name = "dtp_NgayBD";
            this.dtp_NgayBD.Size = new System.Drawing.Size(219, 27);
            this.dtp_NgayBD.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(14, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "Thời gian tạo hóa đơn";
            // 
            // btn_XuatExcel
            // 
            this.btn_XuatExcel.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_XuatExcel.ForeColor = System.Drawing.Color.White;
            this.btn_XuatExcel.Image = ((System.Drawing.Image)(resources.GetObject("btn_XuatExcel.Image")));
            this.btn_XuatExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_XuatExcel.Location = new System.Drawing.Point(873, 29);
            this.btn_XuatExcel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_XuatExcel.Name = "btn_XuatExcel";
            this.btn_XuatExcel.Size = new System.Drawing.Size(184, 44);
            this.btn_XuatExcel.TabIndex = 16;
            this.btn_XuatExcel.Text = "Xuất excel";
            this.btn_XuatExcel.UseVisualStyleBackColor = false;
            this.btn_XuatExcel.Click += new System.EventHandler(this.btn_XuatExcel_Click);
            // 
            // btn_XoaHD
            // 
            this.btn_XoaHD.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_XoaHD.Image = ((System.Drawing.Image)(resources.GetObject("btn_XoaHD.Image")));
            this.btn_XoaHD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_XoaHD.Location = new System.Drawing.Point(1064, 35);
            this.btn_XoaHD.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_XoaHD.Name = "btn_XoaHD";
            this.btn_XoaHD.Size = new System.Drawing.Size(125, 31);
            this.btn_XoaHD.TabIndex = 15;
            this.btn_XoaHD.Text = "Xóa hoá đơn";
            this.btn_XoaHD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_XoaHD.UseVisualStyleBackColor = true;
            this.btn_XoaHD.Click += new System.EventHandler(this.btn_XoaHD_Click);
            // 
            // btn_timk
            // 
            this.btn_timk.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_timk.ForeColor = System.Drawing.Color.White;
            this.btn_timk.Image = ((System.Drawing.Image)(resources.GetObject("btn_timk.Image")));
            this.btn_timk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_timk.Location = new System.Drawing.Point(387, 24);
            this.btn_timk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_timk.Name = "btn_timk";
            this.btn_timk.Size = new System.Drawing.Size(97, 31);
            this.btn_timk.TabIndex = 3;
            this.btn_timk.Text = "Tìm kiếm";
            this.btn_timk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_timk.UseVisualStyleBackColor = false;
            this.btn_timk.Click += new System.EventHandler(this.btn_timk_Click);
            // 
            // dtg_hoadon
            // 
            this.dtg_hoadon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_hoadon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Ma,
            this.Column2,
            this.Column12,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dtg_hoadon.Location = new System.Drawing.Point(7, 137);
            this.dtg_hoadon.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtg_hoadon.Name = "dtg_hoadon";
            this.dtg_hoadon.RowHeadersWidth = 51;
            this.dtg_hoadon.RowTemplate.Height = 25;
            this.dtg_hoadon.Size = new System.Drawing.Size(1179, 334);
            this.dtg_hoadon.TabIndex = 2;
            this.dtg_hoadon.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_hoadon_CellClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ID";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            this.Column1.Width = 125;
            // 
            // Ma
            // 
            this.Ma.HeaderText = "Mã Hóa đơn";
            this.Ma.MinimumWidth = 6;
            this.Ma.Name = "Ma";
            this.Ma.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Ngày Tạo";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 150;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "Ngày thanh toán";
            this.Column12.MinimumWidth = 6;
            this.Column12.Name = "Column12";
            this.Column12.Width = 125;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Email Nhân Viên";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 200;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Số Điện Thoại Khách Hàng";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 170;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Tổng Giá";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 150;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Trạng Thái";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.Width = 130;
            // 
            // tbt_timk
            // 
            this.tbt_timk.Location = new System.Drawing.Point(154, 26);
            this.tbt_timk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbt_timk.Name = "tbt_timk";
            this.tbt_timk.Size = new System.Drawing.Size(217, 27);
            this.tbt_timk.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(14, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tìm kiếm hóa đơn";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtg_hoadonchitiet);
            this.groupBox2.ForeColor = System.Drawing.Color.IndianRed;
            this.groupBox2.Location = new System.Drawing.Point(14, 499);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(1193, 338);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hóa đơn chi tiết";
            // 
            // dtg_hoadonchitiet
            // 
            this.dtg_hoadonchitiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_hoadonchitiet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column8,
            this.Column7,
            this.Column9,
            this.Column10,
            this.Column11});
            this.dtg_hoadonchitiet.Location = new System.Drawing.Point(15, 34);
            this.dtg_hoadonchitiet.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtg_hoadonchitiet.Name = "dtg_hoadonchitiet";
            this.dtg_hoadonchitiet.RowHeadersWidth = 51;
            this.dtg_hoadonchitiet.RowTemplate.Height = 25;
            this.dtg_hoadonchitiet.Size = new System.Drawing.Size(687, 287);
            this.dtg_hoadonchitiet.TabIndex = 4;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "ID";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            this.Column8.Visible = false;
            this.Column8.Width = 150;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Mã Sản Phẩm";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.Width = 125;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Tên Sản Phẩm";
            this.Column9.MinimumWidth = 6;
            this.Column9.Name = "Column9";
            this.Column9.Width = 150;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Số Lượng";
            this.Column10.MinimumWidth = 6;
            this.Column10.Name = "Column10";
            this.Column10.Width = 125;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Đơn Giá";
            this.Column11.MinimumWidth = 6;
            this.Column11.Name = "Column11";
            this.Column11.Width = 125;
            // 
            // button_rset
            // 
            this.button_rset.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.button_rset.ForeColor = System.Drawing.Color.White;
            this.button_rset.Image = ((System.Drawing.Image)(resources.GetObject("button_rset.Image")));
            this.button_rset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_rset.Location = new System.Drawing.Point(731, 81);
            this.button_rset.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_rset.Name = "button_rset";
            this.button_rset.Size = new System.Drawing.Size(111, 33);
            this.button_rset.TabIndex = 20;
            this.button_rset.Text = "Reset";
            this.button_rset.UseVisualStyleBackColor = false;
            this.button_rset.Click += new System.EventHandler(this.button_rset_Click);
            // 
            // FrmHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1221, 845);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmHoaDon";
            this.Text = "FrmHoaDon";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_hoadon)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_hoadonchitiet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_XoaHD;
        private System.Windows.Forms.Button btn_timk;
        private System.Windows.Forms.DataGridView dtg_hoadon;
        private System.Windows.Forms.TextBox tbt_timk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dtg_hoadonchitiet;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.Button btn_XuatExcel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ma;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DateTimePicker dtp_NgayKT;
        private System.Windows.Forms.DateTimePicker dtp_NgayBD;
        private System.Windows.Forms.Button button_rset;
    }
}