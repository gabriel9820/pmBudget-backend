using Microsoft.AspNetCore.Identity;

namespace pmBudget.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

        /* Relations */
        public ICollection<Transaction> Transactions { get; set; }
        public ICollection<Category> Categories { get; set; }

        public ApplicationUser() { }
    }
}
