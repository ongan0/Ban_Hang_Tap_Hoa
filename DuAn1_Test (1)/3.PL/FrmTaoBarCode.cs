using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace _3.PL
{
    public partial class FrmTaoBarCode : Form
    {
        public FrmTaoBarCode()
        {
            InitializeComponent();
        }

        private void btn_Tao_Click(object sender, EventArgs e)
        {
            BarcodeLib.Barcode barcode = new BarcodeLib.Barcode();
            Image img = barcode.Encode(BarcodeLib.TYPE.UPCA, tbt_BarCode.Text, Color.Black,Color.White);
            pictureBox1.Image = img;
        }
    }
}
