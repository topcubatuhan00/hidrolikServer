using Microsoft.AspNetCore.Mvc;
using Hidrolik.Domain.Dtos;

namespace Hidrolik.API.CustomControllerBase;

public class BaseController : ControllerBase
{
    public IActionResult CreateActionResultInstance<T>(ResponseDto<T> responseDto)
    {
        return new ObjectResult(responseDto)
        {
            StatusCode = Response.StatusCode
        };
    }
}
