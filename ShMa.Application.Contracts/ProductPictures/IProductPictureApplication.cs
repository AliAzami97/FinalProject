using FrameWork.Application;

namespace ShMa.Application.Contracts.ProductPictures
{
    public interface IProductPictureApplication 
    {
        OperationResult Create(CreateProductPicture command);
        OperationResult Edit(EditProductPicture command);
        List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel);
        EditProductPicture GetDetails(long id);
        OperationResult Remove(long id);
        OperationResult Restore(long id);
    }
}
