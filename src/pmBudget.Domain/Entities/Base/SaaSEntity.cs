namespace pmBudget.Domain.Entities.Base
{
    public class SaaSEntity : BaseEntity
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
