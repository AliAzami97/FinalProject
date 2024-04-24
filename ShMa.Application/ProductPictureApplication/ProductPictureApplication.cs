using FrameWork.Application;
using FrameWork.Domain;
using ShMa.Application.Contracts.ProductPictures;
using ShMa.Domain.ProductPictureAgg;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ShMa.Application.ProductPictureApplication
{
    public class ProductPictureApplication : IProductPictureApplication
    {
        private readonly IProductPictureRepository _productPictureRepository;

        public ProductPictureApplication(IProductPictureRepository productPictureRepository)
        {
            _productPictureRepository = productPictureRepository;
        }

        public OperationResult Create(CreateProductPicture command)
        {
            var operation = new OperationResult();
            if (_productPictureRepository.Exists(x => x.Image == command.Image && x.ProductId == command.ProductId))
            {
                operation.Failed(ApplicationMessages.DuplicatedRecord);
            }
            var create = new ProductPicture(command.ProductId, command.Image, command.ImageTitle, command.ImageAlt);
            _productPictureRepository.Create(create);
            _productPictureRepository.Save();
            return operation.Succesfull();
        }

        public OperationResult Edit(EditProductPicture command)
        {
            var operation = new OperationResult();
            var edit = _productPictureRepository.GetBy(command.Id);
            if (edit == null)
            {
                operation.Failed(ApplicationMessages.RecordNotFound);
            }

            if (_productPictureRepository.Exists(x => x.Image == command.Image && x.ProductId == command.ProductId &&
            x.Id != command.Id))
            {
                operation.Failed(ApplicationMessages.DuplicatedRecord);
            }

            edit.Edit(command.ProductId, command.Image, command.ImageTitle, command.ImageAlt);
            _productPictureRepository.Save();
            return operation.Succesfull();
        }

        public EditProductPicture GetDetails(long id)
        {
           return _productPictureRepository.GetDetails(id);
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var remove = _productPictureRepository.GetBy(id);
            if (remove == null)
            {
                operation.Failed(ApplicationMessages.RecordNotFound);
            }

            remove.Removed();
            _productPictureRepository.Save();
            return operation.Succesfull();
        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();
            var remove = _productPictureRepository.GetBy(id);
            if (remove == null)
            {
                operation.Failed(ApplicationMessages.RecordNotFound);
            }

            remove.Restore();
            _productPictureRepository.Save();
            return operation.Succesfull();
        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel)
        {
            return _productPictureRepository.Search(searchModel);
        }
    }
}
