using System.ComponentModel.DataAnnotations;

namespace pmBudget.Application.DTOs.InputModels
{
    public class CategoryInputModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(200, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
        public string Name { get; set; }
    }
}
