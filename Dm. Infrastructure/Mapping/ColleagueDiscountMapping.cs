using Dm._Domain.ColleagueDiscountAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dm._Infrastructure.Mapping
{
    public class ColleagueDiscountMapping : IEntityTypeConfiguration<ColleagueDiscount>
    {
        public void Configure(EntityTypeBuilder<ColleagueDiscount> builder)
        {
            builder.ToTable("Discounts");
            builder.HasKey(x => x.Id);
        }
    }
}
