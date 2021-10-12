using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(long id);
        Task<bool> Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
