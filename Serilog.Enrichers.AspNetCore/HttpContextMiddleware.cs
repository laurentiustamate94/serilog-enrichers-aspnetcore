using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;

namespace Serilog.Enrichers.AspNetCore
{
    public class HttpContextMiddleware
    {
        private readonly RequestDelegate _next = null;

        public HttpContextMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public Task InvokeAsync(HttpContext context, HttpContextModel httpContextModel)
        {
            httpContextModel.UserClaims = context.User?.Claims;
            httpContextModel.Host = context.Request.Host;
            httpContextModel.Location = context.Request.Path;
            httpContextModel.Headers = context.Request.Headers.ToDictionary(x => x.Key, y => y.Value);
            httpContextModel.QueryString = QueryHelpers.ParseQuery(context.Request.QueryString.ToString()).ToDictionary(x => x.Key, y => y.Value);
            httpContextModel.RequestId = context.TraceIdentifier ?? Guid.NewGuid().ToString("N").ToLowerInvariant();

            // Call the next delegate/middleware in the pipeline
            return this._next(context);
        }
    }
}
