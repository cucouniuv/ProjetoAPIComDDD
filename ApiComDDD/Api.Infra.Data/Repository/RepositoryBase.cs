using Api.Domain.Interfaces.Base;
using Api.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Infra.Data.Repository
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly ContextInMemory Db;

        public RepositoryBase(ContextInMemory contextInMemory)
        {
            Db = contextInMemory;
        }

        public void Add(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public void Update(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
        }

        public void Remove(TEntity obj)
        {
            Db.Set<TEntity>().Remove(obj);
        }

        public void Save()
        {
            Db.SaveChanges();
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        // Async 

        public async Task AddAsync(TEntity obj)
        {
            await Db.Set<TEntity>().AddAsync(obj);
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Db.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await Db.Set<TEntity>().FindAsync(id);
        }

        public async void SaveAsync()
        {
            await Db.SaveChangesAsync();
        }
    }
}
