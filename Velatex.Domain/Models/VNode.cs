namespace Velatex.Domain.Models;

public class VNode
{
    public long Id { get; set; }
    public string Name { get; set; } 
    public long? ParentId { get; set; }
    public virtual VNode Parent { get; set; }
    public virtual IEnumerable<VNode> Children { get; set; }
}
