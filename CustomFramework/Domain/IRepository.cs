using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CustomFramework.Domain
{
    public interface IRepository<T,TKey> where T : class
    {
        Task<T> Get(TKey id);

        Task<List<T>> GetAll();

        Task Create(T entity);

        void Update(T entity);

        void Delete(T entity);

        Task<bool> Exists(Expression<Func<T,bool>> expression);

        Task SaveChange();

    }
}
