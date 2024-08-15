namespace Velatex.Domain.Exceptions;

public class NodeNameAlreadyExistsException : SecureException
{
    public NodeNameAlreadyExistsException(string message) : base(message)
    {
    }
}