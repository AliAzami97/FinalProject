using FrameWork.Application;

namespace DM._Application.Contracts.CustomerDiscounts
{
    public interface ICustomerDiscountApplication
    {
        OperationResult Create(CreateCustomerDiscount command);
        OperationResult Edit(EditCustomerDiscount command);
        //OperationResult Activate (long id);
        //OperationResult Deactivate (long id);
        List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel);
        EditCustomerDiscount GetDetails(long id);
    }
}
