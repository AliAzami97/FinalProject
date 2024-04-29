using Azure;
using FrameWork.Application;
using Microsoft.AspNetCore.Mvc;
using ShMa.Application.Contracts.ProductCategories;
using ShMa.Application.Contracts.Products;
using ShMa.Application.Contracts.Slides;
using ShMa.Application.ProductApp;
using ShMa.Domain.ProductAgg;
using ShMa.Infrastructure.EfCore.Repositories;

namespace ServerHost.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SlideController : ControllerBase
    {
        private readonly ISlideApplication _slideApplication;
        public SlideController(ISlideApplication slideApplication)
        {
            _slideApplication = slideApplication;
        }

        [HttpPost]
        public OperationResult Create(CreateSlide command)
        {
            return _slideApplication.Create(command);
        }

        [HttpPut]
        public  OperationResult Edit(EditSlide command)
        {
            return _slideApplication.Edit(command);
        }

        [HttpGet(template: "GetDetails")]
        public EditSlide GetDetails(long id)
        {
            return _slideApplication.GetDetails(id);
        }

        [HttpPut(template: "Remove")]
        public OperationResult Remove(long id)
        {
           return _slideApplication.Remove(id);
        }

        [HttpPut(template: "Restore")]
        public OperationResult Restore(long id)
        {
           return _slideApplication.ReStore(id);
        }

        [HttpGet(template: "GetList")]
        public List<SlideViewModel> GetList()
        {
            return _slideApplication.GetList();
        }
    }
}
