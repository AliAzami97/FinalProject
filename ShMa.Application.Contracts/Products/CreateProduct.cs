namespace ShMa.Application.Contracts.Products
{
    public class CreateProduct
    {
        public string Name { get;  set; }
        public string Code { get;  set; }
        public string Image { get;  set; }
        public string ImageTitle { get;  set; }
        public string ImageAlt { get; set; }
        public long CategoryId { get; set; }
        public string MetaDescription { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Keyword { get; set; }
        public string Slug { get; set; }
        public double UnitPrice { get; set; }
    }
}
