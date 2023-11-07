using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Repository.Interfaces.Base;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.Classes.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {

        private readonly DbContext Context;
        public BaseRepository(DbContext context)
        {
            Context = context;
        }

        public IQueryable<T> Queryable()
        {
            return Context.Set<T>().AsQueryable();
        }

        public bool Create(T entity)
        {
            Context.Set<T>().Add(entity);
            return Context.SaveChanges() > 0;
        }

        public async Task<bool> CreateAsync(T entity)
        {
            await Context.Set<T>().AddAsync(entity);
            return await Context.SaveChangesAsync() > 0;
        }
        public bool Update(T entity)
        {
            var _entity = Context.Set<T>().Find(entity.ID);
            Context.Entry(_entity).CurrentValues.SetValues(entity);
            return Context.SaveChanges() > 0;
        }
        public async Task<bool> UpdateAsync(T entity)
        {
            var _entity = await Context.Set<T>().FindAsync(entity.ID);
            Context.Entry(_entity).CurrentValues.SetValues(entity);
            return await Context.SaveChangesAsync() > 0;
        }
        public bool Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
            return Context.SaveChanges() > 0;
        }
        public async Task<bool> DeleteAsync(T entity)
        {
            Context.Set<T>().Remove(entity);
            return await Context.SaveChangesAsync() > 0;
        }

        public T? Get(int ID)
        {
            return Context.Set<T>().Find(ID);
        }
        public async Task<T?> GetAsync(int ID)
        {
            return await Context.Set<T>().FindAsync(ID);
        }

        public List<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }
        public async Task<List<T>> GetAllAsync()
        {
            return await Context.Set<T>().ToListAsync();
        }




    }
}