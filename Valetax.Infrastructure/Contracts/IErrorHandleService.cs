using Valetax.Infrastructure.DTO;

namespace Valetax.Infrastructure.Contracts;

public interface IErrorHandleService
{
    Task<ProblemDetailsResponse> SaveErrorToJournal(
        string path, string query, string body, Exception ex);
}