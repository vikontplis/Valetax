namespace Velatex.Domain.Exceptions;

public class TreeNameAlreadyExistsException : SecureException
{
    public TreeNameAlreadyExistsException(string message) : base(message)
    {
    }
}