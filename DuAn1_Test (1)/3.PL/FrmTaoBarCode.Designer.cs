namespace _3.PL
{
    partial class FrmTaoBarCode
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
            this.tbt_BarCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Tao = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbt_BarCode
            // 
            this.tbt_BarCode.Location = new System.Drawing.Point(226, 46);
            this.tbt_BarCode.Name = "tbt_BarCode";
            this.tbt_BarCode.Size = new System.Drawing.Size(369, 27);
            this.tbt_BarCode.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Nội dung BarCode: ";
            // 
            // btn_Tao
            // 
            this.btn_Tao.Location = new System.Drawing.Point(261, 85);
            this.btn_Tao.Name = "btn_Tao";
            this.btn_Tao.Size = new System.Drawing.Size(169, 33);
            this.btn_Tao.TabIndex = 7;
            this.btn_Tao.Text = "Tạo BarCode";
            this.btn_Tao.UseVisualStyleBackColor = true;
            this.btn_Tao.Click += new System.EventHandler(this.btn_Tao_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(81, 130);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(514, 183);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // FrmTaoBarCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 375);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_Tao);
            this.Controls.Add(this.tbt_BarCode);
            this.Controls.Add(this.label2);
            this.Name = "FrmTaoBarCode";
            this.Text = "FrmTaoBarCode";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbt_BarCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Tao;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}