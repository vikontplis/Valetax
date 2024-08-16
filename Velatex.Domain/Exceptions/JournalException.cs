namespace Velatex.Domain.Exceptions;

public class JournalException : SecureException
{
    public JournalException(string message) : base(message)
    {
    }
}