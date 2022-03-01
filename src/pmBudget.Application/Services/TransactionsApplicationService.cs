using AutoMapper;
using pmBudget.Application.DTOs.InputModels;
using pmBudget.Application.DTOs.OutputModels;
using pmBudget.Application.Interfaces;
using pmBudget.Domain.Entities;
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
    }
}
