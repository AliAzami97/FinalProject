namespace ShMa.Application.Contracts.Products
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Image { get; set; }
        public string Category { get; set; }
        public double UnitPrice { get; set; }
        public long CategoryId { get; set; }
    }
}