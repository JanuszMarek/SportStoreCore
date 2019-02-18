using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.Linq;

namespace Lessons.Infrastructure
{
    public class WeekDayConstraint : IRouteConstraint
    {
        //Tworzenie własnej reguły routingu

        private static string[] Days = new[] { "mon", "tue", "wed", "thu", "fri", "sat", "sun" };

        /*
        Match  method, which is called to allow a constraint to
        decide whether a request should be matched by the route.The parameters for the Match  method provide
        access to the request from the client, the route, the name of the segment that is being constrained, the
        segment variables that have been extracted from the URL, and whether the request is to check for an
        incoming or outgoing URL
        */

        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            /*
            I use the  routeKey  parameter to get the value of the segment variable to which the
            constraint has been applied from the  values  parameter, convert it to a lowercase string, and see whether it
            matches one of the days of the week that are defined in the static  Days  field.
            */
            return Days.Contains(values[routeKey]?.ToString().ToLowerInvariant());
        }
    }
}
