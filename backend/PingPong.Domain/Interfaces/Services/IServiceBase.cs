using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        bool Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        bool Update(TEntity obj);
        bool Remove(TEntity obj);
        void Dispose();
    }
}
