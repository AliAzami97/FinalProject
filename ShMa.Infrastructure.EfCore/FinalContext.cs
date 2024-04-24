using Microsoft.EntityFrameworkCore;
using ShMa.Domain.ProductAgg;
using ShMa.Domain.ProductCategoryAgg;
using ShMa.Domain.ProductPictureAgg;
using ShMa.Infrastructure.EfCore.Mapping;

namespace ShMa.Infrastructure.EfCore
{
    public class FinalContext : DbContext
    {
        public DbSet<ProductCategory> productCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPicture> ProductPictures { get; set; }

        public FinalContext(DbContextOptions<FinalContext> options) : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ProductCategoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
