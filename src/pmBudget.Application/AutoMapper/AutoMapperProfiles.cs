using AutoMapper;
using pmBudget.Application.DTOs.InputModels;
using pmBudget.Application.DTOs.OutputModels;
using pmBudget.Domain.Entities;

namespace pmBudget.Application.AutoMapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<TransactionInputModel, Transaction>()
                .AfterMap<SetUserIdAction<TransactionInputModel>>();
            CreateMap<Transaction, TransactionOutputModel>();
        }
    }
}
