using pmBudget.Domain.Entities;
using pmBudget.Domain.Interfaces.Repositories;
using pmBudget.Infrastructure.Context;

namespace pmBudget.Infrastructure.Repositories
{
    public class TransactionsRepository : BaseRepository<Transaction>, ITransactionsRepository
    {
        private readonly pmBudgetContext _context;

        public TransactionsRepository(pmBudgetContext context) : base(context)
        {
            _context = context;
        }
    }
}
