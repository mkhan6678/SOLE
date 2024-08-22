using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite
{
    public class Startup
    {
        /// <summary>
        /// Constructor to initialize the configuration for startup class
        /// </summary>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Getter method for configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            // Add razor pages and clients to the services collection
            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddServerSideBlazor();
            services.AddHttpClient();
            services.AddControllers();
            services.AddTransient<JsonFileProductService>();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Check for Developement page
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // Post Error page in case of errors on rendering page
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Render all static files , http redirections , and endpoints required for the page
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // Render Razorpage, controllers, blazorhub for the endpoints
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
            });
        }
    }
}
