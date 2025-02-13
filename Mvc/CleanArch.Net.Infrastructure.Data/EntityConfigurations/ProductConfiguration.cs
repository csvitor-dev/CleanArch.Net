using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CleanArch.Net.Domain.Entities;

namespace CleanArch.Net.Infrastructure.Data.EntityConfigurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("products")
            .HasKey(x => x.Id).HasName("product_id");

        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(200);
        builder.Property(x => x.Price).HasPrecision(10, 2).IsRequired();

        builder.HasData(
            new Product(1, "Notebook", 1.575m)
            {
                Description = "spiral notebook 100 sheets"
            },
            new Product(2, "Eraser", 0.625m)
            {
                Description = "small white eraser"
            },
            new Product(3, "School Pencil Case", 0.875m)
            {
                Description = "small plastic case"
            }
        );
    }
}