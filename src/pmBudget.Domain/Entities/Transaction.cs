using pmBudget.Domain.Entities.Base;
using pmBudget.Domain.Enums;

namespace pmBudget.Domain.Entities
{
    public class Transaction : SaaSEntity
    {
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public TransactionType Type { get; set; }
        public long CategoryId { get; set; }
        public double Value { get; set; }

        /* Relations */
        public Category Category { get; set; }

        public Transaction() { }
    }
}
