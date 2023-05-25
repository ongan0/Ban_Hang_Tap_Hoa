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

namespace _3.PL
{
    public partial class FrmInHoaDon : Form
    {
        HoaDonChiTietService _hoaDonChiTietService;
        HoaDonService _hoaDonService;
        public FrmInHoaDon()
        {
            InitializeComponent();
        }

        private void pictureBoxPrint_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBoxPrint, "Print");
        }

    }
}
