using AutoMapper;
using pmBudget.Application.Interfaces;
using pmBudget.Domain.Entities.Base;

namespace pmBudget.Application.AutoMapper
{
    public class SetUserIdAction<T> : IMappingAction<T, SaaSEntity> where T : class
    {
        private readonly ILoggedInUserService _loggedInUserService;

        public SetUserIdAction(ILoggedInUserService loggedInUserService)
        {
            _loggedInUserService = loggedInUserService ?? throw new ArgumentNullException(nameof(loggedInUserService));
        }

        public void Process(T source, SaaSEntity target, ResolutionContext context)
        {
            target.UserId = _loggedInUserService.Id;
        }
    }
}
