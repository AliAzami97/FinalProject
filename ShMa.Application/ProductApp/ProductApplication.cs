using FrameWork.Application;
using ShMa.Application.Contracts.Products;
using ShMa.Domain.ProductAgg;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ShMa.Application.ProductApp
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _productRepository;

        public ProductApplication(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public OperationResult Create(CreateProduct command)
        {
            var operation = new OperationResult();
            if (_productRepository.Exists(x => x.Name == command.Name))
            {
                operation.Failed(ApplicationMessages.DuplicatedRecord);
            }

            var create1 = new Product(command.Name, command.Code, command.Image, command.ImageTitle, command.ImageAlt,
                command.CategoryId, command.MetaDescription, command.ShortDescription, command.Description,
                command.Keyword, command.Slug, command.UnitPrice);

            _productRepository.Create(create1);
            _productRepository.Save();
            return operation.Succesfull();
        }

        public OperationResult Edit(EditProduct command)
        {
            var operation = new OperationResult();
            var result = _productRepository.GetBy(command.Id);
            if (result == null)
            {
                operation.Failed(ApplicationMessages.RecordNotFound);
            }

            if (_productRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
            {
                operation.Failed(ApplicationMessages.DuplicatedRecord);
            }

            result.Edit(command.Name, command.Code, command.Image, command.ImageTitle, command.ImageAlt,
                command.CategoryId, command.MetaDescription, command.ShortDescription, command.Description,
                command.Keyword, command.Slug, command.UnitPrice);
            _productRepository.Save();
            return operation.Succesfull();
        }

        public EditProduct GetDetails(long id)
        {
            return _productRepository.GetDetails(id);
        }

        public OperationResult InStock(long id)
        {
            var operation = new OperationResult();
            var result = _productRepository.GetBy(id);
            if (result == null)
            {
                operation.Failed(ApplicationMessages.RecordNotFound);
            }

            result.InStock();
            _productRepository.Save();
            return operation.Succesfull();
        }

        public OperationResult NotInStock(long id)
        {
            var operation = new OperationResult();
            var result = _productRepository.GetBy(id);
            if (result == null)
            {
                operation.Failed(ApplicationMessages.RecordNotFound);
            }

            result.NotInStock();
            _productRepository.Save();
            return operation.Succesfull();
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
           return _productRepository.Search(searchModel);
        }
    }
}