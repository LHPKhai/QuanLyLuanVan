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
    public partial class UCTNNhan : UserControl
    {
        public UCTNNhan()
        {
            InitializeComponent();
        }
        public UCTNNhan(string text)
        {
            InitializeComponent();
            labelNhan.Text = text;
        }
    }
}
