using Microsoft.AspNetCore.Mvc;
using OCS.Common.Result.Abstract;
using OCS.Common.Result.Concrete;

namespace OCS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseController : ControllerBase
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        public ActionResult GetResponseOnlyResultData<T>(IDataResult<T> result)
        {
            if (result == null)
                return NotFound(new ErrorResult());

            return result.IsSuccessful
                ? Ok(result)
                : BadRequest(result);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public ActionResult GetResponseOnlyResult(OCS.Common.Result.Abstract.IResult result)
        {
            if (result == null)
                return NotFound(new ErrorResult());

            return result.IsSuccessful
                ? Ok(result)
                : BadRequest(result);
        }
    }
}
