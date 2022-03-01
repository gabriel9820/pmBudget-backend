using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using pmBudget.Application.Interfaces;
using pmBudget.Domain.Entities;
using pmBudget.Domain.Entities.Base;

namespace pmBudget.Infrastructure.Context
{
    public class pmBudgetContext : IdentityDbContext<ApplicationUser>
    {
        private readonly ILoggedInUserService _loggedInUserService;

        public pmBudgetContext(DbContextOptions<pmBudgetContext> options, ILoggedInUserService loggedInUserService) : base(options)
        {
            _loggedInUserService = loggedInUserService;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(pmBudgetContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.UtcNow;
                        entry.Entity.CreatedBy = _loggedInUserService.Id;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedAt = DateTime.UtcNow;
                        entry.Entity.UpdatedBy = _loggedInUserService.Id;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Transaction> Transactions { get; set; }
    }
}
