using Microsoft.AspNetCore.Mvc;
using pmBudget.Application.DTOs.InputModels;
using pmBudget.Application.Interfaces;

namespace pmBudget.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private IAccountsService _accountsService;

        public AccountsController(IAccountsService accountsService)
        {
            _accountsService = accountsService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginInputModel loginInputModel)
        {
            return Ok(await _accountsService.LoginAsync(loginInputModel));
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterInputModel registerInputModel)
        {
            return Ok(await _accountsService.RegisterAsync(registerInputModel));
        }
    }
}
