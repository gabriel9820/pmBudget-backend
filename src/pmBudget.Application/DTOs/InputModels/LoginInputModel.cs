using System.ComponentModel.DataAnnotations;

namespace pmBudget.Application.DTOs.InputModels
{
    public class LoginInputModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Password { get; set; }
    }
}
