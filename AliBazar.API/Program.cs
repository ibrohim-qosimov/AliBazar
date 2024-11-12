using AliBazar.Infrastructure;
using AliBazar.Application;
namespace AliBazar.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // services 

        builder.Services.AddAliBazarInfrastructureDependencyInjection(builder.Configuration);
        builder.Services.AddAliBazarApplicationDependencyInjection();

        builder.Services.AddCors(ops =>
        {
            ops.AddDefaultPolicy(policy =>
            {
                policy.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader();
            });
        });

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();


        // pipeline

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseCors();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
