using System.Net;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using Valetax.Infrastructure.Contracts;
using Valetax.Infrastructure.DTO;
using Velatex.Domain.Exceptions;

namespace Valetax.WebAPI.Middlewares;

public class ExceptionMiddleware
{
    private readonly ILogger<ExceptionMiddleware> _logger;
    private readonly IErrorHandleService _errorHandleService;
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(
        ILogger<ExceptionMiddleware> logger,
        IErrorHandleService errorHandleService,
        RequestDelegate next)
    {
        _logger = logger;
        _errorHandleService = errorHandleService;
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        context.Request.EnableBuffering();
        using var reader = new StreamReader(context.Request.Body, Encoding.UTF8);
        var body = await reader.ReadToEndAsync();
        context.Request.Body.Position = 0;

        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            if (ex is JournalException)
            {
                _logger.LogError(ex, ex.Message);
            }
            else
            {
                await HandleCustomExceptionResponseAsync(context, ex, body);
            }
        }
    }

    private async Task HandleCustomExceptionResponseAsync(HttpContext context, Exception ex, string body)
    {
        context.Response.ContentType = MediaTypeNames.Application.Json;
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var reqBody = body;
        var reqPath = context.Request.Path.ToString();
        var reqQuery = context.Request.QueryString.ToString();

        var problemDetailsResponse = await _errorHandleService.SaveErrorToJournal(reqPath, reqQuery, reqBody, ex);

        var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower };

        var json = JsonSerializer.Serialize(problemDetailsResponse, options);
        await context.Response.WriteAsync(json);
    }
}