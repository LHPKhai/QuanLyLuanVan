using DataLibrary;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyLuanAn.DAL
{
    public class DBConnect<T> : IDisposable where T : class
    {

        public DBConnect(){ }

        public List<T> LayDanhSach()
        {
            using(var dbContext = new LuanVanDBEntities())
            {
                return dbContext.Set<T>().ToList();
            }
        }

        public T LayTheoID(int id)
        {
            using (var dbContext = new LuanVanDBEntities())
            {
                return dbContext.Set<T>().Find(id);
            }
        }

        public int Them(T entity)
        {
            try
            {
                using (var dbContext = new LuanVanDBEntities())
                {
                    dbContext.Set<T>().Add(entity);
                    dbContext.SaveChanges();
                    return ((dynamic)entity).ID;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm đối tượng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        public void Xoa(int id)
        {
            try
            {
                using (var dbContext = new LuanVanDBEntities())
                {
                    var entity = dbContext.Set<T>().Find(id);
                    if (entity != null)
                    {
                        dbContext.Set<T>().Remove(entity);
                        dbContext.SaveChanges();
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa đối tượng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CapNhat(T entity)
        {
            try
            {
                using (var dbContext = new LuanVanDBEntities())
                {
                    dbContext.Entry(entity).State = EntityState.Modified;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật đối tượng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Dispose()
        {
            using (var dbContext = new LuanVanDBEntities())
            {
                if (dbContext != null)
                {
                    dbContext.Dispose();
                }
            }
        }
    }
}