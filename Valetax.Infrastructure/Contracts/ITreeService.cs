using System.ComponentModel.DataAnnotations;
using Velatex.Domain.Models;

namespace Valetax.Infrastructure.Contracts;

public interface ITreeService
{
    Task<VNode> CreateTree(string? treeName);
    Task<VNode> GetTree(string? treeName);
}