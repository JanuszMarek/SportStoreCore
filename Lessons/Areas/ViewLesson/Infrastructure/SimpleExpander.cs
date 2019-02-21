using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Razor;

namespace Lessons.Areas.ViewLesson.Infrastructure
{
    public class SimpleExpander : IViewLocationExpander
    {

        //Changing Default location of Views
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            foreach (string location in viewLocations)
            {
                yield return location.Replace("Shared", "Common");
            }
            yield return "/Views/Legacy/{1}/{0}/View.cshtml";

        }


        public void PopulateValues(ViewLocationExpanderContext context)
        {
            //do nothing
        }
    }
}
