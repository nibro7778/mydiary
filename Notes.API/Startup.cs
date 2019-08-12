using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyDiary.API;

namespace Notes.API
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IHostingEnvironment env, ILoggerFactory loggerFactor)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            _configuration = builder.Build();
            var log = loggerFactor.CreateLogger<Startup>();

            log.LogInformation($"Starting Notes service in {env.EnvironmentName} environment");
        }

        // ConfigureServices method to configure the app's services. Services are configured—also described as registered
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => { options.EnableEndpointRouting = false; })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.EnableVersionedApi();
            services.EnableHealthCheck(_configuration);
            
            // Swagger
        }

        // Method to create the app's request processing pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            app.UseHttpsRedirection();
            app.UseMvcWithDefaultRoute();
            app.UseCustomHealthCheck();
        }
    }
}
