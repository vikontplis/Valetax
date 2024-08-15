namespace Velatex.Domain.Exceptions;

public class NodeNameNullOrEmptyException : SecureException
{
    public NodeNameNullOrEmptyException(string message = "The name name is empty.") : base(message)
    {
    }
}