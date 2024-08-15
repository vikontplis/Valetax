namespace Velatex.Domain.Exceptions;

public class NodeNotExistsException : SecureException
{
    public NodeNotExistsException(string message) : base(message)
    {
    }
}