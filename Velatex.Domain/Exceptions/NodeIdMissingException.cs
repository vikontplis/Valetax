namespace Velatex.Domain.Exceptions;

public class NodeIdMissingException : SecureException
{
    public NodeIdMissingException(string message) : base(message)
    {
    }
}