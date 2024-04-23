using FrameWork.Domain;
using ShMa.Domain.ProductAgg;

namespace ShMa.Domain.ProductCategoryAgg
{
    public class ProductCategory : EntityBase
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Image { get; private set; }
        public string ImageTitle { get; private set; }
        public string ImageAlt { get; private set; }
        public string KeyWord { get; private set; }
        public string MetaDescription { get; private set; }
        public string Slug { get; private set; }
        public ICollection<Product> Productsz { get; set; }

        public ProductCategory(string name, string description, string image, string imageTitle, string imageAlt, string keyWord, string metaDescription, string slug)
        {
            Name = name;
            Description = description;
            Image = image;
            ImageTitle = imageTitle;
            ImageAlt = imageAlt;
            KeyWord = keyWord;
            MetaDescription = metaDescription;
            Slug = slug;
            Productsz = new List<Product>();
        }

        public void Edit(string name, string description, string image, string imageTitle, string imageAlt, string keyWord, string metaDescription, string slug)
        {
            Name = name;
            Description = description;
            Image = image;
            ImageTitle = imageTitle;
            ImageAlt = imageAlt;
            KeyWord = keyWord;
            MetaDescription = metaDescription;
            Slug = slug;
        }
    }
}
