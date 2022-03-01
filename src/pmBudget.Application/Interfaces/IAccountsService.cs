using pmBudget.Application.Common;
using pmBudget.Application.DTOs.InputModels;
using pmBudget.Application.DTOs.OutputModels;

namespace pmBudget.Application.Interfaces
{
    public interface IAccountsService
    {
        Task<Response<LoginOutputModel>> LoginAsync(LoginInputModel loginInputModel);
        Task ConfirmEmailAsync(string userId, string code);
        Task<Response<LoginOutputModel>> RegisterAsync(RegisterInputModel registerInputModel);
    }
}
