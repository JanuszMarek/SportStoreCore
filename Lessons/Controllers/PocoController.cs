using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Linq;

namespace Lessons.Controllers
{
    public class PocoController
    {
        [ControllerContext]
        public ControllerContext ControllerContext { get; set; }



        //Pure POCO method
        //public string Index() => "POCO Controller";

        //    This is no longer a pure POCO controller because it has direct dependencies on the MVC API. 
        public ViewResult Index() => new ViewResult()
        {
            ViewName = "StringResult",
            ViewData = new ViewDataDictionary(
             new EmptyModelMetadataProvider(),
             new ModelStateDictionary())
            {
                Model = $"This is a POCO controller"
            }
        };

        public ViewResult Headers() => new ViewResult()
        {
            ViewName = "DictionaryResult",
            ViewData = new ViewDataDictionary(
                new EmptyModelMetadataProvider(),
                new ModelStateDictionary())
                {
                    Model = ControllerContext.HttpContext.Request.Headers.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.First())
                }
        };

    }
}