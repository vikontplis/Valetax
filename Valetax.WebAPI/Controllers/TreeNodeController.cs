using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Valetax.WebAPI.Controllers;

/// <summary>
/// Represents tree node API
/// </summary>
[ApiController]
[SwaggerTag("Represents tree node API")]
[Produces("application/json")]
public class TreeNodeController : ControllerBase
{
    public TreeNodeController()
    {
        
    }

    /// <summary>
    /// Create a new node in your tree.
    /// You must to specify a parent node ID that belongs to your tree.
    /// A new node name must be unique across all siblings.
    /// </summary>
    [HttpPost]
    [Route("api.user.tree.node.create")]
    public ActionResult<bool> Create()
    {
        return Ok(true);
    }
    
    /// <summary>
    /// Delete an existing node in your tree.
    /// You must specify a node ID that belongs your tree.
    /// </summary>
    [HttpPost]
    [Route("api.user.tree.node.delete")]
    public ActionResult<bool> Delete()
    {
        return Ok(true);
    }
    
    /// <summary>
    /// Rename an existing node in your tree.
    /// You must specify a node ID that belongs your tree.
    /// A new name of the node must be unique across all siblings.
    /// </summary>
    [HttpPost]
    [Route("api.user.tree.node.rename")]
    public ActionResult<bool> Rename()
    {
        return Ok(true);
    }

}