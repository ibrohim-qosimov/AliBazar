using AliBazar.Application;
using AliBazar.Application.Exceptions;
using AliBazar.Infrastructure;
using System.Text.Json.Serialization;
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



        builder.Services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        }); ;
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();


        // pipeline

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        //s
        //app.UseMiddleware<GlobalExceptionHandlerMiddlware>();
        app.UseHttpsRedirection();

        app.UseCors();

        app.UseStaticFiles();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
