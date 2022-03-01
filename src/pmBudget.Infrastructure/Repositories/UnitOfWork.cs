using pmBudget.Domain.Interfaces.Repositories;
using pmBudget.Infrastructure.Context;

namespace pmBudget.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly pmBudgetContext _context;

        public UnitOfWork(pmBudgetContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}
