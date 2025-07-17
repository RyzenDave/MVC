using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VROS.DataAccess;

namespace Avenga.TodoApp.DataAccess;

public static class DependencyInjection
{
    // This is the extension method
    public static IServiceCollection AddDataAccessServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // Get the connection string from appsettings.json
        var connectionString = configuration.GetConnectionString("VROSConnString");

        // Add the DbContext to the services collection
        services.AddDbContext<VROSDbContext>(options =>
            options.UseSqlServer(connectionString));

        // Add your repositories here
        // services.AddScoped<ITodoRepository, TodoRepository>();
        // services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
