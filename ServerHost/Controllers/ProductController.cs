using FrameWork.Application;
using Microsoft.AspNetCore.Mvc;
using ShMa.Application.Contracts.ProductCategories;
using ShMa.Application.Contracts.Products;
using ShMa.Domain.ProductAgg;

namespace ServerHost.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductApplication _productApplication;
        public ProductController(IProductApplication productApplication, IProductRepository productRepository)
        {
            _productApplication = productApplication;
            _productRepository = productRepository;
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

        [HttpGet]
        public EditProduct GetDetails(long id)
        {
           return _productApplication.GetDetails(id);
        }

        [HttpDelete]
        public IActionResult NotInStock(long id)
        {
            var operation = _productRepository.GetBy(id);
            if (operation.IsInStock == true)
                operation.InStock();

            else
                operation.NotInStock();
            return RedirectToPage("./Index");

        }
    }
}
