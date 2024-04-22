using Microsoft.EntityFrameworkCore;
using ShMa.Domain.ProductCategoryAgg;
using ShMa.Infrastructure.EfCore.Mapping;

namespace ShMa.Infrastructure.EfCore
{
    public class FinalContext : DbContext
    {
        public DbSet<ProductCategory> productCategories { get; set; }

        public FinalContext(DbContextOptions<FinalContext> options) : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(FinalContext).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
