using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace MyDiary.API
{
    public static class StartupExtension
    {
        public static IServiceCollection EnableVersionedApi(this IServiceCollection services)
        {
            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
            });

            return services;
        }

        public static IServiceCollection EnableHealthCheck(this IServiceCollection services, IConfiguration configuration)
        {
            //TODO: Added sql server and rabbit MQ health check once it related functionality implemented
            services.AddHealthChecks();
            services.AddHealthChecksUI();
            return services;
        }

        public static IApplicationBuilder UseCustomHealthCheck(this IApplicationBuilder app)
        {
            var options = new HealthCheckOptions
            {
                ResponseWriter = async (c, r) =>
                {
                    c.Response.ContentType = "application/json";

                    var result = JsonConvert.SerializeObject(new
                    {
                        status = r.Status.ToString(),
                        //TODO: Where we defining a key?
                        errors = r.Entries.Select(e => new {key = e.Key, value = e.Value.Status.ToString()})
                    });
                    await c.Response.WriteAsync(result);
                }
            };
            app.UseHealthChecks("/hc", options);
            app.UseHealthChecksUI();
            return app;
        }
    }
}
