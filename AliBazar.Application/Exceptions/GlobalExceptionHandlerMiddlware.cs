using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace AliBazar.Application.Exceptions
{
    public class GlobalExceptionHandlerMiddlware : IMiddleware
    {
        private readonly ILogger<GlobalExceptionHandlerMiddlware> _logger;

        public GlobalExceptionHandlerMiddlware(ILogger<GlobalExceptionHandlerMiddlware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {

            try
            {

                await next(context);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                ProblemDetails problem = new()
                {
                    Status = (int)HttpStatusCode.InternalServerError,
                    Type = "Server error",
                    Title = "Server Error",
                    Detail = ex.Message
                };


                string json = JsonSerializer.Serialize(problem);

                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(json);




            }



        }
    }
}
