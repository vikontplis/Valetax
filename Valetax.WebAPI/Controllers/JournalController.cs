using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Valetax.Infrastructure.Contracts;
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
    private readonly IJournalService _journalService;

    public JournalController(IJournalService journalService)
    {
        _journalService = journalService;
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
        [Required] [FromQuery] int skip,
        [Required] [FromQuery] int take,
        [Required] [FromBody] JournalFilter journalFilter)
    {
        var jrange = await _journalService.GetRange(skip, take, journalFilter);
        return Ok(jrange);
    }

    /// <summary>
    /// Returns the information about an particular event by ID.
    /// </summary>
    [HttpPost]
    [Route("api.user.journal.getSingle")]
    public async Task<ActionResult<JournalInfo>> GetSingle([Required] long id)
    {
        var ji = await _journalService.GetSingle(id);
        return Ok(ji);
    }
}