using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShMa.Application.Contracts.ProductCategories;
using ShMa.Application.Contracts.ProductPictures;
using ShMa.Application.Contracts.Products;
using ShMa.Application.Contracts.Slides;
using ShMa.Application.ProductApp;
using ShMa.Application.ProductCategori;
using ShMa.Application.ProductPictureApplication;
using ShMa.Application.SlideApplication;
using ShMa.Domain.ProductAgg;
using ShMa.Domain.ProductCategoryAgg;
using ShMa.Domain.ProductPictureAgg;
using ShMa.Domain.SliderAgg;
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

            services.AddTransient<IProductPictureApplication, ProductPictureApplication>();
            services.AddTransient<IProductPictureRepository, ProductPictureRepository>();

            services.AddTransient<ISlideApplication, SlideApplication>();
            services.AddTransient<ISlideRepository, SlideRepository>();

            services.AddDbContext<FinalContext>(x=> x.UseSqlServer(connectionstring));
            
        }
    }
}