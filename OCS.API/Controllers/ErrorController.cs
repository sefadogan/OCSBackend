using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OData;
using OCS.Common.Exceptions;
using OCS.Common.Result.Concrete;

namespace OCS.API.Controllers;

[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorController : BaseController
{
    [HttpGet]
    public IActionResult Handle()
    {
        var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
        if (context.Error is ODataException)
            return BadRequest(new ErrorResult(context.Error.Message));

        var message = context.Error.CollectMessages();

        //serilog vb. log sistemine log atılabilir.
        //Serilog.Error(context.Error, message);

        return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult(message));
    }
}
