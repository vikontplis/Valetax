using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Valetax.Infrastructure.Contracts;
using Velatex.Domain.Models;

namespace Valetax.WebAPI.Controllers;

/// <summary>
/// Represents entire tree API
/// </summary>
[ApiController]
[SwaggerTag("Represents entire tree API")]
[Produces("application/json")]
public class TreeController : ControllerBase
{
    private readonly ITreeService _treeService;

    public TreeController(ITreeService treeService)
    {
        _treeService = treeService;
    }

    /// <summary>
    /// Returns your entire tree.
    /// If your tree doesn't exist it will be created automatically.
    /// </summary>
    [HttpPost]
    [Route("api.user.tree.get")]
    public async Task<ActionResult<VNode>> Get([Required] string treeName)
    {
        var tree = await _treeService.GetTree(treeName);
        return Ok(tree);
    }

}