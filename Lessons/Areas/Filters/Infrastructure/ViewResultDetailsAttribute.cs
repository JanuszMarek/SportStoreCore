using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Lessons.Areas.Filters.Infrastructure
{
    public class ViewResultDetailsAttribute : ResultFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                ["Result Type"] = context.Result.GetType().Name,
            };

            ViewResult vr;
            if((vr = context.Result as ViewResult) != null)
            {
                dict["View Name"] = vr.ViewName;
                dict["Model Type"] = vr.Model.GetType().Name;
                dict["Model Data"] = vr.Model.ToString();
            }
            
            context.Result = new ViewResult
            {
                ViewName = "Message",
                ViewData = new ViewDataDictionary(
                      new EmptyModelMetadataProvider(),
                      new ModelStateDictionary())
                {
                    Model = dict
                }
            };
            
        }
    }
}
