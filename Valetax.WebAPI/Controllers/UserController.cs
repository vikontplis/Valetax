using Microsoft.AspNetCore.Mvc;

namespace Valetax.WebAPI.Controllers;

[ApiController]
//[Route("api.[controller]")]
[Produces("application/json")]
public class UserController : ControllerBase
{
    /// <summary>
    /// remember Me
    /// </summary>
    [HttpPost]
    [Route("api.[controller].partner.[action]")]
    public ActionResult<bool> RememberMe(string code)
    {
        return Ok();
    }
}