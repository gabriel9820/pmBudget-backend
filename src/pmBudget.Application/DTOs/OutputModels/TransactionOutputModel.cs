using pmBudget.Domain.Enums;

namespace pmBudget.Application.DTOs.OutputModels
{
    public class TransactionOutputModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public TransactionType Type { get; set; }
        public double Value { get; set; }
        public string Category { get; set; }
    }
}
