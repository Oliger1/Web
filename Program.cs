using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using WebOliger.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Drawing;
using Microsoft.AspNetCore.Identity;
using WebOliger.Entity;

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
            options.UseSqlServer("Data Source=SQL6031.site4now.net;User ID=db_aa6c02_resume_admin;Password=Oliger12.;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;Initial Catalog=db_aa6c02_resume"));


        services.AddIdentity<User, Role>(options =>
        {
            options.SignIn.RequireConfirmedAccount = true;
        })
      .AddEntityFrameworkStores<ApplicationDbContext>()
      .AddDefaultTokenProviders();

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

        app.UseAuthentication();
        app.UseAuthorization();

       

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}