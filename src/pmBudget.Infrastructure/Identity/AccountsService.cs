using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using pmBudget.Application.Common;
using pmBudget.Application.DTOs.InputModels;
using pmBudget.Application.DTOs.OutputModels;
using pmBudget.Application.Exceptions;
using pmBudget.Application.Interfaces;
using pmBudget.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace pmBudget.Infrastructure.Identity
{
    public class AccountsService : IAccountsService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtSettings _jwtSettings;

        public AccountsService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<JwtSettings> jwtSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<Response<LoginOutputModel>> LoginAsync(LoginInputModel loginInputModel)
        {
            var result = await _signInManager.PasswordSignInAsync(loginInputModel.UserName, loginInputModel.Password, false, true);

            if (!result.Succeeded)
            {
                throw new ApiException("Usuário e/ou senha incorreto(s)");
            }

            var response = await GenerateJwt(loginInputModel.UserName);

            return Response<LoginOutputModel>.Ok("Autenticado", response);
        }

        public Task ConfirmEmailAsync(string userId, string code)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<LoginOutputModel>> RegisterAsync(RegisterInputModel registerInputModel)
        {
            var user = new ApplicationUser
            {
                Name = registerInputModel.Name,
                UserName = registerInputModel.UserName,
                Email = registerInputModel.Email,
                EmailConfirmed = false,
            };

            var result = await _userManager.CreateAsync(user, registerInputModel.Password);

            if (!result.Succeeded)
            {
                throw new ValidationException(result.Errors.Select(e => e.Description));
            }

            await _signInManager.SignInAsync(user, false);

            var response = await GenerateJwt(user.UserName);

            return Response<LoginOutputModel>.Ok("Autenticado", response);
        }

        private async Task<LoginOutputModel> GenerateJwt(string username)
        {
            var user = await _userManager.FindByNameAsync(username);

            var claimsIdentity = new ClaimsIdentity();
            claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id));

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Key);

            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Issuer = _jwtSettings.Issuer,
                Audience = _jwtSettings.Audience,
                Expires = DateTime.UtcNow.AddHours(_jwtSettings.ExpiresInHours),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            return new LoginOutputModel
            {
                AccessToken = tokenHandler.WriteToken(token),
                ExpiresIn = TimeSpan.FromHours(_jwtSettings.ExpiresInHours).TotalSeconds,
                User = new AuthenticatedUserOutputModel
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    UserName = user.UserName,
                }
            };
        }
    }
}
