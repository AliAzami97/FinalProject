using Dm._Domain.ColleagueDiscountAgg;
using Dm._Domain.DiscountAgg;
using Dm._Infrastructure;
using Dm._Infrastructure.Repositories;
using DM._Application;
using DM._Application.Contracts.ColleagueDiscounts;
using DM._Application.Contracts.CustomerDiscounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Dm._Infrastructure_Management
{
    public class DiscountBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<ICustomerDiscountRepository, DiscountRepository>();
            services.AddTransient<ICustomerDiscountApplication, CustomerDiscountApplication>();

            services.AddTransient<IColleagueDiscountRepository , ColleagueDiscountRepository>();
            services.AddTransient<IColleagueDiscountApplication ,  ColleagueDiscountApplication>();

            services.AddDbContext<DiscountContext>(x=> x.UseSqlServer(connectionString));

        }
    }
}
