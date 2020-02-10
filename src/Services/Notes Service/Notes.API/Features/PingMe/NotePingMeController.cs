using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Notes.API.Features.PingMe
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class NotePingMeController : ControllerBase
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