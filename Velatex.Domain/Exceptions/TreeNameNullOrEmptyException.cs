namespace Velatex.Domain.Exceptions;

public class TreeNameNullOrEmptyException : SecureException
{
    public TreeNameNullOrEmptyException(string message = "The tree name is empty.") : base(message)
    {
    }
}