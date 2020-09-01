using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Domain.Entities
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void Dispose();
        void Save();

        Task AddAsync(TEntity obj);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        void SaveAsync();
    }
}
