using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NToastNotify;
using Portafolio.Data;
using Portafolio.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetSection("AppSettings").GetSection("Dataconexion").Value));
builder.Services.AddMvc();
builder.Services.AddMvc().AddNToastNotifyNoty(new NotyOptions
{
    ProgressBar = true,
    Timeout = 3000,
    Theme = "mint"
});

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<Contactaccion>();
builder.Services.AddScoped<EnviarMail>();
builder.Services.AddCors();

var app = builder.Build();

if (app.Environment.IsDevelopment())
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


app.Run();