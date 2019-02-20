using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Lessons.Areas.Filters.Infrastructure
{
    public class TimeFilter : IAsyncActionFilter, IAsyncResultFilter
    {
        private Stopwatch timer;
        private IFilterDiagnostics diagnostics;

        public TimeFilter(IFilterDiagnostics diags)
        {
            diagnostics = diags;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            timer = Stopwatch.StartNew();
            await next();
            diagnostics.AddMessage($@"Action time:{timer.Elapsed.TotalMilliseconds}");
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            await next();
            timer.Stop();
            diagnostics.AddMessage($@"Result time:{timer.Elapsed.TotalMilliseconds}");
        }

    }
}
