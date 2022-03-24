using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Repositories.GenericRepository
{
    public interface IGenericRepository2<TEntity>
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetByIdAsync(int id);

        void Create(TEntity entity);
        void CreateRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);


        Task<bool> SaveAsync();
    }
}
