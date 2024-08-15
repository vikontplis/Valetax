using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Valetax.Infrastructure.DTO;
using Valetax.Infrastructure.Filters;

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
    public async Task<ActionResult<JournalRange>> GetRange(
        [Required] [FromQuery] long skip, 
        [Required] [FromQuery] long take, 
        [Required] [FromBody] JournalFilter journalFilter)
    {
        return Ok(null);
    }

    /// <summary>
    /// Returns the information about an particular event by ID.
    /// </summary>
    [HttpPost]
    [Route("api.user.journal.getSingle")]
    public async Task<ActionResult<JournalInfo>> GetSingle([Required] long id)
    {
        return Ok(null);
    }
}