using Valetax.Infrastructure.DTO;
using Valetax.Infrastructure.Filters;

namespace Valetax.Infrastructure.Contracts;

public interface IJournalService
{
    Task<JournalRange> GetRange(int skip, int take, JournalFilter? journalFilter);
    Task<JournalInfo> GetSingle(long eventId);
}