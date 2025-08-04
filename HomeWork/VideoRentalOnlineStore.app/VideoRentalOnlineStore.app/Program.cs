using Microsoft.EntityFrameworkCore;
using VROS.DataAccess;
using VROS.DataAccess.Interfaces;
using VROS.DataAccess.Repository;
using VROS.Services;
using VROS.Services.Interfaces; 

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

builder.Services.AddSession(options =>  
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

#region DBregistration
string connectionString = builder.Configuration.GetConnectionString("VROSConnString");
builder.Services.AddDbContext<VROSDbContext>(options =>
options.UseSqlServer(connectionString));
#endregion  

#region Register Repositories
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IMovieRepository, MovieRepository>();
builder.Services.AddSingleton<IRentalRepository, RentalRepository>();
#endregion

#region Register Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IRentalService, RentalService>();
#endregion

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); 
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();