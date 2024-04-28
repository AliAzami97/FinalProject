using FrameWork.Application;
using ShMa.Application.Contracts.Slides;
using ShMa.Domain.SliderAgg;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ShMa.Application.SlideApplication
{
    public class SlideApplication : ISlideApplication
    {
        private readonly ISlideRepository _slideRepository;

        public SlideApplication(ISlideRepository slideRepository)
        {
            _slideRepository = slideRepository;
        }

        public OperationResult Create(CreateSlide command)
        {
            var operation = new OperationResult();
            var create = new Slide(command.Picture, command.PictureAlt, command.PictureTitle, command.Heading,
                command.Title, command.Text, command.BtnText);
            _slideRepository.Create(create);
            _slideRepository.Save();
            return operation.Succesfull();
        }

        public OperationResult Edit(EditSlide command)
        {
            var operation = new OperationResult();
            var edit = _slideRepository.GetBy(command.Id);
            if(edit == null)
            {
                operation.Failed("رکورد مورد نظر یافت نشد");
            }
            edit.Edit(command.Picture, command.PictureAlt, command.PictureTitle, command.Heading, 
                command.Title, command.Text, command.BtnText);
            _slideRepository.Save();
            return operation.Succesfull();
        }

        public EditSlide GetDetails(long id)
        {
            return _slideRepository.GetDetails(id);
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var remove = _slideRepository.GetBy(id);
            if (remove == null)
            {
                operation.Failed("رکورد مورد نظر یافت نشد");
            }
            remove.Delete();
            _slideRepository.Save();
            return operation.Succesfull();
        }

        public OperationResult ReStore(long id)
        {
            var operation = new OperationResult();
            var remove = _slideRepository.GetBy(id);
            if (remove == null)
            {
                operation.Failed("رکورد مورد نظر یافت نشد");
            }
            remove.UnDelete();
            _slideRepository.Save();
            return operation.Succesfull();
        }

        public List<SlideViewModel> GetList()
        {
            return _slideRepository.GetList();
        }
    }
}
