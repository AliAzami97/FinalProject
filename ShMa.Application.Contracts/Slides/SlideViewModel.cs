using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShMa.Application.Contracts.Slides
{
    public class SlideViewModel
    {
        public long Id { get;  set; }
        public string Picture { get;  set; }
        public string Heading { get;  set; }
        public string Title { get;  set; }
        public bool IsRemoved { get; set; }
    }
}
