using FrameWork.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShMa.Application.Contracts.Slides;
using ShMa.Domain.SliderAgg;

namespace ShMa.Infrastructure.EfCore.Repositories
{
    public class SlideRepository : RepositoryBase<long, Slide>, ISlideRepository
    {
        private readonly FinalContext _context;
        public SlideRepository(FinalContext context) : base(context)
        {
            _context = context;
        }

        public EditSlide GetDetails(long id)
        {
          return  _context.Slides.Select(x => new EditSlide
            {
                Id = x.Id,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Heading = x.Heading,
                Title = x.Title,
                Text = x.Text,
                BtnText = x.BtnText,
            }).FirstOrDefault(x=> x.Id == id);
        }

        public List<SlideViewModel> GetList()
        {
            return _context.Slides.Select(x=> new SlideViewModel
            {
              Id = x.Id,
              Picture = x.Picture,
              Heading= x.Heading,
              Title= x.Title,
            }).OrderByDescending(x=> x.Id).ToList();
        }
    }
}
