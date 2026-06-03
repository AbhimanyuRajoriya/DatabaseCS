using Microsoft.Data.SqlClient;
using System.Text.Json;

namespace DatabaseTutorials.Modules.Shared.Middleware
{
    public class ExceptionMiddleware 
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try { await _next(context); }
            catch(ArgumentException ex)
            {
                context.Response.StatusCode = 400;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(
                    JsonSerializer.Serialize(new
                    {
                        Message = ex.Message
                    }));
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, ex.Message);

                context.Response.StatusCode = 503;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(
                    JsonSerializer.Serialize(new
                    {
                        Message = "Database service is currently unavailable"
                    }));
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(
                    JsonSerializer.Serialize(new
                    {
                        Message = "Internal Server Error"
                    }));
            }
        }
    }
}
