using FastTracker.Models;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;

namespace FastTracker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Env.Load();
            string DBKey = Environment.GetEnvironmentVariable("DBKey");
            Console.WriteLine("Current dir: " + Directory.GetCurrentDirectory());

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<JobDBContext>(options =>
            {
                options.UseSqlServer(DBKey);
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
