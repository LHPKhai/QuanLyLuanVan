﻿using DataLibrary;
using QuanLyLuanAn.BUS;
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
    public partial class FCapNhatThongTInGV : Form
    {
        public FCapNhatThongTInGV(NguoiDung user)
        {
            InitializeComponent();
        }
        #region Phương thức
        private void TruyenDuLieu()
        {
            txtHoTen.Text = Hotro.user.HoTen;
            dtpTime.Value = Hotro.user.NgaySinh.Value;
            txtGioiTinh.Text = Hotro.user.GioiTinh;
            txtSdt.Text = Hotro.user.SoDienThoai;
            txtEmail.Text = Hotro.user.Email;
        }

        private void LayDuLieu()
        {
            Hotro.user.NgaySinh = dtpTime.Value;
            Hotro.user.GioiTinh = txtGioiTinh.Text;
            Hotro.user.SoDienThoai = txtSdt.Text;
            Hotro.user.Email = txtEmail.Text;
        }
        #endregion
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            LayDuLieu();
            PNguoiDung pNguoiDung = new PNguoiDung();
            pNguoiDung.CapNhat(Hotro.user.ID, Hotro.user);
            this.Close();
        }

        private void FCapNhatThongTInGV_Load(object sender, EventArgs e)
        {
            TruyenDuLieu();
        }
    }
}
