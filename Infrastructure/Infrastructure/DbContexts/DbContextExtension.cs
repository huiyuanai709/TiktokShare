using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DbContexts;

public static class DbContextExtension
{
    public static IServiceCollection AddDbContextService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextPool<TiktokShareDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("Tiktok"));
        });
        return services;
    }
}