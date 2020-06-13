using ExploreCalifornia.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace ExporeCalifornia {
    public class Startup {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) {
            services.AddTransient(x => new FeatureToggles
            {
                DeveloperExceptions = Configuration.GetValue<bool>("FeatureToggles:DeveloperExceptions")
            });

            services.AddMvc(options => options.EnableEndpointRouting = false);

            services.AddDbContext<BlogDataContext>(options =>
            {
                var connectionString = Configuration.GetConnectionString("BlogDataContext");

                options.UseSqlServer(connectionString);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            FeatureToggles features) {
            app.UseExceptionHandler("/error.html");

            if (features.DeveloperExceptions)
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (context, next) =>
            {
                if (context.Request.Path.Value.Contains("/invalid"))
                {
                    throw new Exception("Some exception");
                }

                await next();
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute("Default",
                    "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseFileServer();
        }
    }
}
