using DataLibrary;
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
    public partial class UCSVKoDuyet : UserControl
    {
        public UCSVKoDuyet(NguoiDung nguoiDung, string lyDo)
        {
            InitializeComponent();
            lblID.Text = nguoiDung.ID.ToString();
            lblLyDo.Text = lyDo;
            lblTen.Text = nguoiDung.HoTen;
        }
    }
}
