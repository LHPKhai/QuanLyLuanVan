using DataLibrary;
using QuanLyLuanAn.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyLuanAn.BUS
{
    public class PLuanVan
    {   
        #region CRUD
        public List<LuanVan> Load()
        {
            try
            {
                using (var db = new DBConnect<LuanVan>())
                {
                    var luanVans = db.LayDanhSach();
                    return luanVans.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<LuanVan>();
            }
        }
        public void Them(LuanVan luanVan)
        {
            try
            {
                using (var db = new DBConnect<LuanVan>())
                {
                    luanVan.TinhTrang = "Chưa đăng ký";
                    luanVan.Diem = -1;
                    db.Them(luanVan);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm luận văn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CapNhat(LuanVan luanVan)
        {
            try
            {
                using (var db = new DBConnect<LuanVan>())
                {
                    db.CapNhat(luanVan);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật luận văn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Xoa(int id)
        {
            try
            {
                using (var db = new DBConnect<LuanVan>())
                {

                    PNhiemVu pNhiemVu = new PNhiemVu();
                    List<NhiemVu> nhiemVus = pNhiemVu.Load();
                    nhiemVus = nhiemVus.Where(x => x.LuanVanID == id).ToList();
                    foreach (NhiemVu n in nhiemVus)
                    {
                        PNhiemVu_TroChuyen pNhiemVu_TroChuyen = new PNhiemVu_TroChuyen(n.ID);
                        pNhiemVu_TroChuyen.Xoa(n.ID);
                        pNhiemVu.XoaNhiemVu(n.ID);
                    }
                    PNhom pNhom = new PNhom();
                    pNhom.XoaTheoLuanVanID(id);
                    db.Xoa(id);
                    //MessageBox.Show("Xóa luận văn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa luận văn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public LuanVan LayLuanVanTheoID(int id)
        {
            try
            {
                using (var db = new DBConnect<LuanVan>())
                {
                    return db.LayTheoID(id);

                }
            }
            catch
            {
                return new LuanVan();
            }
        }
        #endregion
        #region Thao tác hiện thị
        public List<int> HienThiCotMaLuanVan(List<LuanVan> luanVan)
        {
            return luanVan.Select(l => l.ID).Distinct().ToList();
        }

        public List<string> HienThiCotTheLoai(List<LuanVan> luanVan)
        {
            return luanVan.Select(l => l.TheLoai).Distinct().ToList();
        }

        public List<string> HienThiCotCongNghe(List<LuanVan> luanVan)
        {
            return luanVan.Select(l => l.CongNghe).Distinct().ToList(); ;
        }

        public List<int> HienThiCotGiangVienID(List<LuanVan> luanVan)
        {
            return luanVan.Select(x => x.GiangVienID).Distinct().ToList();
        }

        public List<int> HienThiCotSoLuongSinhVien(List<LuanVan> luanVan)
        {
            return luanVan.Select(x => x.SoLuongSinhVien).Distinct().ToList();
        }
        #endregion
        #region Thao tác lọc
        public List<LuanVan> LocTheoGiangVienID(List<LuanVan> luanVan,int id)
        {
            return luanVan.Where(l => (l.GiangVienID == id)).ToList();
        }

        public List<LuanVan> LocTheoTheLoai(List<LuanVan> luanVan, string theLoai)
        {
            return luanVan.Where(l => (l.TheLoai == theLoai)).ToList();
        }

        public List<LuanVan> LocTheoCongNghe(List<LuanVan> luanVan, string congNghe)
        {
            return luanVan.Where(l => (l.CongNghe == congNghe)).ToList();
        }

        public List<LuanVan> LocTheoSoLuongSinhVien(List<LuanVan> luanVan, int slsv)
        {
            return luanVan.Where(l => (l.SoLuongSinhVien == slsv)).ToList();
        }

        public List<LuanVan> LocDanhSach(int? giangVienID, string theLoai, string congNghe, int soLuongSinhVien)
        {
            using (var db = new DBConnect<LuanVan>())
            {
                var luanVans = db.LayDanhSach();
                if (giangVienID.HasValue)
                {
                    luanVans = luanVans.Where(l => l.GiangVienID == giangVienID.Value).ToList();
                }
                if (!string.IsNullOrEmpty(theLoai))
                {
                    luanVans = luanVans.Where(l => l.TheLoai == theLoai).ToList();
                }
                if (!string.IsNullOrEmpty(congNghe))
                {
                    luanVans = luanVans.Where(l => l.CongNghe == congNghe).ToList();
                }
                if (soLuongSinhVien != -1)
                {
                    luanVans = luanVans.Where(l => l.SoLuongSinhVien == soLuongSinhVien).ToList();
                }

                return luanVans;
            }
        }
        #endregion
        #region Thao tác khác
        public LuanVan LayLuanVanDaDangKyTheoSinhVienID(NguoiDung nguoiDung)
        {
            PNhom nhomBUS = new PNhom();
            int? luanVanID = nhomBUS.LayLuanVanIDTuThanhVienID(nguoiDung.ID);
            if (luanVanID != null)
            {
                DBConnect<LuanVan> dBLuanVan = new DBConnect<LuanVan>();
                return dBLuanVan.LayTheoID(luanVanID.Value);
            }
            else
            {
                return new LuanVan();
            }
        }
        #endregion
    }
}
