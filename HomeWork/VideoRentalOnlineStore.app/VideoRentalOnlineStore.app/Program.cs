using Microsoft.EntityFrameworkCore;
using VROS.DataAccess;
using VROS.DataAccess.Interfaces;
using VROS.DataAccess.Repository;
using VROS.Services;
using VROS.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// ====== Add services to the container. ======
builder.Services.AddControllersWithViews();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

#region DBregistration
// Configure database connection
string connectionString = builder.Configuration.GetConnectionString("VROSConnString");
builder.Services.AddDbContext<VROSDbContext>(options =>
    options.UseSqlServer(connectionString));
#endregion

#region Register Repositories
// ===== Here we register the repositories using Dependency Injection =====

// ===> Singleton lifetime: A single instance is created and reused for all requests
// This is appropriate for our static in-memory repositories
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IMovieRepository, MovieRepository>();
builder.Services.AddSingleton<IRentalRepository, RentalRepository>();

// ===> If we were using EF Core implementations instead of static repositories
// builder.Services.AddScoped<IMovieRepository, EFMovieRepository>();
// builder.Services.AddScoped<IUserRepository, EFUserRepository>();
// builder.Services.AddScoped<IRentalRepository, EFRentalRepository>();
#endregion

#region Register Services
// ===== Here we register the application services using Dependency Injection =====

// ===> Scoped lifetime: A new instance is created once per client request
// This is the recommended lifetime for services that contain state related to a specific user request
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IRentalService, RentalService>();

// ===> If we needed transient services (new instance every time)
// builder.Services.AddTransient<IEmailService, EmailService>();
#endregion

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

app.UseSession(); // Must come after UseRouting() and before UseAuthorization()

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();