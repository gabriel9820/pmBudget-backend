using pmBudget.Domain.Entities.Base;
using pmBudget.Domain.Enums;

namespace pmBudget.Domain.Entities
{
    public class Transaction : SaaSEntity
    {
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public TransactionType Type { get; set; }
        public double Value { get; set; }
        public string Category { get; set; }

        public Transaction() { }
    }
}
