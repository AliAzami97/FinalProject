using FrameWork.Domain;
using ShMa.Application.Contracts.Slides;

namespace ShMa.Domain.SliderAgg
{
    public interface ISlideRepository : IRepository<long , Slide>
    {
        EditSlide GetDetails(long id);
        List<SlideViewModel> GetList();
    }
}
