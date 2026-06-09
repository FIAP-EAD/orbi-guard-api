using System.Text.Json;
using OrbiGuard.Application.Exceptions;

namespace OrbiGuard.Api.Middleware;

public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Exceção não tratada: {Message}", ex.Message);
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        var (status, message) = ex switch
        {
            NaoEncontradoException e  => (StatusCodes.Status404NotFound,         e.Message),
            NaoAutorizadoException e  => (StatusCodes.Status401Unauthorized,     e.Message),
            ConflitoException e       => (StatusCodes.Status409Conflict,         e.Message),
            ArgumentException e       => (StatusCodes.Status400BadRequest,       e.Message),
            InvalidOperationException e => (StatusCodes.Status422UnprocessableEntity, e.Message),
            _                         => (StatusCodes.Status500InternalServerError, "Erro interno no servidor.")
        };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = status;

        var body = JsonSerializer.Serialize(new { error = message });
        return context.Response.WriteAsync(body);
    }
}
