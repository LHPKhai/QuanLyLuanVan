using DataLibrary;
using QuanLyLuanAn.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace QuanLyLuanAn.BUS
{
    internal class PNguoiDung
    {
        DBConnect<NguoiDung> db;

        public PNguoiDung() 
        {
            db = new DBConnect<NguoiDung>();
        }

        ~PNguoiDung() { }

        #region CRUD
        public void CapNhat(int NguoiDungID, NguoiDung user1)
        {
            var user = db.LayDanhSach().FirstOrDefault(u => u.ID == NguoiDungID);
            if (user == null)
            {
                return;
            }
            user = user1;
            db.CapNhat(user);
        }

        public List<NguoiDung> LayDanhSach()
        {
            return db.LayDanhSach();
        }
        #endregion


        

        public NguoiDung Login(string TenDangNhap, string matKhau)
        {
            var dsNguoiDung = db.LayDanhSach();
            var nguoiDung = dsNguoiDung.FirstOrDefault(nd => nd.TenDangNhap == TenDangNhap && nd.MatKhau == matKhau);
            return nguoiDung;
        }


        public string SignUp(string name, string role, DateTime? dateOfBirth, string gender, string phoneNumber, string email, string password)
        {
            try
            {
                if (password.Length < 8)
                {
                    return "Mật khẩu phải có ít nhất 8 ký tự.";
                }

                var existingUser = db.LayDanhSach().FirstOrDefault(nd => nd.TenDangNhap == name);
                if (existingUser != null)
                {
                    return "Tên đăng nhập đã tồn tại.";
                }

                var newUser = new NguoiDung
                {
                    HoTen = name,
                    VaiTro = role,
                    NgaySinh = dateOfBirth,
                    GioiTinh = gender,
                    SoDienThoai = phoneNumber,
                    Email = email,
                    MatKhau = password
                };

                db.Them(newUser);
                return "";
            }
            catch (Exception ex)
            {
                return ("Lỗi đăng ký: " + ex.Message);
            }
        }

        public bool ForgetPassword(string email)
        {
            var user = db.LayDanhSach().FirstOrDefault(u => u.Email == email);
            if (user == null)
            {
                return false;
            }            
            return true;
        }

        public bool ChangePassword(string userName, string oldPassword, string newPassword)
        {
            var user = db.LayDanhSach().FirstOrDefault(u => u.TenDangNhap == userName && u.MatKhau == oldPassword);
            if (user == null)
            {
                return false;
            }
            user.MatKhau = newPassword;
            db.CapNhat(user);
            return true;
        }

        public void CapNhat(NguoiDung user)
        {
            db.CapNhat(user);
        }

        public List<NguoiDung> LayDanhSachGiangVien()
        {
            var nguoiDungs = db.LayDanhSach();
            return nguoiDungs.Where(g => g.VaiTro == "GiangVien").Distinct().ToList();
        }

        public List<NguoiDung> LayDanhSachTheoLuanVan(int id)
        {
            PNhom nhomBUS = new PNhom();
            var nguoiDungs = db.LayDanhSach();
            return nguoiDungs.Where(g => nhomBUS.LayLuanVanIDTuThanhVienID(g.ID) == id).ToList();
        }

        public int? TraIDGiangVienTheoTen(string tenGiangVien)
        {
            return db.LayDanhSach().FirstOrDefault(nguoiDung => nguoiDung.HoTen == tenGiangVien)?.ID;
        }

        public NguoiDung LayNguoiDungTheoID(int id)
        {
            NguoiDung nguoiDung = db.LayDanhSach().FirstOrDefault(nd => nd.ID == id);
            if(nguoiDung == null)
            {
                return new NguoiDung();
            }
            return nguoiDung;
        }
    }
}