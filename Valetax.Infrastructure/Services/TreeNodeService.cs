using Microsoft.EntityFrameworkCore;
using Valetax.Infrastructure.Context;
using Valetax.Infrastructure.Contracts;
using Velatex.Domain.Exceptions;
using Velatex.Domain.Models;

namespace Valetax.Infrastructure.Services;

public class TreeNodeService : ITreeNodeService
{
    public TreeNodeService()
    {
    }

    public async Task CreateNode(string? treeName, long? parentNodeId, string nodeName)
    {
        if (string.IsNullOrEmpty(treeName))
            throw new TreeNameNullOrEmptyException();

        if (parentNodeId is null)
            throw new ParentNodeIdMissingException();

        if (string.IsNullOrEmpty(nodeName))
            throw new NodeNameNullOrEmptyException();

        await using var db = new AppDbContext();

        // find Tree 
        var tree = await db.Nodes
            .SingleOrDefaultAsync(n => n.Name == treeName && n.ParentId == null);

        if (tree is null)
            throw new TreeNotExistsException($"Tree with name: {treeName} not exists");

        // find Node with parentNodeId in Tree
        var parentNode = await db.Nodes
            .Include(n => n.Children)
            .SingleOrDefaultAsync(n => n.Id == parentNodeId);

        if (parentNode is null)
            throw new NodeNotExistsException($"Node with ID = {parentNodeId} not exists.");

        // check if sibling nodes has different Name
        if (parentNode.Children.Any(child => child.Name == nodeName))
        {
            throw new NodeNameAlreadyExistsException(
                $"Node with Name: {nodeName} already exists in parent node with id: {parentNodeId}");
        }

        // create node in DB
        var node = new VNode() { Name = nodeName, ParentId = parentNodeId, TreeId = tree.Id };
        db.Nodes.Add(node);
        await db.SaveChangesAsync();
    }

    public async Task DeleteNode(string? treeName, long? nodeId)
    {
        if (string.IsNullOrEmpty(treeName))
            throw new TreeNameNullOrEmptyException();

        if (nodeId is null)
            throw new NodeIdMissingException($"Node id is null.");

        await using var db = new AppDbContext();

        // find Tree 
        var tree = await db.Nodes
            .SingleOrDefaultAsync(n => n.Name == treeName && n.ParentId == null);

        if (tree is null)
            throw new TreeNotExistsException($"Tree with name: {treeName} not exists");

        // find Node with Id in Tree
        var node = await db.Nodes
            .Include(n => n.Children)
            .SingleOrDefaultAsync(n => n.Id == nodeId && n.TreeId == tree.Id);

        if (node is null)
            throw new NodeNotExistsException($"Node with id: {nodeId} not in tree {treeName}");

        if (node.Children.Any())
            throw new NodeNotEmptyException(
                $"Node {node.Name} not empty. Delete all children nodes before delete action.");

        db.Nodes.Remove(node);
        await db.SaveChangesAsync();
    }

    public async Task RenameNode(string? treeName, long? nodeId, string? newNodeName)
    {
        if (string.IsNullOrEmpty(treeName))
            throw new TreeNameNullOrEmptyException();

        if (nodeId is null)
            throw new NodeIdMissingException($"Node id is null.");

        if (string.IsNullOrEmpty(newNodeName))
            throw new NodeNewNameMissingException($"New node name missing.");

        await using var db = new AppDbContext();

        // find Tree 
        var tree = await db.Nodes
            .SingleOrDefaultAsync(n => n.Name == treeName && n.ParentId == null);

        if (tree is null)
            throw new TreeNotExistsException($"Tree with name: {treeName} not exists");

        // find Node with Id in Tree
        var node = await db.Nodes
            .SingleOrDefaultAsync(n => n.Id == nodeId && n.TreeId == tree.Id);

        if (node is null)
            throw new NodeNotExistsException($"Node with id: {nodeId} not in tree {treeName}");

        if (node.ParentId is null)
            throw new RootNodeRenameException($"Can't rename the root node.");

        // find sibling nodes - check for unique names
        var parentNode = await db.Nodes
            .Include(n => n.Children)
            .SingleOrDefaultAsync(n => n.Id == node.ParentId);

        // check if sibling nodes has different Names
        if (parentNode!.Children.Any(child => child.Name == newNodeName))
        {
            throw new NodeNameAlreadyExistsException(
                $"Node with Name: {newNodeName} already exists in parent node with id: {parentNode.Id}");
        }

        node.Name = newNodeName;
        await db.SaveChangesAsync();
    }
}