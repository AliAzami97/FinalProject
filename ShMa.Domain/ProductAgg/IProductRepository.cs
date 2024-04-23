using FrameWork.Domain;
using ShMa.Application.Contracts.Products;

namespace ShMa.Domain.ProductAgg
{
    public interface IProductRepository : IRepository<long , Product>
    {
        List<ProductViewModel> Search(ProductSearchModel searchModel);
        EditProduct GetDetails(long id);
    }
}
