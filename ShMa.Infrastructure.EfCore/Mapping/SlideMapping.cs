using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShMa.Domain.SliderAgg;

namespace ShMa.Infrastructure.EfCore.Mapping
{
    public class SlideMapping : IEntityTypeConfiguration<Slide>
    {
        public void Configure(EntityTypeBuilder<Slide> builder)
        {
            builder.ToTable("Slides");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Picture).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.PictureAlt).HasMaxLength(500).IsRequired();
            builder.Property(x => x.PictureTitle).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Heading).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Title).HasMaxLength(255);
            builder.Property(x => x.Text).HasMaxLength(255);
            builder.Property(x => x.BtnText).HasMaxLength(50).IsRequired();

            builder.HasOne(x=> x.Images).WithMany(x=> x.Slides).HasForeignKey(x=> x.Id);
        }
    }
}
