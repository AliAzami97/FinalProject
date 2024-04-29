using Dm._Domain.DiscountAgg;
using DM._Application.Contracts.CustomerDiscounts;
using FrameWork.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShMa.Infrastructure.EfCore;

namespace Dm._Infrastructure.Repositories
{
    public class DiscountRepository : RepositoryBase<long, CustomerDiscount>, ICustomerDiscountRepository
    {
        private readonly DiscountContext _Context;
        private readonly FinalContext _FinalContext;
        public DiscountRepository(DiscountContext context, FinalContext finalContext) : base(context)
        {
            _Context = context;
            _FinalContext = finalContext;
        }

        public EditCustomerDiscount GetDetails(long id)
        {
            return _Context.CustomerDiscounts.Select(x => new EditCustomerDiscount
            {
                Id = x.Id,
                ProdutId = x.ProdutId,
                StartDate = x.StartDate.ToString(),
                EndDate = x.EndDate.ToString(),
                DiscountRate = x.DiscountRate,
                Reason = x.Reason
            }).FirstOrDefault(x => x.Id == id);

        }

        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel)
        {
            var products = _FinalContext.Products.Select(x => new { x.Id, x.Name }).ToList();
            var query = _Context.CustomerDiscounts.Select(x => new CustomerDiscountViewModel
            {
                Id = x.Id,
                ProductId = x.ProdutId,
                DiscountRate = x.DiscountRate,
                StartDate = x.StartDate.ToString(),
                EndDate = x.EndDate.ToString(),
                StartDatePr = x.StartDate,
                EndDatePr = x.EndDate,
                Reason = x.Reason,
            });

            if (searchModel.ProductId > 0)
                query = query.Where(x => x.ProductId == searchModel.ProductId);

            if (!string.IsNullOrWhiteSpace(searchModel.StartDate))
            {
                var startDate = DateTime.Now;
                query = query.Where(x => x.StartDatePr > startDate);
            }

            if (!string.IsNullOrWhiteSpace(searchModel.EndDate))
            {
                var EndDate = DateTime.Now;
                query = query.Where(x => x.EndDatePr < EndDate);
            }

            var discount = query.OrderByDescending(x => x.Id).ToList();

            discount.ForEach(discount => discount.Product = products.FirstOrDefault(x => x.Id == discount.ProductId)?.Name);

            return discount;
        }
    }
}
