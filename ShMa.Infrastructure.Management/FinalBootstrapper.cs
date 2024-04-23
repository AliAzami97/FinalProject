using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShMa.Application.Contracts.ProductCategories;
using ShMa.Application.Contracts.Products;
using ShMa.Application.ProductApp;
using ShMa.Application.ProductCategori;
using ShMa.Domain.ProductAgg;
using ShMa.Domain.ProductCategoryAgg;
using ShMa.Infrastructure.EfCore;
using ShMa.Infrastructure.EfCore.Repositories;

namespace ShMa.Infrastructure.Management
{
    public class FinalBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionstring)
        {
            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();

            services.AddTransient<IProductApplication, ProductApplication>();
            services.AddTransient<IProductRepository, ProductRepository>();

            services.AddDbContext<FinalContext>(x=> x.UseSqlServer(connectionstring));
            
        }
    }
}