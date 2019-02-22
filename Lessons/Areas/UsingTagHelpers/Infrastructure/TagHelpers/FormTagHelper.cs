using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Lessons.Areas.UsingTagHelpers.Infrastructure.TagHelpers
{
    public class FormTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;

        // I declared a dependency on the  IUrlHelperFactoryservice,
        //which allows outgoing URLs to be created from routing data
        public FormTagHelper(IUrlHelperFactory factory)
        {
            urlHelperFactory = factory;
        }


        //The ViewContext  attribute denotes that the value of this property should be assigned a ViewContext object when a new instance of the 
        //FormTagHelper  class is created
        [ViewContext]
        //The HtmlAttributeNotBound  attribute prevents MVC from assigning a value to this property if there is
        //a view-context attribute on the  input HTML element.
        [HtmlAttributeNotBound]
        public ViewContext ViewContextData { get; set; }

        //properties
        public string Controller { get; set; }
        public string Action { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContextData);

            //ustawia atrybuty z ścieżki dostępu jeśli nie podane przez użytkownika
            output.Attributes.SetAttribute("action", urlHelper.Action(
                Action ?? ViewContextData.RouteData.Values["action"].ToString(),
                Controller ?? ViewContextData.RouteData.Values["controller"].ToString()));
        }
    }
}
