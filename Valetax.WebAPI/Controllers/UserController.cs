using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Valetax.Infrastructure.Contracts;

namespace Valetax.WebAPI.Controllers;

[ApiController]
//[Route("api.[controller]")]
[Produces("application/json")]
public class UserController : ControllerBase
{
    private readonly IUSerRememberMe _rememberMeService;

    public UserController(IUSerRememberMe rememberMeService)
    {
        _rememberMeService = rememberMeService;
    }
    
    /// <summary>
    /// remember Me
    /// </summary>
    [HttpPost]
    [Route("api.user.partner.rememberMe")]
    public ActionResult<bool> RememberMe([Required] string code)
    {
        return Ok(_rememberMeService.RememberMe(code));
    }
}