using Sampas_Mobil_Etkinlik.Models;
using System.Net;
using System.Text.Json;

namespace Sampas_Mobil_Etkinlik.Controllers.Infrastructure.Middleware
{
    public class GlobalErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalErrorHandlingMiddleware> _logger;

        public GlobalErrorHandlingMiddleware(RequestDelegate next, ILogger<GlobalErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, _logger);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception, ILogger<GlobalErrorHandlingMiddleware> logger)
        {
            HttpStatusCode status;
            ApiResponse apiResponse = new ApiResponse(false);

            var exceptionType = exception.GetType();

            if (exceptionType == typeof(NotImplementedException))
            {
                status = HttpStatusCode.NotImplemented;
                apiResponse.Message = exception.Message;
            }
            else if (exceptionType == typeof(UnauthorizedAccessException))
            {
                status = HttpStatusCode.Unauthorized;
                apiResponse.Message = exception.Message;
            }
            else if (exceptionType == typeof(KeyNotFoundException))
            {
                status = HttpStatusCode.Unauthorized;
                apiResponse.Message = exception.Message;
            }
            else
            {
                status = HttpStatusCode.InternalServerError;
                apiResponse.Message = exception.Message;// "Beklenmedik bir hata oluştu, lütfen daha sonra tekrar deneyiniz"; //TODO replace this message with user friendly one in production
                                                                                                         //apiResponse.Trace = exception.Message;
            }

            logger.LogError(exception, "Unhandled exception: ");

            var exceptionResult = JsonSerializer.Serialize(apiResponse);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;
            return context.Response.WriteAsync(exceptionResult);
        }

    }
}
