using Dm._Domain.ColleagueDiscountAgg;
using DM._Application.Contracts.ColleagueDiscounts;
using FrameWork.Application;
using FrameWork.Infrastructure;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DM._Application
{
    public class ColleagueDiscountApplication : IColleagueDiscountApplication
    {
        private readonly IColleagueDiscountRepository _colleagueDiscountRepository;

        public ColleagueDiscountApplication(IColleagueDiscountRepository colleagueDiscountRepository)
        {
            _colleagueDiscountRepository = colleagueDiscountRepository;
        }

        public OperationResult Create(CreateCollegue command)
        {
            var operation = new OperationResult();
            if(_colleagueDiscountRepository.Exists(x=>x.ProductId == command.ProductId))
            {
                operation.Failed(ApplicationMessages.DuplicatedRecord);
            }
            var create = new ColleagueDiscount(command.ProductId, command.DiscountRate);
            _colleagueDiscountRepository.Create(create);
            _colleagueDiscountRepository.Save();
            return operation.Succesfull();
        }

        public OperationResult Edit(EditColleague command)
        {
            var operation = new OperationResult();
            var edit = _colleagueDiscountRepository.GetBy(command.Id);
            if(edit == null) 
            {
                operation.Failed(ApplicationMessages.RecordNotFound);
            }
            if(_colleagueDiscountRepository.Exists(x=> x.ProductId == command.ProductId && x.Id != command.Id))
            {
                operation.Failed(ApplicationMessages.DuplicatedRecord);
            }

            edit.Edit(command.ProductId, command.DiscountRate);
            _colleagueDiscountRepository.Save();
            return operation.Succesfull();
        }

        public EditColleague GetDetails(long id)
        {
            return _colleagueDiscountRepository.GetDetails(id);
        }

        public OperationResult Removed(long id)
        {
            var operation = new OperationResult();
            var delete = _colleagueDiscountRepository.GetBy(id);
            if (delete == null)
            {
                operation.Failed(ApplicationMessages.RecordNotFound);
            }
            delete.Removed();
            _colleagueDiscountRepository.Save();
            return operation.Succesfull();
        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();
            var restore = _colleagueDiscountRepository.GetBy(id);
            if (restore == null)
            {
                operation.Failed(ApplicationMessages.RecordNotFound);
            }
            restore.Restored();
            _colleagueDiscountRepository.Save();
            return operation.Succesfull();
        }

        public List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel)
        {
            return _colleagueDiscountRepository.Search(searchModel);
        }
    }
}
