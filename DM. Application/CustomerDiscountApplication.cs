using Dm._Domain.DiscountAgg;
using DM._Application.Contracts.CustomerDiscounts;
using FrameWork.Application;
using FrameWork.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace DM._Application
{
    public class CustomerDiscountApplication : ICustomerDiscountApplication
    {
        private readonly ICustomerDiscountRepository _discountRepository;

        public CustomerDiscountApplication(ICustomerDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }

        public OperationResult Create(CreateCustomerDiscount command)
        {
            var operation = new OperationResult();
            if (_discountRepository.Exists(x => x.ProdutId == command.ProdutId))
            {
                operation.Failed(ApplicationMessages.DuplicatedRecord);
            }
            //var create = new CustomerDiscount(command.ProdutId, command.DiscountRate, /*command.StartDate.ToString()*/
                /*command.EndDate*//* command.Reason);*/

            //_discountRepository.Create(create);
            _discountRepository.Save();
                return operation.Succesfull();
        }

        public OperationResult Edit(EditCustomerDiscount command)
        {
            var operation = new OperationResult();
            var edit = _discountRepository.GetBy(command.Id);
            if (edit == null)
            {
                operation.Failed(ApplicationMessages.RecordNotFound);
            }

            if(edit.ProdutId == command.ProdutId && edit.Id != command.Id) 
            {
                operation.Failed(ApplicationMessages.DuplicatedRecord);
            }
            //edit.Edit(command.ProdutId, command.DiscountRate, command.StartDate, command.EndDate, command.Reason);
            _discountRepository.Save();
            return operation.Succesfull();

        }

        public EditCustomerDiscount GetDetails(long id)
        {
            return _discountRepository.GetDetails(id);
        }

        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel)
        {
            return _discountRepository.Search(searchModel);
        }
    }
}
