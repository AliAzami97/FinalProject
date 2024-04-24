using FrameWork.Domain;
using ShMa.Domain.ProductAgg;

namespace ShMa.Domain.ProductPictureAgg
{
    public class ProductPicture : EntityBase
    {
        public long ProductId { get; private set; }
        public string Image { get; private set; }
        public string ImageTitle { get; private set; }
        public string ImageAlt  { get; private set; }
        public bool IsRemoved { get; private set; }
        public Product Product { get; private set; }

        public ProductPicture(long productId, string image, string imageTitle, string imageAlt)
        {
            ProductId = productId;
            Image = image;
            ImageTitle = imageTitle;
            ImageAlt = imageAlt;
            IsRemoved = false;
        }

         public void Edit(long productId, string image, string imageTitle, string imageAlt)
         {
            ProductId = productId;
            Image = image;
            ImageTitle = imageTitle;
            ImageAlt = imageAlt;
         }

        public void Removed() 
        {
            IsRemoved = true;        
        }

        public void Restore()
        {
            IsRemoved = false; 
        }
    }
}
