using FrameWork.Application;
using FrameWork.Domain;

namespace ShMa.Application.Contracts.Products
{
    public interface IProductApplication
    {
        OperationResult Create(CreateProduct command);
        OperationResult Edit(EditProduct command);
        void Delete(long id);
        void UnDelete(long id);
        List<ProductViewModel> Search(ProductSearchModel searchModel);
        EditProduct GetDetails(long id);
    }
}
