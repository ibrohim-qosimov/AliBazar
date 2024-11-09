using AliBazar.Application.Services.CategoryServices;
using AliBazar.Application.Services.GeneratingJWT;
using AliBazar.Application.Services.PasswrodHashing;
using AliBazar.Application.Services.UserServices;
using Microsoft.Extensions.DependencyInjection;

namespace AliBazar.Application
{
    public static class AliBazarApplicationDependencyInjection
    {
        public static IServiceCollection AddAliBazarApplicationDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}
