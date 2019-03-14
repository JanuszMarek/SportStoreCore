using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lessons.Areas.CV.Models
{
    public class CategoryItem
    {
        public string PhotoUrl { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string[] Years { get; set; }
        public string[] Responsibility { get; set; }
    }
}
