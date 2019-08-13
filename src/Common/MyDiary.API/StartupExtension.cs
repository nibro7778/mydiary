using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;

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
            //TODO: Added sql server and rabbit MQ health check once it related functionality has implemented
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

        public static IServiceCollection EnableSwagger(this IServiceCollection services, string serviceName)
        {
            services.AddSwaggerGen(options =>
            {
                var provider = services.BuildServiceProvider()
                    .GetRequiredService<IApiVersionDescriptionProvider>();

                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerDoc(
                        description.GroupName,
                        new Info()
                        {
                            Title = $"{serviceName} {description.ApiVersion}",
                            Version = description.ApiVersion.ToString()
                        });
                    options.AddFluentValidationRules();
                }
            });
            return services;
        }

        public static IApplicationBuilder UseCustomSwagger(this IApplicationBuilder app,
            IApiVersionDescriptionProvider provider)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint(
                        $"/swagger/{description.GroupName}/swagger.json",
                        description.GroupName.ToUpperInvariant());
                }
            });
            return app;
        }
    }
}
