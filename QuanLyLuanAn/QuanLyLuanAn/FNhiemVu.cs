
using DataLibrary;
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
    public partial class FNhiemVu : Form
    {
        public FNhiemVu()
        {
            InitializeComponent();
        }

        private void LoadUCDeTai(List<NhiemVu> danhSachNhiemVu)
        {
            flpNhiemVu.Controls.Clear();
            foreach (NhiemVu deTai in danhSachNhiemVu)
            {
                UCNhiemVu uc = new UCNhiemVu(deTai);
                //uc.HienThiUCThaoTac += ;
                //uc.LoadLaiForm += FDanhSachDeTai_Load;
                flpNhiemVu.Controls.Add(uc);
            }
        }
        //private void dgvDangThucHien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Kiểm tra xem người dùng đã chọn một ô hợp lệ chưa
        //    {
        //        if (dgvDangThucHien.Columns[e.ColumnIndex].Name == "MaDeTai") // Kiểm tra xem ô được chọn có phải là cột "MaDeTai" không
        //        {
        //            string maDeTai = dgvDangThucHien.Rows[e.RowIndex].Cells["MaDeTai"].Value.ToString();
        //            HoTro.nhiemVu = bUS_NhiemVu.LayNhiemVuTheoMaDeTai(maDeTai);
        //            DialogResult result = ShowCustomMessageBox("Bạn muốn thực hiện thao tác nào?", "Xác nhận");
        //            if (result == DialogResult.Yes)
        //            {
        //                HoTro.chucNang = "Xóa";
        //            }
        //            else if (result == DialogResult.No)
        //            {
        //                HoTro.chucNang = "Sửa";
        //            }
        //            else if (result == DialogResult.Cancel)
        //            {

        //            }
        //            else if (result == DialogResult.Retry)
        //            {
        //                HoTro.chucNang = "Nộp";
        //            }

        //            FThaoTacNhiemVu form = new FThaoTacNhiemVu();
        //            form.Show();
        //        }
        //    }
        //}
        private DialogResult ShowCustomMessageBox(string message, string caption)
        {
            // Tạo một hộp thoại tùy chỉnh
            Form customMessageBox = new Form();
            customMessageBox.Text = caption;
            customMessageBox.Size = new Size(300, 150);
            customMessageBox.StartPosition = FormStartPosition.CenterParent;

            // Tạo các nút "Cập nhật", "Sửa" và "Nộp bài"
            Button btnCapNhat = new Button();
            btnCapNhat.Text = "Cập nhật";
            btnCapNhat.DialogResult = DialogResult.Yes;
            btnCapNhat.Location = new Point(30, 50);
            btnCapNhat.Click += (sender, e) => { customMessageBox.DialogResult = DialogResult.Yes; customMessageBox.Close(); };

            Button btnSua = new Button();
            btnSua.Text = "Sửa";
            btnSua.DialogResult = DialogResult.No;
            btnSua.Location = new Point(110, 50);
            btnSua.Click += (sender, e) => { customMessageBox.DialogResult = DialogResult.No; customMessageBox.Close(); };

            Button btnNopBai = new Button();
            btnNopBai.Text = "Nộp bài";
            btnNopBai.DialogResult = DialogResult.Retry;
            btnNopBai.Location = new Point(190, 50);
            btnNopBai.Click += (sender, e) => { customMessageBox.DialogResult = DialogResult.Retry; customMessageBox.Close(); };

            // Thêm các nút vào hộp thoại
            customMessageBox.Controls.Add(btnCapNhat);
            customMessageBox.Controls.Add(btnSua);
            customMessageBox.Controls.Add(btnNopBai);

            // Thêm Label hiển thị thông điệp
            Label labelMessage = new Label();
            labelMessage.Text = message;
            labelMessage.Location = new Point(30, 20);
            labelMessage.AutoSize = true;
            customMessageBox.Controls.Add(labelMessage);

            // Hiển thị hộp thoại và trả về kết quả
            return customMessageBox.ShowDialog();
        }

        private void FNhiemVu_Load(object sender, EventArgs e)
        {
            PNhiemVu nhiemVuBUS = new PNhiemVu();
            List<NhiemVu> nhiemVus = nhiemVuBUS.LayDanhSachNhiemVu();
            LoadUCDeTai(nhiemVus);
        }
    }
}
