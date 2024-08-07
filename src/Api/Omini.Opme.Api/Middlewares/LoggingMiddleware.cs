
using System.Diagnostics;

namespace Omini.Opme.Api.Middlewares;

internal static class LoggingMiddlewareExtensions
{
    public static IApplicationBuilder UseLoggingMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<LoggingMiddleware>();
    }
}

internal class LoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<LoggingMiddleware> _logger;
    public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Unexpected error");
            }

            stopwatch.Stop();
        }
        finally
        {

        }
    }
}