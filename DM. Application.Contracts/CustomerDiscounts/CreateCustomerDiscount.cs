namespace DM._Application.Contracts.CustomerDiscounts
{
    public class CreateCustomerDiscount
    {
        public long ProdutId { get; set; }
        public int DiscountRate { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Reason { get; set; }
    }
}
