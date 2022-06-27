using Microsoft.EntityFrameworkCore;
using pmBudget.Domain.Entities.Base;
using pmBudget.Domain.Interfaces.Repositories;
using pmBudget.Infrastructure.Context;
using System.Linq.Expressions;

namespace pmBudget.Infrastructure.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly pmBudgetContext _context;

        public BaseRepository(pmBudgetContext context)
        {
            _context = context;
        }

        public TEntity Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);

            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            return entity;
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>>? conditions = null, int? skip = null, int? take = null, params Expression<Func<TEntity, object>>[]? includes)
        {
            var query = _context.Set<TEntity>().AsNoTracking().AsQueryable();

            if (conditions != null)
            {
                query = query.Where(conditions);
            }

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            if (skip != null && skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take != null && take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return await query.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(long id)
        {
            return await _context.Set<TEntity>()
                .AsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
