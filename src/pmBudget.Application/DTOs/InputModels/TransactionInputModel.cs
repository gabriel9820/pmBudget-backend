using pmBudget.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace pmBudget.Application.DTOs.InputModels
{
    public class TransactionInputModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(200, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
        public string Title { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EnumDataType(typeof(TransactionType), ErrorMessage = "O campo {0} é inválido")]
        public TransactionType Type { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public double Value { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(200, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
        public string Category { get; set; }
    }
}
