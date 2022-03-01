using pmBudget.Application.DTOs.InputModels;
using pmBudget.Application.DTOs.OutputModels;
using pmBudget.Domain.Entities;

namespace pmBudget.Application.Interfaces
{
    public interface ITransactionsApplicationService : IBaseApplicationService<Transaction, TransactionInputModel, TransactionOutputModel> { }
}
