using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataLibrary
{
    public enum CRUDAction
    {
        Them,
        CapNhat,
        Xoa,
        LayTheoID
    }

    public class DBConnect1<T> : IDisposable where T : class
    {
        private readonly LuanVanDBEntities dbContext;

        public DBConnect1()
        {
            dbContext = new LuanVanDBEntities();
        }

        public void ExecuteCRUD(T entity , CRUDAction action, int id = 0)
        {
            try
            {
                switch (action)
                {
                    case CRUDAction.Them:
                        dbContext.Set<T>().Add(entity);
                        break;
                    case CRUDAction.CapNhat:
                        dbContext.Entry(entity).State = EntityState.Modified;
                        break;
                    case CRUDAction.Xoa:
                        var entityToDelete = dbContext.Set<T>().Find(id);
                        if (entityToDelete != null)
                        {
                            dbContext.Set<T>().Remove(entityToDelete);
                        }
                        break;
                    case CRUDAction.LayTheoID:
                        var entityByID = dbContext.Set<T>().Find(id);
                        break;
                    default:
                        break;
                }
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thực hiện thao tác CRUD: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Dispose()
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
            }
        }
    }

}
