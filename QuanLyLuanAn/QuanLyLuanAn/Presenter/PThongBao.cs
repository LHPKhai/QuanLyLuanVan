using DataLibrary;
using QuanLyLuanAn.BUS;
using QuanLyLuanAn.DAL;
using QuanLyLuanAn.Presenter;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyLuanAn.Presenter
{

    public enum EThongBao
    {
        LuanVan_ChoDuyet,
        LuanVan_DaDuyet,
        LuanVan_KhongDuocDuyet,
        LuanVan_KetQua,
        Chat_ThongBaoMoi,
        NhiemVu_DuocPhanCong,
        NhiemVu_SapDenHan,
        NhiemVu_QuaHan
    }

    public class PThongBao
    {
        private readonly Dictionary<EThongBao, string> thongBaoDict;
        public PThongBao()
        {
            thongBaoDict = new Dictionary<EThongBao, string>
                {
                    { EThongBao.LuanVan_ChoDuyet, "Yêu cầu đăng ký luận văn đang chờ duyệt" },
                    { EThongBao.LuanVan_DaDuyet, "Yêu cầu đăng ký luận văn đã được duyệt" },
                    { EThongBao.LuanVan_KhongDuocDuyet, "Yêu cầu đăng ký luận văn không được duyệt" },
                    { EThongBao.LuanVan_KetQua, "Kết quả chấm điểm luận văn của bạn" },
                    { EThongBao.Chat_ThongBaoMoi, "Thông báo mới trong chat nhiệm vụ" },
                    { EThongBao.NhiemVu_DuocPhanCong, "Nhiệm vụ mới được phân công cho bạn" },
                    { EThongBao.NhiemVu_SapDenHan, "Nhiệm vụ của bạn sắp đến hạn" },
                    { EThongBao.NhiemVu_QuaHan, "Nhiệm vụ của bạn đã quá hạn" }
                };
        }
        #region CRUD
        public int ThemThongBaoMoi(ThongBao thongBao)
        {
            using (var db = new DBConnect<ThongBao>())
            {
                db.Them(thongBao);
                return thongBao.ID;
            }
        }

        public void XoaThongBao(int id)
        {
            using (var db = new DBConnect<ThongBao>())
            {
                var thongBao = db.LayTheoID(id);
                if (thongBao != null)
                {
                    db.Xoa(thongBao.ID);
                }
            }
        }

        public void CapNhatThongBao(ThongBao thongBao)
        {
            using (var db = new DBConnect<ThongBao>())
            {
                db.CapNhat(thongBao);
            }
        }

        public ThongBao LayThongBaoTheoID(int id)
        {
            using (var db = new DBConnect<ThongBao>())
            {
                return db.LayTheoID(id);
            }
        }
        #endregion
        #region thao tác
        public string LayNoiDungThongBao(EThongBao loaiThongBao)
        {
            if (thongBaoDict.ContainsKey(loaiThongBao))
            {
                return thongBaoDict[loaiThongBao];
            }
            else
            {
                return "Thông báo không xác định";
            }
        }
        public List<ThongBao> LayDanhSachThongBao(int nguoiDungID)
        {
            using (var db = new DBConnect<ThongBao>())
            {
                return db.LayDanhSach().Where(tb => tb.NguoiDungID == nguoiDungID).ToList();
            }
        }

        public List<ThongBao> LayDanhSachThongBaoDaXem(int nguoiDungID)
        {
            List<ThongBao> ds = LayDanhSachThongBao(nguoiDungID);
            return ds.Where(tb => tb.DaDoc == true).ToList();
        }

        public List<ThongBao> LayDanhSachThongBaoChuaXem(int nguoiDungID)
        {
            List<ThongBao> ds = LayDanhSachThongBao(nguoiDungID);
            return ds.Where(tb => tb.DaDoc == false).ToList();
        }

        public void DanhDauThongBaoDaDoc(int thongBaoID)
        {
            using (var db = new DBConnect<ThongBao>())
            {
                var notification = db.LayTheoID(thongBaoID);
                if (notification != null)
                {
                    notification.DaDoc = true;
                    db.CapNhat(notification);
                }
            }
        }

        public int SoLuongThongBaoMoi(int nguoiDungID)
        {
            List<ThongBao> ds = LayDanhSachThongBao(nguoiDungID);
            int sl = ds.Where(tb => tb.DaDoc == false).ToList().Count;
            return sl;
        }

        public List<int> SoLuongThongBao(int nguoiDungID)
        {
            List<int> ints = new List<int>();
            List<ThongBao> ds = LayDanhSachThongBao(nguoiDungID);
            ints.Add(ds.Where(tb => tb.TheLoai == "NhiemVu   ").ToList().Count());
            ints.Add(ds.Where(tb => tb.TheLoai == "Chat      ").ToList().Count());
            ints.Add(ds.Where(tb => tb.TheLoai == "LuanVan   ").ToList().Count());
            return ints;
        }
        #endregion
        #region Chức năng thông báo
        #region Luận văn
        public void ThemThongBaoDangKyLuanVan(int sinhvienID, LuanVan luanVan)
        {
            PNguoiDung db = new PNguoiDung();
            int giangVienID = (int)luanVan.GiangVienID;
            var sinhvien = db.LayNguoiDungTheoID(sinhvienID);
            var giangVien = db.LayNguoiDungTheoID(giangVienID);

            var thongBaoForGiangVien = new ThongBao()
            {
                NguoiDungID = giangVienID,
                NoiDung = $"Sinh viên {sinhvien.HoTen} có yêu cầu đăng ký luận văn {luanVan.TieuDe}.",
                ThoiGian = DateTime.Now,
                DaDoc = false,
                TheLoai = "LuanVan",
                TieuDe = "Yêu cầu đăng ký mới",
                ThongTinThem = luanVan.ID
            };

            var thongBaoForSinhVien = new ThongBao()
            {
                NguoiDungID = sinhvienID,
                NoiDung = $"Bạn đã yêu cầu đăng ký luận văn {luanVan.TieuDe} của giảng viên {giangVien.HoTen}",
                ThoiGian = DateTime.Now,
                DaDoc = false,
                TheLoai = "LuanVan",
                TieuDe = $"Đã gửi yêu cầu đăng ký của bạn đến giảng viên {giangVien.HoTen}",
                ThongTinThem = luanVan.ID
            };
            ThemThongBaoMoi(thongBaoForGiangVien);
            ThemThongBaoMoi(thongBaoForSinhVien);
        }

        public void ThemThongBaoXoaSinhVienKhoiLuanVan(int sinhVienID, int luanVanID, string lyDo)
        {
            PLuanVan pLuanVan = new PLuanVan();
            LuanVan luanVan = pLuanVan.LayLuanVanTheoID(luanVanID);
            PNguoiDung db = new PNguoiDung();
            string hoTenGiangVien = db.LayNguoiDungTheoID((int)luanVan.ID).HoTen;
            var thongBaoForSinhVien = new ThongBao
            {
                NguoiDungID = sinhVienID,
                NoiDung = $"Bạn đã bị xóa khỏi luận văn {luanVan.TieuDe} \nLý do {lyDo}",
                ThoiGian = DateTime.Now,
                DaDoc = false,
                TheLoai = "LuanVan",
                TieuDe = $"Điểm luận văn",
                ThongTinThem = luanVan.ID
            };
            ThemThongBaoMoi(thongBaoForSinhVien);
        }

        public void ThemThongBaoDuocDuyetLuanVan(int sinhVienID, int luanVanID)
        {
            PLuanVan pLuanVan = new PLuanVan();
            PNguoiDung pNguoiDung = new PNguoiDung();
            LuanVan luanVan = pLuanVan.LayLuanVanTheoID(luanVanID);
            string hoTenGiangVien = pNguoiDung.LayNguoiDungTheoID((int)luanVan.ID).HoTen;
            var thongBaoForSinhVien = new ThongBao
            {
                NguoiDungID = sinhVienID,
                NoiDung = $"Yêu cầu làm đăng ký luận văn {luanVan.TieuDe} của giảng viên {hoTenGiangVien} đã được duyệt",
                ThoiGian = DateTime.Now,
                DaDoc = false,
                TheLoai = "LuanVan",
                TieuDe = $"Yêu cầu đăng ký luận văn được duyệt",
                ThongTinThem = luanVan.ID
            };
            ThemThongBaoMoi(thongBaoForSinhVien);
        }

        public void ThemThongBaoKoDuyetLuanVan(int sinhVienID, int luanVanID, string lyDo)
        {
            PLuanVan pLuanVan = new PLuanVan();
            LuanVan luanVan = pLuanVan.LayLuanVanTheoID(luanVanID);
            PNguoiDung db = new PNguoiDung();
            string hoTenGiangVien = db.LayNguoiDungTheoID((int)luanVan.ID).HoTen;
            var thongBaoForSinhVien = new ThongBao
            {
                NguoiDungID = sinhVienID,
                NoiDung = $"Yêu cầu làm đăng ký luận văn {luanVan.TieuDe}không được duyệt \n" + lyDo,
                ThoiGian = DateTime.Now,
                DaDoc = false,
                TheLoai = "LuanVan",
                TieuDe = $"Yêu cầu đăng ký luận văn được duyệt",
                ThongTinThem = luanVan.ID
            };
            ThemThongBaoMoi(thongBaoForSinhVien);
        }

        public void ThemThongBaoDiemLuanVan(int sinhVienID, int luanVanID, int diem)
        {
            PLuanVan pLuanVan = new PLuanVan();
            LuanVan luanVan = pLuanVan.LayLuanVanTheoID(luanVanID);
            PNguoiDung db = new PNguoiDung();
            string hoTenGiangVien = db.LayNguoiDungTheoID((int)luanVan.ID).HoTen;
            var thongBaoForSinhVien = new ThongBao
            {
                NguoiDungID = sinhVienID,
                NoiDung = $"Điểm luận văn {luanVan.TieuDe} của bạn là {diem}",
                ThoiGian = DateTime.Now,
                DaDoc = false,
                TheLoai = "LuanVan",
                TieuDe = $"Giảng viên {hoTenGiangVien} đã xóa bạn khỏi luận văn",
                ThongTinThem = luanVan.ID
            };
            ThemThongBaoMoi(thongBaoForSinhVien);
        }

        public void ThemThongBaoXacNhanDiemLuanVan(int sinhVienID, int luanVanID)
        {
            PLuanVan pLuanVan = new PLuanVan();
            LuanVan luanVan = pLuanVan.LayLuanVanTheoID(luanVanID);
            PNguoiDung db = new PNguoiDung();
            NguoiDung sinhVien = db.LayNguoiDungTheoID(sinhVienID);
            int giangVienID = (int)luanVan.GiangVienID;
            var thongBaoForSinhVien = new ThongBao
            {
                NguoiDungID = giangVienID,
                NoiDung = $"Sinh viên {sinhVien.HoTen} xác nhận điểm luận văn {luanVan.TieuDe}",
                ThoiGian = DateTime.Now,
                DaDoc = false,
                TheLoai = "LuanVan",
                TieuDe = $"Sinh viên xác nhận điểm",
                ThongTinThem = luanVan.ID
            };
            ThemThongBaoMoi(thongBaoForSinhVien);
        }

        public void ThemThongBaoPhucKhaoDiemLuanVan(int sinhVienID, int luanVanID)
        {
            PLuanVan pLuanVan = new PLuanVan();
            LuanVan luanVan = pLuanVan.LayLuanVanTheoID(luanVanID);
            PNguoiDung pNguoiDung = new PNguoiDung();
            var sinhVien = pNguoiDung.LayNguoiDungTheoID(sinhVienID);
            int giangVienID = (int)luanVan.GiangVienID;
            var giangVien = pNguoiDung.LayNguoiDungTheoID(giangVienID);
            var thongBaoForSinhVien = new ThongBao()
            {
                NguoiDungID = giangVien.ID,
                NoiDung = $"Sinh viên {sinhVien.HoTen} muốn phúc khảo luận văn {luanVan.TieuDe}",
                ThoiGian = DateTime.Now,
                DaDoc = false,
                TheLoai = "LuanVan",
                TieuDe = $"Sinh viên muốn phúc khảo điểm",
                ThongTinThem = luanVan.ID
            };
            ThemThongBaoMoi(thongBaoForSinhVien);
        }
        #endregion
        #region Nhiệm vụ
        public void ThemThongBaoPhanCongNhiemVu(int sinhvienID, NhiemVu nhiemVu)
        {
            PNguoiDung pNguoiDung = new PNguoiDung();
            string hoTenGiangVien = pNguoiDung.LayNguoiDungTheoID((int)nhiemVu.LuanVanID).HoTen;
            var thongBaoForSinhVien = new ThongBao
            {
                NguoiDungID = sinhvienID,
                NoiDung = $"Bạn đã được yêu cầu làm nhiệm vụ {nhiemVu.TieuDe} của giảng viên {hoTenGiangVien}",
                ThoiGian = DateTime.Now,
                DaDoc = false,
                TheLoai = "NhiemVu",
                TieuDe = $"Nhiệm vụ này được giảng viên {hoTenGiangVien} phân công cho bạn",
                ThongTinThem = nhiemVu.ID
            };
            ThemThongBaoMoi(thongBaoForSinhVien);
        }

        public void ThemThongBaoDoiPhanCongNhiemVu(int sinhvienID, NhiemVu nhiemVu)
        {
            PNguoiDung pNguoiDung=new PNguoiDung();
            string hoTenGiangVien = pNguoiDung.LayNguoiDungTheoID((int)nhiemVu.LuanVanID).HoTen;
            var thongBaoForSinhVien = new ThongBao
            {
                NguoiDungID = sinhvienID,
                NoiDung = $"Bạn đã được yêu cầu làm nhiệm vụ {nhiemVu.TieuDe} của giảng viên {hoTenGiangVien}",
                ThoiGian = DateTime.Now,
                DaDoc = false,
                TheLoai = "NhiemVu",
                TieuDe = $"Nhiệm vụ này được giảng viên {hoTenGiangVien} thay đổi phân công cho bạn",
                ThongTinThem = nhiemVu.ID
            };
            ThemThongBaoMoi(thongBaoForSinhVien);
        }
        #endregion
        #region Chat
        public void ThemThongBaoTinNhanDen(NguoiDung nguoiGui, NhiemVu_TroChuyen chat, NguoiDung nguoiNhan)
        {
            PNhiemVu pnhiemVu = new PNhiemVu();
            string chucVu = "Sinh viên";
            if(nguoiGui.VaiTro == "GiangVien")
            {
                chucVu = "Giảng viên hướng dẫn";
            }
            var thongBaoForSinhVien = new ThongBao
            {
                NguoiDungID = nguoiNhan.ID,
                NoiDung = chat.NoiDung,
                ThoiGian = DateTime.Now,
                DaDoc = false,
                TheLoai = "Chat",
                TieuDe = $"Tin nhắn đến từ {chucVu} {nguoiGui.HoTen} trong nhiệm vụ {pnhiemVu.LayNhiemVuTheoID((int)chat.NhiemVuID).TieuDe}",
                ThongTinThem = chat.ID
            };
            ThemThongBaoMoi(thongBaoForSinhVien);
        }
        #endregion
        #endregion
    }
}
