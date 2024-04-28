using FrameWork.Domain;
using ShMa.Domain.ProductPictureAgg;

namespace ShMa.Domain.SliderAgg
{
    public class Slide : EntityBase
    {
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Heading { get; private set; }
        public string Title { get; private set; }
        public string Text { get; private set; }
        public string BtnText { get; private set; }
        public bool IsRemoved { get; private set; }
        public ProductPicture Images { get; set; }

        public Slide(string picture, string pictureAlt, string pictureTitle, string heading, string title, string text, string btnText)
        {
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Heading = heading;
            Title = title;
            Text = text;
            BtnText = btnText;
            IsRemoved = false;
        }

        public void Edit(string picture, string pictureAlt, string pictureTitle, string heading, string title, string text, string btnText)
        {
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Heading = heading;
            Title = title;
            Text = text;
            BtnText = btnText;
        }

        public void Delete()
        {
            IsRemoved = true;
        }

        public void UnDelete() 
        {
            IsRemoved = false;
        }
    }
}
