using CustomFramework.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CustomFramework.Infrastructure
{
    public class GenericRepository<T, TKey> : IRepository<T, TKey> where T : class
    {
        private readonly DbContext _dbContext;

        public GenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(T entity)
        {
            await _dbContext.AddAsync<T>(entity);
        }

        public void Delete(T entity)
        {
             _dbContext.Remove<T>(entity);
        }

        public async Task<bool> Exists(Expression<Func<T, bool>> expression)
        {
            return await _dbContext.Set<T>().AnyAsync(expression);
        }

        public async Task<T> Get(TKey id)
        {
             var entity = await _dbContext.FindAsync<T>(id);
            return entity;
        }

        public async Task<List<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task SaveChange()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _dbContext.Update(entity);
        }
    }
}
