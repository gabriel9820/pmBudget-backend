using pmBudget.Domain.Entities;
using pmBudget.Domain.Interfaces.Repositories;
using pmBudget.Infrastructure.Context;

namespace pmBudget.Infrastructure.Repositories
{
    public class CategoriesRepository : BaseRepository<Category>, ICategoriesRepository
    {
        private readonly pmBudgetContext _context;

        public CategoriesRepository(pmBudgetContext context) : base(context)
        {
            _context = context;
        }
    }
}
