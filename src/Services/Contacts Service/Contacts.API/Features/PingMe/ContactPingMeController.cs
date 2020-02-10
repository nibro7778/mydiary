using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Contacts.API.Features.PingMe
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ContactPingMeController : ControllerBase
    {
        [HttpGet]
        [Route("Reply")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<string> Reply()
        {
            return Ok("I am available");
        }
    }
}