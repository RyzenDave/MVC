using Microsoft.EntityFrameworkCore;
using VROS.DataAccess;
using VROS.DataAccess.Interfaces;
using VROS.DataAccess.Repository;
using VROS.Services;
using VROS.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllersWithViews();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Database context registration
string connectionString = builder.Configuration.GetConnectionString("VROSConnString");
builder.Services.AddDbContext<VROSDbContext>(options =>
    options.UseSqlServer(connectionString));

// Repository and service registration
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // For more information see https://aka.ms/aspnetcore-hsts
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession(); // Must come after UseRouting and before UseAuthorization

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();