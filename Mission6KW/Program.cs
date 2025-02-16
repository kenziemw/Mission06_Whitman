using Microsoft.EntityFrameworkCore;
using Mission6KW.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(); // Adds MVC controllers and views support

// Configure the database context using SQLite with the connection string from appsettings.json
builder.Services.AddDbContext<MovieDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MovieConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) // If the app is not running in development mode
{
    app.UseExceptionHandler("/Home/Error"); // Redirects to an error page when exceptions occur
    app.UseHsts(); // Enforces HTTPS with HTTP Strict Transport Security (HSTS)
}

app.UseHttpsRedirection(); // Redirects HTTP requests to HTTPS
app.UseStaticFiles(); // Enables serving static files (CSS, JavaScript, images, etc.)

app.UseRouting(); // Enables routing for controllers

app.UseAuthorization(); // Handles user authorization (not configured in this project)

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // Defines the default route for the app

app.Run(); // Starts the application