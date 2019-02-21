using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lessons.Areas.CV.Models.ViewModels
{
    public class ViewModel
    {
        public PersonalInfo PersonalInfo { get; set; }
        public List<Category> Categories { get; set; } = new List<Category>();
        public string[] Skills { get; set; }
        public string[] Languages { get; set; }
    }
}
