using Microsoft.AspNetCore.Mvc;
using Sampas_Mobil_Etkinlik.Models;

namespace Sampas_Mobil_Etkinlik.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseApiController : Controller
{
    protected virtual IActionResult Result<T>(T data, bool isSuccess, string message)
    {
        if (isSuccess)
        {
            return Result<T>(data);
        }
        return BadRequest(new ApiResponse<T>(message));
    }

    public IActionResult Result<T>(T data)
    {
        return Ok(new ApiResponse<T>(data));
    }

    protected List<string> Validate(Type t, object obj)
    {
        var errors = new List<string>();

        ModelState.ClearValidationState(nameof(t));
        if (!TryValidateModel(obj, nameof(t)))
        {
            foreach (var state in ModelState)
            {
                errors.AddRange(state.Value.Errors.Select(error => error.ErrorMessage));
            }

        }
        return errors;
    }

}
