using AliBazar.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AliBazar.Infrastructure;

public static class AliBazarInfrastructureDependencyInjection
{
    public static IServiceCollection AddAliBazarInfrastructureDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AliBazarDbContext>(db =>
        {
            db.UseNpgsql("connectionString: ");
        });

        return services;
    }
}
