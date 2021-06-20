using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(i => i.Id).IsRequired();
            builder.Property(i =>i.Name).IsRequired().HasMaxLength(100);
            builder.Property(i => i.Description).IsRequired().HasMaxLength(180);
            builder.Property(i => i.Price).HasColumnType("decimal(18,2)");
            builder.Property(i => i.PictureUrl).IsRequired();
            builder.HasOne(b => b.ProductBrand).WithMany().HasForeignKey(i => i.ProductBrandId);
            builder.HasOne(t => t.ProductType).WithMany().HasForeignKey(i => i.ProductTypeId);
        }
    }
}