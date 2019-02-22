using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Lessons.Areas.UsingTagHelpers.Infrastructure.TagHelpers
{
    // [HtmlTargetElement("button", Attributes = "bs-button-color", ParentTag = "form")]

    //now it match not only for <button> but for every
    //[HtmlTargetElement(Attributes = "bs-button-color", ParentTag = "form")]

    [HtmlTargetElement("button", Attributes = "bs-button-color", ParentTag = "form")]
    [HtmlTargetElement("a", Attributes = "bs-button-color", ParentTag = "form")]
    public class ButtonTagHelper : TagHelper
    {
        public string BsButtonColor { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.SetAttribute("class", $"btn btn-{BsButtonColor}");
        }
    }
}
