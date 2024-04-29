using FrameWork.Domain;

namespace Dm._Domain.DiscountAgg
{
    public class CustomerDiscount : EntityBase
    {
        public long ProdutId { get; private set; }
        public int DiscountRate { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string Reason { get; private set; }

        public CustomerDiscount(long produtId, int discountRate, DateTime startDate, DateTime endDate, string reason)
        {
            ProdutId = produtId;
            DiscountRate = discountRate;
            StartDate = startDate;
            EndDate = endDate;
            Reason = reason;
        }

        public void Edit(long produtId, int discountRate, DateTime startDate, DateTime endDate, string reason)
        {
            ProdutId = produtId;
            DiscountRate = discountRate;
            StartDate = startDate;
            EndDate = endDate;
            Reason = reason;
        }


    }
}
