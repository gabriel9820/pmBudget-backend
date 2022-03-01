using System.ComponentModel.DataAnnotations;

namespace pmBudget.Application.DTOs.InputModels
{
    public class RegisterInputModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MinLength(3, ErrorMessage = "O campo {0} deve conter no mínimo {1} caracteres")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} é inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MinLength(3, ErrorMessage = "O campo {0} deve conter no mínimo {1} caracteres")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MinLength(6, ErrorMessage = "O campo {0} deve conter no mínimo {1} caracteres")]
        public string Password { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Compare("Password", ErrorMessage = "As senhas não correspondem")]
        public string ConfirmPassword { get; set; }
    }
}
