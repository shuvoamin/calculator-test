using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Web.API.Models;

namespace Web.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(lb =>
            {
                // logging all messages with severity warning or above to 'warn+err.log' (see appsettings.json for configuration settings)
                lb.AddConfiguration(Configuration.GetSection("Logging"));
                lb.AddFile(o => o.RootPath = AppContext.BaseDirectory);

                // specific file creation for logging info (see appsettings.json for more details)
                lb.AddFile<InfoFileLoggerProvider>(configure: o => o.RootPath = AppContext.BaseDirectory);
            });

            // resolve all project related dependencies
            ApplicationCore.DependencyResolver.ResolveAll(services);
            Infrastructure.DependencyResolver.ResolveAll(services);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
