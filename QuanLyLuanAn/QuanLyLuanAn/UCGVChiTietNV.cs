using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyLuanAn
{
    public partial class UCGVChiTietNV : UserControl
    {
        public UCGVChiTietNV()
        {
            InitializeComponent();
        }

        private void guna2TrackBar1_Scroll(object sender, ScrollEventArgs e)
        {
            guna2TextBox3.Text = guna2TrackBar1.Value.ToString() + "%";
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
