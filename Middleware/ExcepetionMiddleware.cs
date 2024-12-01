using System.Net;
using System.Text.Json;
using MongoExample.Errors;

namespace MongoExample.Middleware;

public class ExcepetionMiddleware
{
    public readonly RequestDelegate _next;
    private readonly ILogger<ExcepetionMiddleware> _logger;
    private readonly IHostEnvironment _env;

    public ExcepetionMiddleware(RequestDelegate next, ILogger<ExcepetionMiddleware> logger, IHostEnvironment env)
    {
        _next = next;
        _logger = logger;
        _env = env;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,ex.Message);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            
            var response = _env.IsDevelopment()? 
                    new ApiExcepetion(context.Response.StatusCode.ToString(), ex.Message, ex.StackTrace!) : 
                    new ApiExcepetion(context.Response.StatusCode.ToString(),ex.Message, "Internal Server Error");
            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var json = JsonSerializer.Serialize(response, options);
            await context.Response.WriteAsync(json);
        }
    }

}