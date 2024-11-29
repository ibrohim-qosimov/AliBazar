using AliBazar.Application.Abstractions;
using AliBazar.Infrastructure.Persistance;
using AliBazar.Infrastructure.Repositories;
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
            db.UseNpgsql(configuration.GetConnectionString("Db"));
        });



        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICateogryRepository, CateogryRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IOrderItemRepository, OrderItemRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();
        services.AddScoped<IProductSizeRepository, ProductSizeRepository>();
        services.AddScoped<IProductDetailRepository, ProductDetailRepository>();
        services.AddScoped<IProductColorRepository, ProductColorRepository>();
        services.AddScoped<IAdminRepository, AdminRepository>();


        return services;
    }
}
