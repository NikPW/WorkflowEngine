using System.Reflection;
using Builder;
using DatabaseContext;
using DilshodWorkflowEngine.Shared.Base;
using Extensions.Enums;
using Microsoft.EntityFrameworkCore;

namespace DilshodWorkflowEngine.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            HostingEnvironment = hostingEnvironment;
        }

        public IConfiguration Configuration { get; }

        public IWebHostEnvironment HostingEnvironment { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var config = new AppConfig();
            Configuration.GetSection(nameof(AppConfig)).Bind(config);
            services.AddSingleton(config);

            #region Services

            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddWorkflowEngine()
                .AddDatabaseConnection(config.ConnectionString, EfProviders.SqlLite)
                .AddBasicActivities();

            #endregion
            
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(opt =>
            {
                opt.MapRazorPages();
                opt.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}
