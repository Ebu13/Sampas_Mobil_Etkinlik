using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Sampas_Mobil_Etkinlik.Controllers.Infrastructure.Filters
{
    public class ApplicationLoggingActionFilter : ActionFilterAttribute
    {
        private readonly ILogger<ApplicationLoggingActionFilter> _logger;

        public ApplicationLoggingActionFilter(ILogger<ApplicationLoggingActionFilter> logger)
        {
            _logger = logger;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.HttpContext == null || context.HttpContext.Request is null)
            {
                await next();
                return;
            }

            object action = context.HttpContext.Request.RouteValues["action"];
            string token = context.HttpContext.Request.Cookies.ContainsKey("X-Access-Token") ? context.HttpContext.Request.Cookies["X-Access-Token"] : "anonymous user";
            string queryString = Convert.ToString(context.HttpContext.Request.QueryString);

            _logger.LogInformation($"{action} Token:{token},");
            _logger.LogInformation($"{context.HttpContext.Request.Method} {context.HttpContext.Request.Scheme}//{context.HttpContext.Request.Host}{context.HttpContext.Request.Path}{context.HttpContext.Request.QueryString}");

            await next();

        }

        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (context?.HttpContext is null)
            {
                await next();
                return;
            }

            if (context.Result is ObjectResult result)
            {
                var respCode = result?.StatusCode;

                _logger.LogInformation($"Response Code {respCode}");

            }

            await next();

        }
    }
}
