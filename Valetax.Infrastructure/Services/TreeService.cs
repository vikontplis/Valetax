using Microsoft.EntityFrameworkCore;
using Valetax.Infrastructure.Context;
using Valetax.Infrastructure.Contracts;
using Velatex.Domain.Exceptions;
using Velatex.Domain.Models;

namespace Valetax.Infrastructure.Services;

public class TreeService : ITreeService
{
    public async Task<bool> IsTreeExists(string treeName)
    {
        await using var db = new AppDbContext();
        var isExists = await db.Nodes
            .AnyAsync(n => n.Name == treeName && n.ParentId == null);
        return isExists;
    }

    // TODO: refactor to CTE (raw sql query) !!!
    public async Task<VNode> GetTree(string? treeName)
    {
        if (string.IsNullOrEmpty(treeName))
            throw new TreeNameNullOrEmptyException();

        if (!await IsTreeExists(treeName)) await CreateTree(treeName);

        await using var db = new AppDbContext();

        var rootNode = await db.Nodes
            .SingleAsync(n => n.Name == treeName && n.ParentId == null);

        var allNodesInTree = await db.Nodes
            .Where(n => n.TreeId == rootNode.Id)
            .ToListAsync();

        var root = allNodesInTree.Single(n => n.ParentId is null);
        return root;

    /*
        // unoptimized version
        RecursiveLoad(rootNode);
        return rootNode;

        void RecursiveLoad(VNode parent)
        {
            db
                .Entry(parent)
                .Collection(d => d.Children).Load();

            foreach (var child in parent.Children)
            {
                db.Entry(child).Reference(d => d.Parent).Load();
                RecursiveLoad(child);
            }
        }
    */

    /*
         //show json result
        JsonSerializerOptions options = new()
        {
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            WriteIndented = true
        };

        var js = JsonSerializer.Serialize(node, options);
    */
    }


    // node with ParentID == null is Tree Root
    public async Task<VNode> CreateTree(string? treeName)
    {
        if (string.IsNullOrEmpty(treeName))
            throw new TreeNameNullOrEmptyException();

        if (await IsTreeExists(treeName))
            throw new TreeNameAlreadyExistsException($"The tree name {treeName} already exists.");

        var node = new VNode() { Name = treeName };

        await using var db = new AppDbContext();
        db.Nodes.Add(node);
        await db.SaveChangesAsync();

        node.TreeId = node.Id;
        await db.SaveChangesAsync();

        return node;
    }
}