using System.Net;
using System.Text.Json;

namespace ContactsManagementApplication.Exceptions;

public class ApiExceptionMiddleware
{
    private readonly RequestDelegate next;
    private readonly ILogger<ApiExceptionMiddleware> logger;

    public ApiExceptionMiddleware(
        RequestDelegate next,
        ILogger<ApiExceptionMiddleware> logger)
    {
        this.next = next;
        this.logger = logger;
    }

    public async Task Invoke(HttpContext context, IHostEnvironment env)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex, env);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception, IHostEnvironment env)
    {
        string error;

        logger.LogError(exception.ToString());

        switch (exception)
        {
            case ApplicationException:

                break;
            default:
                break;
        }

        if (exception is ApplicationException)
        {
            error = "ApplicationError";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        }
        else
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            error = "Unhandled";
        }

        string result = JsonSerializer.Serialize(new
        {
            error = error,
            message = exception.Message,
            exception.Data
        });

        context.Response.ContentType = "application/json";
        return context.Response.WriteAsync(result);
    }
}
