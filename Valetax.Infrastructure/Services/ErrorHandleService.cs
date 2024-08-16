using Valetax.Infrastructure.Context;
using Valetax.Infrastructure.Contracts;
using Valetax.Infrastructure.DTO;
using Velatex.Domain.Exceptions;
using Velatex.Domain.Models;

namespace Valetax.Infrastructure.Services;

public class ErrorHandleService : IErrorHandleService
{
    public ErrorHandleService()
    {
    }

    public async Task<ProblemDetailsResponse> SaveErrorToJournal(
        string path, string query, string body, Exception ex)
    {
        const string secureKind = "Secure";
        const string serverKind = "Exception";

        try
        {
            var exceptionKind = ex is SecureException ? secureKind : serverKind;

            // Save
            await using var db = new AppDbContext();

            var journalRec = new VJournal()
            {
                Body = body,
                Query = query,
                Text = ex.Message,
                Path = path,
                Trace = ex.StackTrace,
                CreatedAt = DateTime.UtcNow
            };
            
            db.Journals.Add(journalRec);
            await db.SaveChangesAsync();
            
            var eventId = journalRec.EventId;

            var message = exceptionKind == secureKind ? ex.Message : $"Internal server error ID = {eventId} of event";

            return new ProblemDetailsResponse(exceptionKind, eventId, message);
        }
        catch (Exception e)
        {
            throw new JournalException("Error writing to journal.");
        }
    }
}