using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Portafolio.Data;
using Portafolio.Models;
using NToastNotify;


namespace Portafolio
{
    public class Startup
    {

        public IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
                _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(_configuration.GetConnectionString("Dataconexion")));
            services.AddMvc();
            services.AddMvc().AddNToastNotifyNoty(new NotyOptions
            {
             ProgressBar = true,
             Timeout = 3000,
             Theme = "mint"});

            services.AddControllersWithViews();
            services.AddScoped<Contactaccion>();
            services.AddScoped<EnviarMail>();
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
             app.UseNToastNotify();
            app.UseRouting();
            app.UseStaticFiles();
            app.UseCors();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "Default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
