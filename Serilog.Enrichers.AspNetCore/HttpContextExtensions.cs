using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Serilog.Configuration;

namespace Serilog.Enrichers.AspNetCore
{
    public static class HttpContextExtensions
    {
        public static IApplicationBuilder UseHttpContextMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HttpContextMiddleware>();
        }

        public static IServiceCollection AddHttpContextMiddleware(this IServiceCollection services)
        {
            services.AddScoped<HttpContextModel>();
            services.AddScoped<HttpContextEnricher>();

            return services;
        }

        public static LoggerConfiguration WithHttpContext(this LoggerEnrichmentConfiguration loggerEnrichmentConfiguration, IServiceProvider services)
        {
            return loggerEnrichmentConfiguration.With(services.GetService<HttpContextEnricher>());
        }
    }
}
