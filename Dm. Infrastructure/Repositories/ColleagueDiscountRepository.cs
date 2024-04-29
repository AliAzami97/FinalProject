using Dm._Domain.ColleagueDiscountAgg;
using DM._Application.Contracts.ColleagueDiscounts;
using FrameWork.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShMa.Infrastructure.EfCore;

namespace Dm._Infrastructure.Repositories
{
    public class ColleagueDiscountRepository : RepositoryBase<long, ColleagueDiscount> , IColleagueDiscountRepository
    {
        private readonly DiscountContext _discountContext;
        private readonly FinalContext _finalContext;
        public ColleagueDiscountRepository(DiscountContext context, FinalContext finalContext) : base(context)
        {
            _discountContext = context;
            _finalContext = finalContext;
        }

        public EditColleague GetDetails(long id)
        {
            return _discountContext.ColleagueDiscounts.Select(x=> new EditColleague
            {
                Id = x.Id,
                DiscountRate = x.DiscountRate,
                ProductId = x.ProductId,
            }).FirstOrDefault(x=> x.Id == id);
        }

        public List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel)
        {
            var products = _finalContext.Products.Select(x => new { x.Id, x.Name }).ToList();
            var query = _discountContext.ColleagueDiscounts.Select(x => new ColleagueDiscountViewModel
            {
                Id = x.Id,
                ProductId = x.ProductId,
                DiscountRate = x.DiscountRate,
                CreationDate = x.CreationDate.ToString(),
            });

            if(searchModel.ProductId > 0) 
            {
                query = query.Where(x => x.ProductId == searchModel.ProductId);
            }

            var discount = query.OrderByDescending(x=> x.Id).ToList();
            discount.ForEach(discount => discount.Product = products.FirstOrDefault(x => x.Id == discount.ProductId)?.Name);
            return discount;
        }
    }
} 
