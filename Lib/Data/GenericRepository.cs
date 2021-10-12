using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected FoodsOrderAPIContext _context;
        protected readonly DbSet<T> dbSet;
        protected readonly ILogger _logger;
        public GenericRepository(FoodsOrderAPIContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
            dbSet = _context.Set<T>();
        }
        public virtual async Task<bool> Add(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }

        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<T> GetById(long id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual void Update(T entity)
        {
            dbSet.Update(entity);
        }
    }
}
