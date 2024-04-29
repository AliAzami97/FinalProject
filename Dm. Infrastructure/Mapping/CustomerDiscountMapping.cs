using Dm._Domain.DiscountAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dm._Infrastructure.Mapping
{
    public class CustomerDiscountMapping : IEntityTypeConfiguration<CustomerDiscount>
    {
        public void Configure(EntityTypeBuilder<CustomerDiscount> builder)
        {
            builder.ToTable("Discounts");
            builder.HasKey(x=> x.Id);

            builder.Property(x=> x.ProdutId);
            builder.Property(x=> x.DiscountRate);
            builder.Property(x=> x.StartDate);
            builder.Property(x=> x.EndDate);
            builder.Property(x=> x.Reason);

        }
    }
}