using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pmBudget.Domain.Entities;

namespace pmBudget.Infrastructure.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transactions");

            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id)
                .UseIdentityColumn();

            builder.Property(b => b.Date)
                .HasDefaultValueSql("now()")
                .IsRequired();

            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(b => b.Type)
                .IsRequired();

            builder.Property(b => b.Value)
                .IsRequired();

            builder.HasOne(t => t.Category)
                .WithMany(c => c.Transactions)
                .HasForeignKey(t => t.CategoryId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.User)
                .WithMany(u => u.Transactions)
                .HasForeignKey(t => t.UserId);
        }
    }
}
