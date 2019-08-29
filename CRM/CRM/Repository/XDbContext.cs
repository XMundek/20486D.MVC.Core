using CRM.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.Repository
{
    public interface IXDbContext
    {
        void Save<T>(T entity) where T : BaseEntity;
        void Delete<T>(int id) where T : BaseEntity;
        T FindById<T>(int id) where T : BaseEntity;
    }
    public class XDbContext:DbContext,IXDbContext
    {
        public XDbContext (DbContextOptions options) : base(options)
        {

        }
        public virtual void Save<T>(T entity) where T: BaseEntity
        {
            if (entity.Id == 0)
                this.Add<T>(entity);
            else
                this.Update<T>(entity);
            this.SaveChanges();
        }
        public virtual void Delete<T>(int id) where T : BaseEntity
        {
            using (var cn = this.Database.GetDbConnection())
            {
                cn.Open();
                var cmd = cn.CreateCommand();
                cmd.CommandText = $"DELETE {typeof(T).Name} WHERE Id={id}";
                cmd.ExecuteNonQuery();
            }

                
        }

        public virtual T FindById<T>(int id) where T:BaseEntity
        {
            return this.Find<T>(id);
        }
    }
}