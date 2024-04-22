using FrameWork.Domain;
using ShMa.Application.Contracts;
using System.Linq.Expressions;

namespace ShMa.Domain.ProductCategoryAgg
{
    public interface IProductCategoryRepository : IRepository<long , ProductCategory>
    {
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel);
        EditProductCategory GetDetails(long id);
    }
}
