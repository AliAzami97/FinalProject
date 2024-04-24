using FrameWork.Domain;
using FrameWork.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShMa.Application.Contracts.ProductPictures;
using ShMa.Domain.ProductPictureAgg;
using System.Linq.Expressions;

namespace ShMa.Infrastructure.EfCore.Repositories
{
    public class ProductPictureRepository : RepositoryBase<long, ProductPicture>, IProductPictureRepository
    {
        private readonly FinalContext _context;

        public ProductPictureRepository(FinalContext context) : base(context)
        {
            _context = context;
        }

        public EditProductPicture GetDetails(long id)
        {
            var productPicture = _context.ProductPictures.Select(x => new EditProductPicture
            {
                Id = x.Id,
                Image = x.Image,
                ImageAlt = x.ImageAlt,
                ImageTitle = x.ImageTitle,
                ProductId = x.ProductId,
            }).FirstOrDefault(x => x.Id == id);
            return productPicture;
        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel)
        {
            var query = _context.ProductPictures.Include(x => x.Product).Select(x => new ProductPictureViewModel
            {
                Id = x.Id,
                Image = x.Image,
                Product = x.Product.Name,
                CreationDate = x.CreationDate.ToString(),
                ProducdId = x.ProductId,
            });
            if(searchModel.ProductId != 0)
                query = query.Where(x=> x.ProducdId == searchModel.ProductId);
            return query.OrderByDescending(x=> x.Id).ToList();
            ;
        }
    }
}
