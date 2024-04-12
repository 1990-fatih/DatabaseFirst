using DatabaseFirst.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace DatabaseFirst
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<DatabaseFirstDbContext>(opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("Database")));


            var app = builder.Build();
            app.UseStaticFiles();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=index}/{id?}");

            app.Run();
        }
    }
}