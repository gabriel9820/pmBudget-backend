using pmBudget.Domain.Entities.Base;
using System.Linq.Expressions;

namespace pmBudget.Application.Interfaces
{
    public interface IBaseApplicationService<TEntity, TInputModel, TOutputModel>
        where TEntity : BaseEntity
        where TInputModel : class
        where TOutputModel : class
    {
        Task<TOutputModel> CreateAsync(TInputModel inputModel);
        Task<TOutputModel> UpdateAsync(long id, TInputModel inputModel);
        Task DeleteAsync(long id);
        Task<IEnumerable<TOutputModel>> FindAsync(Expression<Func<TEntity, bool>>? conditions = null, int? skip = null, int? take = null, params Expression<Func<TEntity, object>>[]? includes);
        Task<TOutputModel> GetByIdAsync(long id);
    }
}
