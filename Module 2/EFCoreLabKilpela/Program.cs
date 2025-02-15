using EFCoreLabKilpela.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreLabKilpela
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddRouting(options => {
                options.LowercaseUrls = true; 
                options.AppendTrailingSlash = true;
            });

            // Add EF Core DI
            builder.Services.AddDbContext<MovieContext>(options => 
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("MovieContext")));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}/{slug?}");

            app.Run();
        }
    }
}
