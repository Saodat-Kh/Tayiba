using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Extensions;

public static class RegisterDataContext
{
    public static void AddDBContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDataContext>(options =>
            options.UseNpgsql("Server=localhost;Port=5432;Database=Tayiba;Username=postgres;Password=12345;Timeout=5;Command Timeout=5;"));
    }
}