using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShMa.Domain.ProductPictureAgg;

namespace ShMa.Infrastructure.EfCore.Mapping
{
    public class ProductPictureMapping : IEntityTypeConfiguration<ProductPicture>
    {
        public void Configure(EntityTypeBuilder<ProductPicture> builder)
        {
            builder.ToTable("ProductPictures");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Image).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.ImageAlt).HasMaxLength(500).IsRequired();
            builder.Property(x => x.ImageTitle).HasMaxLength(500).IsRequired();

            builder.HasOne(x=> x.Product).WithMany(x=> x.ProductPictures).HasForeignKey(x=>x.ProductId);
        }
    }
}
