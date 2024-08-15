namespace Velatex.Domain.Exceptions;

public class JournalItemNotFoundException : SecureException
{
    public JournalItemNotFoundException(string message) : base(message)
    {
    }
}