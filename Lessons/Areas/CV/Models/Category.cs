using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lessons.Areas.CV.Models
{
    public class Category
    {
        public string Name { get; set; }
        public List<CategoryItem> CategoryItems { get; set; }
    }

}
