using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Events.API.Features.PingMe
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class PingMeController : ControllerBase
    {
        [HttpGet]
        [Route("Get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<string> Get()
        {
            return Ok("I am available"); 
        }
    }
}