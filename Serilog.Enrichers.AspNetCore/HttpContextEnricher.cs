using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers.AspNetCore
{
    public class HttpContextEnricher : ILogEventEnricher
    {
        private readonly HttpContextModel _model = null;

        public HttpContextEnricher(HttpContextModel model)
        {
            this._model = model;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            if (this._model == null)
            {
                return;
            }

            logEvent.AddOrUpdateProperty(propertyFactory.CreateProperty("HttpContext", this._model, true));
        }
    }
}
