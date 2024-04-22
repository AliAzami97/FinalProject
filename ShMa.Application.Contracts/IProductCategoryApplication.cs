using FrameWork.Application;
using FrameWork.Domain;
using System.Linq.Expressions;

namespace ShMa.Application.Contracts
{
    public interface IProductCategoryApplication
    {
        OperationResult Create (CreateProductCategory command);
        OperationResult Edit(EditProductCategory command);
        EditProductCategory GetDetails(long id);
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel);
        void Save();
    }
}