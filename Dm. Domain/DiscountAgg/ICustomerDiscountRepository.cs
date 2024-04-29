using DM._Application.Contracts.CustomerDiscounts;
using FrameWork.Domain;

namespace Dm._Domain.DiscountAgg
{
    public interface ICustomerDiscountRepository : IRepository<long , CustomerDiscount>
    {
        List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel);
        EditCustomerDiscount GetDetails(long id);
    }
}
