using DataLibrary;
using QuanLyLuanAn.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyLuanAn.BUS
{
    public class PHoiDong
    {
        #region CRUD
        public List<HoiDongChamThi> Load()
        {
            try
            {
                using (var db = new DBConnect<HoiDongChamThi>())
                {
                    var HoiDongChamThis = db.LayDanhSach();
                    return HoiDongChamThis.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<HoiDongChamThi>();
            }
        }
        public void Them(HoiDongChamThi HoiDongChamThi)
        {
            try
            {
                using (var db = new DBConnect<HoiDongChamThi>())
                {
                    db.Them(HoiDongChamThi);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CapNhat(HoiDongChamThi HoiDongChamThi)
        {
            try
            {
                using (var db = new DBConnect<HoiDongChamThi>())
                {
                    db.CapNhat(HoiDongChamThi);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Xoa(int id)
        {
            try
            {
                using (var db = new DBConnect<HoiDongChamThi>())
                {
                    db.Xoa(id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region thao tác

        public HoiDongChamThi LayTheoID(int GiangVienID1, int luanVanID)
        {
            HoiDongChamThi hoiDong = new HoiDongChamThi();
            try
            {
                using (var db = new DBConnect<HoiDongChamThi>())
                {
                    var HoiDongChamThis = db.LayDanhSach();
                    
                    hoiDong = HoiDongChamThis.FirstOrDefault(hd => hd.GiangVienID == GiangVienID1 && hd.LuanVanID == luanVanID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return hoiDong;
        }

        public List<HoiDongChamThi> LayDanhSachTheoLuanVanID(int luanVanID)
        {
            try
            {
                using (var db = new DBConnect<HoiDongChamThi>())
                {
                    var HoiDongChamThis = db.LayDanhSach();
                    return HoiDongChamThis.ToList().Where(hd => hd.LuanVanID == luanVanID).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<HoiDongChamThi>();
            }
        }
        #endregion
    }
}
