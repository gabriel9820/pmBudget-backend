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
        private readonly ILoggedInUserService _loggedInUserService;

        public TransactionsApplicationService(ITransactionsRepository transactionsRepository, IUnitOfWork unitOfWork, IMapper mapper, ILoggedInUserService loggedInUserService) : base(transactionsRepository, unitOfWork, mapper)
        {
            _transactionsRepository = transactionsRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _loggedInUserService = loggedInUserService;
        }

        public async Task<IEnumerable<TransactionOutputModel>> GetAllAsync()
        {
            var userId = _loggedInUserService.Id;

            var transactions = await _transactionsRepository.FindAsync(t => t.UserId == userId, null, null, t => t.Category);

            return _mapper.Map<IEnumerable<TransactionOutputModel>>(transactions);
        }

        public async Task<SummaryOutputModel> GetSummaryAsync()
        {
            var userId = _loggedInUserService.Id;

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
