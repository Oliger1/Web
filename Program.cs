using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using WebOliger.Models;
using Microsoft.AspNetCore.Mvc;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Konfigurimi i sh�rbimeve
        ConfigureServices(builder.Services, builder.Configuration);

        var app = builder.Build();

        // Konfigurimi i middleware t� p�rpunimit t� k�rkesave HTTP
        Configure(app, builder.Configuration);

        app.Run();
    }

    private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        // Regjistrimi i DbContext
        services.AddDbContext<ApplicationDbContext>(options =>
      options.UseSqlServer("Data Source=OLIGERi\\SQLEXPRESS;Initial Catalog=Resume;Integrated Security=True;Multiple Active Result Sets=True;Trust Server Certificate=True"));


        // Regjistrimi i sh�rbimeve t� nevojshme
        services.AddControllersWithViews();
    }

    public static void Configure(IApplicationBuilder app, IConfiguration configuration)
    {
        IWebHostEnvironment env = app.ApplicationServices.GetRequiredService<IWebHostEnvironment>();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();


        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}
