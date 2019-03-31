using PingPong.Domain.Interfaces.Repositories;
using PingPong.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong.Infra.Data.Repositories
{
    public class RespositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected PingPongContext Db = new PingPongContext();
        public bool Add(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Added;

            Db.Set<TEntity>().Add(obj);

            return Convert.ToBoolean(Db.SaveChanges());
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        public IEnumerable<TEntity> GetAll()
        {                       
            return Db.Set<TEntity>().ToList();
        }
        public TEntity GetById(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }
        public bool Remove(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Deleted;

            Db.Set<TEntity>().Remove(obj);

            return Convert.ToBoolean(Db.SaveChanges());
        }
        public bool Update(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;

            return Convert.ToBoolean(Db.SaveChanges());
        }
    }
}
