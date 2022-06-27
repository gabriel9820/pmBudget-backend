using pmBudget.Domain.Enums;

namespace pmBudget.Application.DTOs.OutputModels
{
    public class TransactionOutputModel
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public TransactionType Type { get; set; }
        public double Value { get; set; }
        public CategoryOutputModel Category { get; set; }
    }
}
