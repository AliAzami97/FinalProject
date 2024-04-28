using FrameWork.Application;

namespace ShMa.Application.Contracts.Slides
{
    public interface ISlideApplication
    {
        OperationResult Create(CreateSlide command);
        OperationResult Edit(EditSlide command);
        OperationResult Remove(long id);
        OperationResult ReStore(long id);
        EditSlide GetDetails(long id);
        List<SlideViewModel> GetList();
    }
}
