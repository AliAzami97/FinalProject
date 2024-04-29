namespace DM._Application.Contracts.CustomerDiscounts
{
    public class CustomerDiscountViewModel
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string Product { get; set; }
        public int DiscountRate { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public DateTime StartDatePr { get; set; }
        public DateTime EndDatePr { get; set; }
        public string Reason { get; set; }
    }
}
