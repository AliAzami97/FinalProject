using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShMa.Domain.ProductAgg;

namespace ShMa.Infrastructure.EfCore.Mapping
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Code).HasMaxLength(15).IsRequired();
            builder.Property(x => x.Image).HasMaxLength(1000);
            builder.Property(x => x.ImageAlt).HasMaxLength(255);
            builder.Property(x => x.ImageTitle).HasMaxLength(500);
            builder.Property(x => x.MetaDescription).HasMaxLength(150).IsRequired();
            builder.Property(x => x.ShortDescription).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Keyword).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Slug).HasMaxLength(500).IsRequired();
            builder.Property(x => x.UnitPrice).HasMaxLength(50).IsRequired();


            builder.HasOne(x => x.Category).WithMany(x => x.Productsz).HasForeignKey(x => x.CategoryId);
            builder.HasMany(x => x.ProductPictures).WithOne(x => x.Product).HasForeignKey(x => x.ProductId);
        }
    }
}
