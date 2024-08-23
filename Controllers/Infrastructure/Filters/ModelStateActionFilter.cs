using NLog;
using NLog.Extensions.Logging;
using NLog.Web;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Sampas_Mobil_Etkinlik.Models;
using Sampas_Mobil_Etkinlik.Common.Constants;

namespace Sampas_Mobil_Etkinlik.Controllers.Infrastructure.Filters;

public class ModelStateActionFilter : IActionFilter
{
    public void OnActionExecuted(ActionExecutedContext context)
    {
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.ModelState.IsValid)
            return;

        var errors = new List<string>();
        foreach (var state in context.ModelState)
        {
            errors.AddRange(state.Value.Errors.Select(error => error.ErrorMessage));
        }

        context.Result = new BadRequestObjectResult(new ApiResponse(ErrorMessages.REQUEST_PARAMETERS_INVALID, errors));
    }
}
