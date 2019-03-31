using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        bool Add(TEntity obj);
        TEntity GetById(int id);
        bool Update(TEntity obj);
        bool Remove(TEntity obj);
        void Dispose();
    }
}
