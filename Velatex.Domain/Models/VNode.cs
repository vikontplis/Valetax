using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Velatex.Domain.Models;

public class VNode
{
    public long Id { get; set; }
    [Required] public string Name { get; set; }
    public long? ParentId { get; set; }
    [JsonIgnore] public virtual VNode Parent { get; set; }

    [JsonIgnore] public long TreeId { get; set; }
    public virtual IEnumerable<VNode> Children { get; set; } = new List<VNode>();

    public override string ToString()
    {
        var parId = ParentId is null ? "null" : ParentId.ToString();
        var info = new StringBuilder($"Name: {Name} ParentID: {parId}");

        if (!Children.Any()) return info.ToString();

        info.Append(" children: [");
        foreach (var child in Children)
        {
            var childParId = child.ParentId is null ? "null" : child.ParentId.ToString();
            info.Append($"{{ Name: {child.Name}, ParentID: {childParId} }}");
        }

        info.Append("] ");

        return info.ToString();
    }
}