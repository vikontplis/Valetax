namespace Valetax.Infrastructure.Contracts;

public interface ITreeNodeService
{
    Task CreateNode(string? treeName, long? parentNodeId, string nodeName);
    Task DeleteNode(string? treeName, long? nodeId);
    Task RenameNode(string? treeName, long? nodeId, string? newNodeName);
}