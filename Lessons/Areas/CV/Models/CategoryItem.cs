using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lessons.Areas.CV.Models
{
    public class CategoryItem
    {
        public CategoryItem()
        {
        }

        public CategoryItem(string title, string subTitle, string desc, string photoURL, string[] years, string[] resp)
        {
            Title = new HtmlString(title);
            SubTitle = new HtmlString(subTitle);
            Description = new HtmlString(desc);
            PhotoUrl = photoURL;
            Years = years;
            Responsibility = resp;
        }
        
        public string PhotoUrl { get; set; }
        public HtmlString Title
        {
            get;
            set;
        }

        public HtmlString SubTitle
        {
            get;
            set;
        }
        public HtmlString Description
        {
            get;
            set;
        }
        public string[] Years
        {
            get;
            set;
        }
        public string[] Responsibility
        {
            get;
            set;
        }
    }
}
