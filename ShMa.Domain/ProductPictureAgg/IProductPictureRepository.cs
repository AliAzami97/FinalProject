using FrameWork.Application;
using FrameWork.Domain;
using ShMa.Application.Contracts.ProductPictures;

namespace ShMa.Domain.ProductPictureAgg
{
    public interface IProductPictureRepository : IRepository<long , ProductPicture>
    {
        List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel);
        EditProductPicture GetDetails(long id);
    }
}
