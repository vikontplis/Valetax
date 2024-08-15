using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Valetax.WebAPI.Controllers;

/// <summary>
/// Represents journal API
/// </summary>
[ApiController]
[SwaggerTag("Represents journal API")]
[Produces("application/json")]
public class JournalController : ControllerBase
{
    public JournalController()
    {
        
    }

    /// <summary>
    /// Provides the pagination API.
    /// Skip means the number of items should be skipped by server.
    /// Take means the maximum number items should be returned by server.
    /// All fields of the filter are optional.
    /// </summary>
    [HttpPost]
    [Route("api.user.journal.getRange")]
    public ActionResult<bool> GetRange()
    {
        return Ok(true);
    }
    
    /// <summary>
    /// Returns the information about an particular event by ID.
    /// </summary>
    [HttpPost]
    [Route("api.user.journal.getSingle")]
    public ActionResult<bool> GetSingle()
    {
        return Ok(true);
    }

}