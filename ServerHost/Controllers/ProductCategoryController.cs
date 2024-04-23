using FrameWork.Application;
using Microsoft.AspNetCore.Mvc;
using ShMa.Application.Contracts;

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
            return  _productCategoryApplication.Create(command);
        }



    }
}
