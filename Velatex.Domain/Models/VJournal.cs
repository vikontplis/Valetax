namespace Velatex.Domain.Models;

public class VJournal
{
    public long Id { get; set; }
    public long EventId { get; set; }
    public string Text { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? Query { get; set; }
    public string? Path { get; set; }
    public string? Body { get; set; }
    public string? Trace { get; set; }
}