
using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<CodeFirstDbContext>(opts => 
	opts.UseSqlServer(builder.Configuration.GetConnectionString("Database")));


var app = builder.Build();

app.UseStaticFiles();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

EnsureDatabase.Migrate(app
	.Services.CreateScope()
	.ServiceProvider
	.GetRequiredService<CodeFirstDbContext>());

app.Run();
