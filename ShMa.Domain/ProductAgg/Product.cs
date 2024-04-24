using FrameWork.Domain;
using ShMa.Domain.ProductCategoryAgg;
using ShMa.Domain.ProductPictureAgg;

namespace ShMa.Domain.ProductAgg
{
    public class Product : EntityBase
    {
        public string Name { get; private set; }
        public string Code { get; private set; }
        public string Image { get; private set; }
        public string ImageTitle { get; private set; }
        public string ImageAlt { get; private set; }
        public long CategoryId { get; private set; }
        public ProductCategory Category { get; private set; }
        public string MetaDescription { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public string Keyword { get; private set; }
        public string Slug { get; private set; }
        public double UnitPrice { get; private set; }
        public bool IsInStock { get; private set; }
        public ICollection<ProductPicture> ProductPictures { get; private set; }

        public Product(string name, string code, string image, string imageTitle, string imageAlt, long categoryId, string metaDescription, string shortDescription, string description, string keyword, string slug, double unitPrice)
        {
            Name = name;
            Code = code;
            Image = image;
            ImageTitle = imageTitle;
            ImageAlt = imageAlt;
            CategoryId = categoryId;
            MetaDescription = metaDescription;
            ShortDescription = shortDescription;
            Description = description;
            Keyword = keyword;
            Slug = slug;
            UnitPrice = unitPrice;
            IsInStock = true;
        }

        public void Edit(string name, string code, string image, string imageTitle, string imageAlt, long categoryId, string metaDescription, string shortDescription, string description, string keyword, string slug, double unitPrice)
        {
            Name = name;
            Code = code;
            Image = image;
            ImageTitle = imageTitle;
            ImageAlt = imageAlt;
            CategoryId = categoryId;
            MetaDescription = metaDescription;
            ShortDescription = shortDescription;
            Description = description;
            Keyword = keyword;
            Slug = slug;
            UnitPrice = unitPrice;
        }

        public void InStock()
        {
            IsInStock = true;
        }

        public void NotInStock()
        {
            IsInStock = false;
        }
    }
}
