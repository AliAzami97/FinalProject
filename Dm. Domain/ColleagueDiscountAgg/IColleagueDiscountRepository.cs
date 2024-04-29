using DM._Application.Contracts.ColleagueDiscounts;
using FrameWork.Domain;

namespace Dm._Domain.ColleagueDiscountAgg
{
    public interface IColleagueDiscountRepository : IRepository<long , ColleagueDiscount>
    {
        List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel);
        EditColleague GetDetails(long id);
    }
}
