using FrameWork.Application;
using ShMa.Application.Contracts;
using ShMa.Domain.ProductCategoryAgg;
using System.Linq.Expressions;

namespace ShMa.Application
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public OperationResult Create(CreateProductCategory command)
        {
            var operation = new OperationResult();
            if(_productCategoryRepository.Exists(x=> x.Name == command.Name))
            {
                operation.Failed("خطا - نام تکراری وارد شده است. لطقا نام را صحیح وارد نمایید");
            }
            operation.Succesfull();

            var create = new ProductCategory(command.Name, command.Description, command.Image, command.ImageTitle,
                command.KeyWord, command.ImageAlt, command.MetaDescription, command.Slug);
            _productCategoryRepository.Create(create);
            _productCategoryRepository.Save();
            return operation.Succesfull();
        }

        public OperationResult Edit(EditProductCategory command)
        {
            var operation = new OperationResult();
            var edit = _productCategoryRepository.GetBy(command.Id);
            if (edit == null)
            { operation.Failed("خطا - رکورد موردنظر یافت نشد. دوباره تلاش کنید");
            }

            if (_productCategoryRepository.Exists(x => x.Id != command.Id && x.Name == command.Name))
            {
                operation.Failed("نام رکورد تکراری می باشد.لطفا مجدد تلاش کنید");
            }
            
            edit.Edit(command.Name, command.Description, command.Image, command.ImageTitle,
                command.ImageAlt, command.KeyWord, command.MetaDescription, command.Slug);
            _productCategoryRepository.Save();

            return operation.Succesfull();
        }

        public EditProductCategory GetDetails(long id)
        {
           return _productCategoryRepository.GetDetails(id);
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            return _productCategoryRepository.Search(searchModel);
        }

        public void Save()
        {
            _productCategoryRepository.Save();
        }
    }
}
