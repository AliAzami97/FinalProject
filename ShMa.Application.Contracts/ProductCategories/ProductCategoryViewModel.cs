namespace ShMa.Application.Contracts.ProductCategories
{
    public class ProductCategoryViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string CreationDate { get; set; }
        public long ProductCount { get; set; }
    }
}
