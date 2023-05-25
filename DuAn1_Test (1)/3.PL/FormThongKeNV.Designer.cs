namespace _3.PL
{
    partial class FormThongKeNV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormThongKeNV));
            this.label7 = new System.Windows.Forms.Label();
            this.ptp_excel = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtg_show = new System.Windows.Forms.DataGridView();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cbb_nam = new System.Windows.Forms.ComboBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.cbb_thang = new System.Windows.Forms.ComboBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.cbb_ngay = new System.Windows.Forms.ComboBox();
            this.button_rset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ptp_excel)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_show)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(70, 269);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(156, 28);
            this.label7.TabIndex = 31;
            this.label7.Text = "Xuất File Excel ";
            // 
            // ptp_excel
            // 
            this.ptp_excel.BackColor = System.Drawing.SystemColors.Info;
            this.ptp_excel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ptp_excel.Image = ((System.Drawing.Image)(resources.GetObject("ptp_excel.Image")));
            this.ptp_excel.Location = new System.Drawing.Point(232, 259);
            this.ptp_excel.Name = "ptp_excel";
            this.ptp_excel.Size = new System.Drawing.Size(92, 48);
            this.ptp_excel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptp_excel.TabIndex = 30;
            this.ptp_excel.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtg_show);
            this.groupBox1.ForeColor = System.Drawing.Color.IndianRed;
            this.groupBox1.Location = new System.Drawing.Point(29, 313);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1251, 448);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhân Viên ";
            // 
            // dtg_show
            // 
            this.dtg_show.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_show.Location = new System.Drawing.Point(15, 26);
            this.dtg_show.Name = "dtg_show";
            this.dtg_show.RowHeadersWidth = 51;
            this.dtg_show.RowTemplate.Height = 29;
            this.dtg_show.Size = new System.Drawing.Size(1223, 407);
            this.dtg_show.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cbb_nam);
            this.groupBox6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox6.Location = new System.Drawing.Point(753, 145);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(245, 63);
            this.groupBox6.TabIndex = 27;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Năm ";
            // 
            // cbb_nam
            // 
            this.cbb_nam.FormattingEnabled = true;
            this.cbb_nam.Location = new System.Drawing.Point(35, 26);
            this.cbb_nam.Name = "cbb_nam";
            this.cbb_nam.Size = new System.Drawing.Size(192, 28);
            this.cbb_nam.TabIndex = 2;
            this.cbb_nam.SelectedIndexChanged += new System.EventHandler(this.cbb_nam_SelectedIndexChanged);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.cbb_thang);
            this.groupBox7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox7.Location = new System.Drawing.Point(404, 145);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(231, 63);
            this.groupBox7.TabIndex = 28;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Tháng ";
            // 
            // cbb_thang
            // 
            this.cbb_thang.FormattingEnabled = true;
            this.cbb_thang.Location = new System.Drawing.Point(26, 26);
            this.cbb_thang.Name = "cbb_thang";
            this.cbb_thang.Size = new System.Drawing.Size(182, 28);
            this.cbb_thang.TabIndex = 1;
            this.cbb_thang.SelectedIndexChanged += new System.EventHandler(this.cbb_thang_SelectedIndexChanged);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.cbb_ngay);
            this.groupBox8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox8.Location = new System.Drawing.Point(56, 145);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(243, 63);
            this.groupBox8.TabIndex = 26;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Ngày ";
            // 
            // cbb_ngay
            // 
            this.cbb_ngay.FormattingEnabled = true;
            this.cbb_ngay.Location = new System.Drawing.Point(22, 25);
            this.cbb_ngay.Name = "cbb_ngay";
            this.cbb_ngay.Size = new System.Drawing.Size(200, 28);
            this.cbb_ngay.TabIndex = 0;
            this.cbb_ngay.SelectedIndexChanged += new System.EventHandler(this.cbb_ngay_SelectedIndexChanged);
            // 
            // button_rset
            // 
            this.button_rset.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.button_rset.ForeColor = System.Drawing.Color.White;
            this.button_rset.Image = ((System.Drawing.Image)(resources.GetObject("button_rset.Image")));
            this.button_rset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_rset.Location = new System.Drawing.Point(1076, 168);
            this.button_rset.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_rset.Name = "button_rset";
            this.button_rset.Size = new System.Drawing.Size(111, 33);
            this.button_rset.TabIndex = 32;
            this.button_rset.Text = "Reset";
            this.button_rset.UseVisualStyleBackColor = false;
            this.button_rset.Click += new System.EventHandler(this.button_rset_Click);
            // 
            // FormThongKeNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1415, 777);
            this.Controls.Add(this.button_rset);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ptp_excel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox8);
            this.Name = "FormThongKeNV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormThongKeNV";
            this.Load += new System.EventHandler(this.FormThongKeNV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptp_excel)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_show)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox ptp_excel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dtg_show;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox cbb_nam;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.ComboBox cbb_thang;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.ComboBox cbb_ngay;
        private System.Windows.Forms.Button button_rset;
    }
}