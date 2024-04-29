using FrameWork.Application;
using Microsoft.AspNetCore.Mvc;
using ShMa.Application.Contracts.ProductCategories;

namespace ServerHost.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryApplication _productCategoryApplication;
        public ProductCategoryController(IProductCategoryApplication productCategoryApplication)
        {
            _productCategoryApplication = productCategoryApplication;
        }

        [HttpPost]
        public async Task<OperationResult> Create(CreateProductCategory command)
        {
            return _productCategoryApplication.Create(command);
        }

        [HttpPut]
        public async Task<OperationResult> Edit(EditProductCategory command)
        {
            return _productCategoryApplication.Edit(command);
        }

        [HttpGet(template: "GetDetails")]
        public EditProductCategory GetDetails(long id)
        {
            return _productCategoryApplication.GetDetails(id);
        }

        [HttpGet(template: "Search")]
        public List<ProductCategoryViewModel> Search([FromQuery] ProductCategorySearchModel searchModel)
        {
            return _productCategoryApplication.Search(searchModel);
        }


    }
}
