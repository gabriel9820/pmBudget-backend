using AutoMapper;
using pmBudget.Application.DTOs.InputModels;
using pmBudget.Application.DTOs.OutputModels;
using pmBudget.Application.Interfaces;
using pmBudget.Domain.Entities;
using pmBudget.Domain.Enums;
using pmBudget.Domain.Interfaces.Repositories;

namespace pmBudget.Application.Services
{
    public class TransactionsApplicationService : BaseApplicationService<Transaction, TransactionInputModel, TransactionOutputModel>, ITransactionsApplicationService
    {
        private readonly ITransactionsRepository _transactionsRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TransactionsApplicationService(ITransactionsRepository transactionsRepository, IUnitOfWork unitOfWork, IMapper mapper) : base(transactionsRepository, unitOfWork, mapper)
        {
            _transactionsRepository = transactionsRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<SummaryOutputModel> GetSummaryAsync(string userId)
        {
            var incomes = await _transactionsRepository.FindAsync(t => t.Type == TransactionType.Income && t.UserId == userId);
            var expenses = await _transactionsRepository.FindAsync(t => t.Type == TransactionType.Expense && t.UserId == userId);

            var sumIncomes = incomes.Sum(i => i.Value);
            var sumExpenses = expenses.Sum(e => e.Value);

            return new SummaryOutputModel
            {
                Incomes = sumIncomes,
                Expenses = sumExpenses,
                Balance = sumIncomes - sumExpenses,
            };
        }
    }
}
