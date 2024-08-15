using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Valetax.WebAPI.Controllers;

/// <summary>
/// Represents entire tree API
/// </summary>
[ApiController]
[SwaggerTag("Represents entire tree API")]
[Produces("application/json")]
public class TreeController : ControllerBase
{
    public TreeController()
    {
        
    }

    /// <summary>
    /// Returns your entire tree.
    /// If your tree doesn't exist it will be created automatically.
    /// </summary>
    [HttpPost]
    [Route("api.user.tree.get")]
    public ActionResult<bool> Get()
    {
        return Ok(true);
    }

}