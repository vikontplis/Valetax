namespace Velatex.Domain.Exceptions;

public class TreeNotExistsException : SecureException
{
    public TreeNotExistsException(string message) : base(message)
    {
    }
}