using Microsoft.AspNetCore.Mvc;
using SGRH.Domain.Base;

namespace SGRH.WebApp.Api.Controllers.Base
{

    public abstract class BaseController : ControllerBase
    {
        protected IActionResult HandleResult<T>(T result)
        {
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        protected IActionResult HandleOperationResult(OperationResult result)
        {
            if (!result.isSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
