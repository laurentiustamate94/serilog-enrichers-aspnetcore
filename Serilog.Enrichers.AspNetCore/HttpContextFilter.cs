using System.Linq;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace Serilog.Enrichers.AspNetCore
{
    public class HttpContextFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var httpContextModel = context.HttpContext.RequestServices.GetService<HttpContextModel>();

            httpContextModel.ControllerName = context.Controller.ToString();
            httpContextModel.ActionName = context.ActionDescriptor.DisplayName;
            httpContextModel.RouteData = context.RouteData.Values.ToDictionary(x => x.Key, y => y.Value);
            httpContextModel.RequestId = httpContextModel.RequestId ?? context.HttpContext.TraceIdentifier;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Nothing to do :-)
        }
    }
}
