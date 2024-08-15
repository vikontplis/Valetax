using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Valetax.Infrastructure.Contracts;

namespace Valetax.WebAPI.Controllers;

/// <summary>
/// Represents tree node API
/// </summary>
[ApiController]
[SwaggerTag("Represents tree node API")]
[Produces("application/json")]
public class TreeNodeController : ControllerBase
{
    private readonly ITreeNodeService _treeNodeService;

    public TreeNodeController(ITreeNodeService treeNodeService)
    {
        _treeNodeService = treeNodeService;
    }

    /// <summary>
    /// Create a new node in your tree.
    /// You must to specify a parent node ID that belongs to your tree.
    /// A new node name must be unique across all siblings.
    /// </summary>
    [HttpPost]
    [Route("api.user.tree.node.create")]
    public async Task<ActionResult> Create(
        [Required] string? treeName,
        [Required] long? parentNodeId,
        [Required] string nodeName)
    {
        await _treeNodeService.CreateNode(treeName, parentNodeId, nodeName);
        return Ok();
    }

    /// <summary>
    /// Delete an existing node in your tree.
    /// You must specify a node ID that belongs your tree.
    /// </summary>
    [HttpPost]
    [Route("api.user.tree.node.delete")]
    public async Task<ActionResult> Delete(
        [Required] string? treeName,
        [Required] long? nodeId)
    {
        await _treeNodeService.DeleteNode(treeName, nodeId);
        return Ok();
    }

    /// <summary>
    /// Rename an existing node in your tree.
    /// You must specify a node ID that belongs your tree.
    /// A new name of the node must be unique across all siblings.
    /// </summary>
    [HttpPost]
    [Route("api.user.tree.node.rename")]
    public async Task<ActionResult> Rename(
        [Required] string? treeName,
        [Required] long? nodeId,
        [Required] string? newNodeName)
    {
        await _treeNodeService.RenameNode(treeName, nodeId, newNodeName);
        return Ok();
    }
}