using ShMa.Application.Contracts.Products;

namespace DM._Application.Contracts.ColleagueDiscounts
{
    public class CreateCollegue
    {
        public long ProductId { get;  set; }
        public int DiscountRate { get;  set; }
        public List<ProductViewModel> Products { get; set; }
    }
}
