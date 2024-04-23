using FrameWork.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShMa.Application.Contracts.Products;
using ShMa.Domain.ProductAgg;
using System.Linq.Expressions;

namespace ShMa.Infrastructure.EfCore.Repositories
{
    public class ProductRepository : RepositoryBase<long , Product> , IProductRepository
    {
        private readonly FinalContext _context;

        public ProductRepository(FinalContext context) : base(context)
        {
            _context = context;
        }

        public EditProduct GetDetails(long id)
        {
            return _context.Products.Select(x=> new EditProduct 
            {
             Id = x.Id,
             Name = x.Name,
             Code = x.Code,
             Image = x.Image,
             ImageAlt = x.ImageAlt,
             ImageTitle = x.ImageTitle,
             CategoryId = x.CategoryId,
             MetaDescription = x.MetaDescription,
             Description = x.Description,
             ShortDescription = x.ShortDescription,
             Keyword = x.Keyword,
             Slug = x.Slug,
             UnitPrice = x.UnitPrice
            }).FirstOrDefault(x=> x.Id == id);    
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            var query = _context.Products.Include(x=> x.Category).Select(x=> new ProductViewModel
            {
                Id = x.Id,
                Name  = x.Name,
                Code = x.Code,
                Image = x.Image,
                Category = x.Category.Name,
                CategoryId = x.CategoryId,
                UnitPrice = x.UnitPrice,
            });

            if(!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x=> x.Name.Contains(searchModel.Name));

            if (!string.IsNullOrWhiteSpace(searchModel.Code))
                query = query.Where(x => x.Code.Contains(searchModel.Code));
            if(searchModel.CategoryId != 0)
                query = query.Where(x=> x.CategoryId == searchModel.CategoryId);

            return query.OrderByDescending(x=>x.Id).ToList();
        }
    }
}
