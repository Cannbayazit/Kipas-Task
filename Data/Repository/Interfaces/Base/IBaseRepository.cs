using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;

namespace Data.Repository.Interfaces.Base
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        IQueryable<T> Queryable();
        bool Create(T entity);
        Task<bool> CreateAsync(T entity);
        bool Update(T entity);
        Task<bool> UpdateAsync(T entity);
        bool Delete(T entity);
        Task<bool> DeleteAsync(T entity);
        T? Get(int ID);
        Task<T?> GetAsync(int ID);
        List<T> GetAll();
        Task<List<T>> GetAllAsync();

    }
}