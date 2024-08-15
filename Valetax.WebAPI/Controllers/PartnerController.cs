using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Valetax.Infrastructure.Contracts;

namespace Valetax.WebAPI.Controllers;

/// <summary>
/// Represents partner API
/// </summary>
[ApiController]
[SwaggerTag("Represents partner API")]
[Produces("application/json")]
public class PartnerController : ControllerBase
{
    private readonly IUSerRememberMe _rememberMeService;

    public PartnerController(IUSerRememberMe rememberMeService)
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