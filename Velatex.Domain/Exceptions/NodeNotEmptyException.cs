namespace Velatex.Domain.Exceptions;

public class NodeNotEmptyException : SecureException
{
    public NodeNotEmptyException(string message) : base(message)
    {
    }
}