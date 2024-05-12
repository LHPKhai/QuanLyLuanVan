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
    public partial class FThongBao : Form
    {
        public FThongBao(string yeucau, bool textbox = false)
        {
            InitializeComponent();
            lblThongBao.Text = yeucau;
            if (textbox)
            {
                txtGiaTri.Visible = true;
            }
        }

        public string Return()
        {
            return txtGiaTri.Text;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
