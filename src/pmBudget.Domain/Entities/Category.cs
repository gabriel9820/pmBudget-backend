using pmBudget.Domain.Entities.Base;

namespace pmBudget.Domain.Entities
{
    public class Category : SaaSEntity
    {
        public string Name { get; set; }

        public Category() { }
    }
}