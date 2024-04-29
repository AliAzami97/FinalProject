using FrameWork.Application;
using Microsoft.AspNetCore.Mvc;
using ShMa.Application.Contracts.ProductPictures;

namespace ServerHost.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductPictureController : ControllerBase
    {
        private readonly IProductPictureApplication _productPictureApplication;

        public ProductPictureController(IProductPictureApplication productPictureApplication)
        {
            _productPictureApplication = productPictureApplication;
        }

        [HttpPost]
        public OperationResult Create(CreateProductPicture command)
        {
            return _productPictureApplication.Create(command);
        }

        [HttpPut]
        public OperationResult Edit(EditProductPicture command)
        {
            return _productPictureApplication.Edit(command);
        }

        [HttpPut(template: "UnDelete")]
        public OperationResult UnDelete(long id)
        {
            return _productPictureApplication.Restore(id); 
        }

        [HttpPut(template: "Delete")]
        public OperationResult Delete(long id)
        {
            return _productPictureApplication.Remove(id);
        }

        [HttpGet(template: "Search")]
        public List<ProductPictureViewModel> Search([FromQuery]ProductPictureSearchModel searchModel)
        {
            return _productPictureApplication.Search(searchModel);
        }

        [HttpGet(template: "GetDetails")]
        public EditProductPicture GetDetails(long id)
        {
            return _productPictureApplication.GetDetails(id);
        }
    }
}
