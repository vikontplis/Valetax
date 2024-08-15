using Microsoft.EntityFrameworkCore;
using Valetax.Infrastructure.Context;
using Valetax.Infrastructure.Contracts;
using Valetax.Infrastructure.DTO;
using Valetax.Infrastructure.Filters;
using Velatex.Domain.Exceptions;

namespace Valetax.Infrastructure.Services;

public class JournalService : IJournalService
{
    public JournalService()
    {
    }

    public async Task<JournalRange> GetRange(int skip, int take, JournalFilter? journalFilter)
    {
        if (journalFilter is null)
            throw new JournalFilterInvalidException("Invalid journal filter");

        await using var db = new AppDbContext();

        var jq = db.Journals.AsQueryable();

        if (!string.IsNullOrEmpty(journalFilter.Search))
        {
            jq = jq.Where(j => j.Text.Contains(journalFilter.Search));
        }

        if (journalFilter.From is not null)
        {
            jq = jq.Where(j => j.CreatedAt >= journalFilter.From);
        }

        if (journalFilter.To is not null)
        {
            jq = jq.Where(j => j.CreatedAt <= journalFilter.To);
        }

        var jlist = await jq.Skip(skip).Take(take).ToListAsync();

        var rl = jlist
            .Select(jlitem => new JournalInfo
            {
                Id = jlitem.Id,
                Text = jlitem.Text,
                EventId = jlitem.EventId,
                CreatedAt = jlitem.CreatedAt
            })
            .ToList();

        var jr = new JournalRange()
        {
            Skip = skip,
            Take = take,
            Items = rl
        };

        return jr;
    }

    public async Task<JournalInfo> GetSingle(long eventId)
    {
        await using var db = new AppDbContext();

        var journalItem = await db.Journals
            .SingleOrDefaultAsync(j => j.EventId == eventId);

        if (journalItem is null)
            throw new JournalItemNotFoundException($"Journal item with id: {eventId} not found");

        var jinfo = new JournalInfo
        {
            Id = journalItem.Id,
            Text = journalItem.Text,
            EventId = journalItem.EventId,
            CreatedAt = journalItem.CreatedAt
        };

        return jinfo;
    }
}