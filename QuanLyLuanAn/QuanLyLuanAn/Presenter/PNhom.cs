using DataLibrary;
using QuanLyLuanAn.DAL;
using QuanLyLuanAn.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuanLyLuanAn.BUS
{
    public class PNhom
    {
        #region CRUD
        public void CapNhatHoacThemNhom(Nhom nhom)
        {
            PThongBao pThongBao = new PThongBao();
            using (var db = new DBConnect<Nhom>())
            {
                var existingNhom = db.LayDanhSach().FirstOrDefault(n => n.ThanhVienID == nhom.ThanhVienID);

                if (existingNhom == null)
                {
                    db.Them(nhom);
                }
                else
                {
                    existingNhom.LuanVanID = nhom.LuanVanID;
                    db.CapNhat(existingNhom);
                }
            }
        }

        public void XoaNhomTheoThanhVienID(int thanhVienID)
        {
            using (var db = new DBConnect<Nhom>())
            {
                var nhom = db.LayDanhSach().FirstOrDefault(n => n.ThanhVienID == thanhVienID);

                if (nhom != null)
                {
                    db.Xoa(nhom.ID);
                }
            }
        }
        public void XoaTheoLuanVanID(int luanVanID)
        {
            using (var dbConnect = new DBConnect<Nhom>())
            {
                try
                {
                    var nhomsCanXoa = dbConnect.LayDanhSach().Where(n => n.LuanVanID == luanVanID).ToList();

                    // Xóa từng đối tượng trong danh sách
                    foreach (var nhom in nhomsCanXoa)
                    {
                        dbConnect.Xoa(nhom.ID);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa dữ liệu từ bảng Nhom: " + ex.Message);
                }
            }
        }
        #endregion
        #region Thao tác khác
        public int LayLuanVanIDTuThanhVienID(int thanhVienID)
        {
            using (var db = new DBConnect<Nhom>())
            {
                var nhom = db.LayDanhSach().FirstOrDefault(n => n.ThanhVienID == thanhVienID);
                if (nhom != null)
                {
                    return nhom.LuanVanID;
                }
                else
                {
                    return 0; // or any other default value you prefer
                }
            }
        }

        public List<Nhom> LayDanhSachNhomTheoLuanVanID(int luanVanID)
        {
            using (var db = new DBConnect<Nhom>())
            {
                var nhom = db.LayDanhSach().Where(n => n.LuanVanID == luanVanID).ToList();
                return nhom;
            }
        }

        public List<int> LayDanhSachThanhVienID(List<Nhom> nhoms)
        {
            return nhoms.Select(x => x.ThanhVienID).Distinct().ToList();
        }

        public Nhom LayNhomTheoThanhVienID(int thanhVienID)
        {
            using (var db = new DBConnect<Nhom>())
            {
                var nhom = db.LayDanhSach().FirstOrDefault(n => n.ThanhVienID == thanhVienID);
                if (nhom != null)
                {
                    return nhom;
                }
                else
                {
                    return null; // or any other default value you prefer
                }
            }
        }

        public List<NguoiDung> LayThongTinThanhVienNhomTheoLuanVanID(int luanVanID)
        {
            List<int> ThanhVienIDs = new List<int>();
            List<Nhom> nhoms = new List<Nhom>();
            nhoms = LayDanhSachNhomTheoLuanVanID(luanVanID);
            PNguoiDung pNguoiDung = new PNguoiDung();
            List<NguoiDung> nguoiDungs = new List<NguoiDung>();
            ThanhVienIDs = LayDanhSachThanhVienID(nhoms);
            if (nhoms.Count > 0)
            {
                foreach(var id in ThanhVienIDs) 
                {
                    if(id != null)
                    {
                        NguoiDung nguoiDung = pNguoiDung.LayNguoiDungTheoID((int)id);
                        if(nguoiDung != null)
                        {
                            nguoiDungs.Add(nguoiDung);
                        }    
                    }    
                }
            }
            return nguoiDungs;
        }

        public List<Nhom> ThemThanhVienVaoList(List<Nhom> nhoms, Nhom thanhVien)
        {
            if (nhoms.Find(tv => tv.ThanhVienID == thanhVien.ID) != null)
            {
                return nhoms; 
            }
            else
            {
                nhoms.Add(thanhVien);
                return nhoms; 
            }
        }
        #endregion
    }
}
