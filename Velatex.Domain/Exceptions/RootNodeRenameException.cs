namespace Velatex.Domain.Exceptions;

public class RootNodeRenameException : SecureException
{
    public RootNodeRenameException(string message) : base(message)
    {
    }
}