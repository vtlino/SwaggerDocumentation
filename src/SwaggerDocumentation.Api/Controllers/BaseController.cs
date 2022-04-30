using Microsoft.AspNetCore.Mvc;
using SwaggerDocumentation.Api.Filters;
using SwaggerDocumentation.Domain.Response;

namespace SwaggerDocumentation.Api.Controllers
{
    /// <response code="400">Invalid request</response>
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
    [Produces("application/json")]
    [ServiceFilter(typeof(ActionFilterExecuting))]
    public abstract class BaseController : Controller
    {
        
    }
}