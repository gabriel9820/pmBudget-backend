using pmBudget.Domain.Entities.Base;

namespace pmBudget.Domain.Entities
{
    public class Category : SaaSEntity
    {
        public string Name { get; set; }
        public bool? IsActive { get; set; }

        /* Relations */
        public ICollection<Transaction> Transactions { get; set; }

        public Category() { }
    }
}