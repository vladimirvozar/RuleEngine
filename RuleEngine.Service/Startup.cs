using Hangfire;
using Hangfire.MemoryStorage;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using RuleEngine.Service.Service;

using System;

namespace RuleEngine.Service
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHangfire(config => config.UseMemoryStorage());

            services.AddHangfireServer();
            
            services.AddSingleton<IImportManager, ImportManager>();
            services.AddSingleton<IData, Data>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
            IWebHostEnvironment env, 
            IRecurringJobManager recurringJobManager,
            IServiceProvider services)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseHangfireDashboard();

            // set background job to trigger on every 10 minutes
            recurringJobManager.AddOrUpdate(
                "Import data every 10 min", 
                () => services.GetService<IImportManager>().Run(),
                "*/10 * * * *"    // "* * * * *"    <- use this is Cron expression for 1 minute timespan
                );
        }
    }
}
