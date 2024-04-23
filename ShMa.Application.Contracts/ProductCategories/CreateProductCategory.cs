using FrameWork.Application;
using System.ComponentModel.DataAnnotations;

namespace ShMa.Application.Contracts.ProductCategories
{
    public class CreateProductCategory
    {

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string ImageTitle { get; set; }
        public string ImageAlt { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string KeyWord { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string MetaDescription { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Slug { get; set; }
    }
}
