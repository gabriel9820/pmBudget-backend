using AutoMapper;
using pmBudget.Application.DTOs.InputModels;
using pmBudget.Application.DTOs.OutputModels;
using pmBudget.Application.Interfaces;
using pmBudget.Domain.Entities;
using pmBudget.Domain.Interfaces.Repositories;

namespace pmBudget.Application.Services
{
    public class CategoriesApplicationService : BaseApplicationService<Category, CategoryInputModel, CategoryOutputModel>, ICategoriesApplicationService
    {
        private readonly ICategoriesRepository _categoriesRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoriesApplicationService(ICategoriesRepository categoriesRepository, IUnitOfWork unitOfWork, IMapper mapper) : base(categoriesRepository, unitOfWork, mapper)
        {
            _categoriesRepository = categoriesRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }
}
