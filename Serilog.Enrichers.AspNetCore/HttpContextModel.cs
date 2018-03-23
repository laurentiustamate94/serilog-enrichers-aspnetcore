using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace Serilog.Enrichers.AspNetCore
{
    public class HttpContextModel
    {
        public IEnumerable<Claim> UserClaims { get; internal set; }

        public HostString Host { get; internal set; }

        public string RequestId { get; internal set; }

        public Dictionary<string, StringValues> Headers { get; internal set; }

        public Dictionary<string, StringValues> QueryString { get; internal set; }

        public PathString Location { get; internal set; }

        public Dictionary<string, object> RouteData { get; internal set; }

        public string ControllerName { get; internal set; }

        public string ActionName { get; internal set; }
    }
}
