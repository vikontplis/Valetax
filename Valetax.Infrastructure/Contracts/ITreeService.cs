using Velatex.Domain.Models;

namespace Valetax.Infrastructure.Contracts;

public interface ITreeService
{
    Task<bool> IsTreeExists(string treeName);
    Task<VNode> CreateTree(string? treeName);
    Task<VNode> GetTree(string? treeName);
}