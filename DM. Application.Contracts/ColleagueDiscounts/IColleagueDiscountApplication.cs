using FrameWork.Application;

namespace DM._Application.Contracts.ColleagueDiscounts
{
    public interface IColleagueDiscountApplication
    {
        OperationResult Create(CreateCollegue command);
        OperationResult Edit(EditColleague command);
        OperationResult Removed(long id);
        OperationResult Restore(long id);
        List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel);
        EditColleague GetDetails(long id);
    }
}
