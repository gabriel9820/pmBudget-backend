using pmBudget.Domain.Entities.Base;
using System.Linq.Expressions;

namespace pmBudget.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity Create(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>>? conditions = null, int? skip = null, int? take = null);
        Task<TEntity> GetByIdAsync(long id);
    }
}
