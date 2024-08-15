namespace Velatex.Domain.Exceptions;

public class JournalFilterInvalidException : SecureException
{
    public JournalFilterInvalidException(string message) : base(message)
    {
    }
}