using FrameWork.Infrastructure;
using ShMa.Application.Contracts;
using ShMa.Domain.ProductCategoryAgg;
using System.Linq.Expressions;

namespace ShMa.Infrastructure.EfCore.Repositories
{
    public class ProductCategoryRepository : RepositoryBase<long , ProductCategory> , IProductCategoryRepository
    {

        private readonly FinalContext _context;

        public ProductCategoryRepository(FinalContext context) : base(context)
        {
            _context = context;
        }

        public EditProductCategory GetDetails(long id)
        {
           return _context.productCategories.Select(x=> new EditProductCategory()
           {
               Id = x.Id,
               Name = x.Name,
               Description = x.Description,
               MetaDescription = x.MetaDescription,
               ImageTitle = x.ImageTitle,
               ImageAlt = x.ImageAlt,
               Slug = x.Slug,
               KeyWord = x.KeyWord,
               Image = x.Image
           }).FirstOrDefault(x=> x.Id == id);
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            var query = _context.productCategories.Select(x => new ProductCategoryViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Image = x.Image,
                CreationDate = x.CreationDate.ToString()
            });

            if(!string.IsNullOrWhiteSpace(searchModel.Name))
            {
                query = query.Where(x => x.Name.Contains(searchModel.Name));
            }

            return query.OrderByDescending(x => x.Id).ToList();
        }

    }
}
