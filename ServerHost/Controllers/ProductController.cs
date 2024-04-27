using Azure;
using FrameWork.Application;
using Microsoft.AspNetCore.Mvc;
using ShMa.Application.Contracts.ProductCategories;
using ShMa.Application.Contracts.Products;
using ShMa.Application.ProductApp;
using ShMa.Domain.ProductAgg;
using ShMa.Infrastructure.EfCore.Repositories;

namespace ServerHost.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
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

        [HttpGet]
        public EditProduct GetDetails(long id)
        {
            return _productApplication.GetDetails(id);
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
