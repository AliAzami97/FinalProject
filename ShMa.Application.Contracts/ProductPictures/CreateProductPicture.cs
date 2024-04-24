namespace ShMa.Application.Contracts.ProductPictures
{
    public class CreateProductPicture
    {
        public long ProductId { get; set; }
        public string Image { get; set; }
        public string ImageTitle { get; set; }
        public string ImageAlt { get; set; }
    }
}
