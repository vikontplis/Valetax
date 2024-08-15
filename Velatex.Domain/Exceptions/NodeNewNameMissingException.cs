namespace Velatex.Domain.Exceptions;

public class NodeNewNameMissingException : SecureException
{
    public NodeNewNameMissingException(string message) : base(message)
    {
    }
}