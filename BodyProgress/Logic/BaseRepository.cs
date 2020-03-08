using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BodyProgress.Models;
using Microsoft.EntityFrameworkCore;

namespace BodyProgress.Logic
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class, IEntity
    {
        private readonly BodyProgressDbContext _context;

        public BaseRepository(BodyProgressDbContext context)
        {
            _context = context;
        }
        
        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsNoTracking();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Create(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task CreateRange(List<TEntity> entities)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public async Task Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRange(List<TEntity> entities)
        {
            _context.Set<TEntity>().UpdateRange(entities);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}