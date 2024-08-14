using System.ComponentModel.DataAnnotations;
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
    [Route("api.user.partner.rememberMe")]
    public void RememberMe([Required] string code)
    {
      
    }
}