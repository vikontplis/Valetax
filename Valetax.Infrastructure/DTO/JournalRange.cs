namespace Valetax.Infrastructure.DTO;

public class JournalRange
{
    public long Skip { get; set; }
    public long Take { get; set; }
    public List<JournalInfo> Items { get; set; }
}