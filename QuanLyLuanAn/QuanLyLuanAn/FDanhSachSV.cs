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
    public partial class FDanhSachSV : Form
    {
        public FDanhSachSV()
        {
            InitializeComponent();
        }

        private void FDanhSachSV_Load(object sender, EventArgs e)
        {
            // Thêm cột mới vào DataGridView

            // Hiển thị dữ liệu
            HienThiDuLieu();
        }

        private void HienThiDuLieu()
        {
            // Khởi tạo đối tượng Bus
            PLyDo lyDoBUS = new PLyDo();
            PNguoiDung nguoiDungBUS = new PNguoiDung();

            // Lấy danh sách người dùng và lý do từ Bus
            List<NguoiDung> danhSachNguoiDung = nguoiDungBUS.LayDanhSach();
            List<LyDo> danhSachLyDo = lyDoBUS.LayDanhSach();

            // Thực hiện kết hợp dữ liệu từ hai danh sách
            foreach (LyDo lyDo in danhSachLyDo)
            {
                // Tìm kiếm thông tin sinh viên tương ứng với lý do
                NguoiDung nguoiDung = danhSachNguoiDung.Find(nd => nd.ID == lyDo.SinhVienID);
                if (nguoiDung != null)
                {
                    // Thêm tên sinh viên vào cột mới của DataGridView
                    int rowIndex = dsKhongDuocDuyet.Rows.Add();
                    dsKhongDuocDuyet.Rows[rowIndex].Cells[0].Value = nguoiDung.HoTen.ToString();
                    dsKhongDuocDuyet.Rows[rowIndex].Cells[1].Value = lyDo.LyDoText.ToString();
                }
            }
        }


    }
}
