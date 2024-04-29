using Dm._Domain.ColleagueDiscountAgg;
using Dm._Domain.DiscountAgg;
using Microsoft.EntityFrameworkCore;

namespace Dm._Infrastructure
{
    public class DiscountContext : DbContext
    {
        public DbSet<CustomerDiscount> CustomerDiscounts { get; set; }
        public DbSet<ColleagueDiscount> ColleagueDiscounts { get; set; }


        public DiscountContext(DbContextOptions<DiscountContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(CustomerDiscount).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            base.OnModelCreating(modelBuilder);
        }

    }
}
