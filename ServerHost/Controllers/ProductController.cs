using FrameWork.Application;
using Microsoft.AspNetCore.Mvc;
using ShMa.Application.Contracts.Products;

namespace ServerHost.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductApplication _productApplication;
        public ProductController(IProductApplication productApplication)
        {
            _productApplication = productApplication;
        }

        [HttpPost]
        public async Task<OperationResult> Create(CreateProduct command)
        {
            return _productApplication.Create(command);
        }

        [HttpPut]
        public async Task<OperationResult> Edit(EditProduct command)
        {
            return _productApplication.Edit(command);
        }

        [HttpGet(template: "GetDetails")]
        public EditProduct GetDetails(long id)
        {
            return _productApplication.GetDetails(id);
        }

        [HttpGet(template: "Search")]
        public List<ProductViewModel> Search([FromQuery] ProductSearchModel searchModel)
        {
            return _productApplication.Search(searchModel);
        }


        [HttpPut(template: "OnPostUnDelete")]
        public void OnPostUnDelete(long id)
        {
            _productApplication.UnDelete(id);
        }

        [HttpPut(template: "OnPostDelete")]
        public void OnPostDelete(long id)
        {
            _productApplication.Delete(id);
        }
    }
}
