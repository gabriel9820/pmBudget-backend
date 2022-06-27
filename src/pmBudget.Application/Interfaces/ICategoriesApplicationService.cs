using pmBudget.Application.DTOs.InputModels;
using pmBudget.Application.DTOs.OutputModels;
using pmBudget.Domain.Entities;

namespace pmBudget.Application.Interfaces
{
    public interface ICategoriesApplicationService : IBaseApplicationService<Category, CategoryInputModel, CategoryOutputModel>
    {
        Task<IEnumerable<CategoryOutputModel>> GetAllAsync();
    }
}
