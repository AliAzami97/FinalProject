using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShMa.Application;
using ShMa.Application.Contracts;
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

            services.AddDbContext<FinalContext>(x=> x.UseSqlServer(connectionstring));
            
        }
    }
}