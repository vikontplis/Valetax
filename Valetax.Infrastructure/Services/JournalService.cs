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
            throw new JournalFilterInvalidException("Invalid journal filter.");
        
        if(journalFilter.From > journalFilter.To)
            throw new JournalFilterInvalidException("Invalid journal filter: date from more date to.");

        await using var db = new AppDbContext();

        var journalQuery = db.Journals.AsQueryable();

        if (!string.IsNullOrEmpty(journalFilter.Search))
        {
            journalQuery = journalQuery.Where(j => j.Text.Contains(journalFilter.Search));
        }

        if (journalFilter.From is not null)
        {
            journalQuery = journalQuery.Where(j => j.CreatedAt >= journalFilter.From);
        }

        if (journalFilter.To is not null)
        {
            journalQuery = journalQuery.Where(j => j.CreatedAt <= journalFilter.To);
        }

        var journalQueryResult = await journalQuery.Skip(skip).Take(take).ToListAsync();

        var journalInfoItems = journalQueryResult
            .Select(jqr => new JournalInfo
            {
                Id = jqr.Id,
                Text = jqr.Text,
                EventId = jqr.EventId,
                CreatedAt = jqr.CreatedAt
            })
            .ToList();

        var journalRange = new JournalRange()
        {
            Skip = skip,
            Take = take,
            Items = journalInfoItems
        };

        return journalRange;
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