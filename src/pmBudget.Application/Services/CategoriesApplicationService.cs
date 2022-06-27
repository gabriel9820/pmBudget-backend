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
        private readonly ILoggedInUserService _loggedInUserService;

        public CategoriesApplicationService(ICategoriesRepository categoriesRepository, IUnitOfWork unitOfWork, IMapper mapper, ILoggedInUserService loggedInUserService) : base(categoriesRepository, unitOfWork, mapper)
        {
            _categoriesRepository = categoriesRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _loggedInUserService = loggedInUserService;
        }

        public async Task<IEnumerable<CategoryOutputModel>> GetAllAsync()
        {
            var userId = _loggedInUserService.Id;

            var categories = await _categoriesRepository.FindAsync(c => c.UserId == userId);

            return _mapper.Map<IEnumerable<CategoryOutputModel>>(categories);
        }
    }
}
