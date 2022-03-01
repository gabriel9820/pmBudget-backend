using pmBudget.Application.Interfaces;
using System.Security.Claims;

namespace pmBudget.API.Services
{
    public class LoggedInUserService : ILoggedInUserService
    {
        public string Id { get; }

        public LoggedInUserService(IHttpContextAccessor httpContextAccessor)
        {
            Id = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
