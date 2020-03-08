using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BodyProgress.Logic
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetById(int id);
        Task Create(TEntity entity);
        Task CreateRange(List<TEntity> entities);
        Task Update(TEntity entity);
        Task UpdateRange(List<TEntity> entities);
        Task Delete(int id);
    }
}