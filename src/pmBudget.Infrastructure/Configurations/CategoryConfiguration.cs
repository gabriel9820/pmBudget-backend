using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pmBudget.Domain.Entities;

namespace pmBudget.Infrastructure.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id)
                .UseIdentityColumn();

            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(b => b.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            builder.HasOne(t => t.User)
                .WithMany(u => u.Categories)
                .HasForeignKey(t => t.UserId);
        }
    }
}
