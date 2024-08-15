namespace Velatex.Domain.Exceptions;

public class ParentNodeIdMissingException : SecureException
{
    public ParentNodeIdMissingException(string message = "The ID of the parent node is missing.") : base(message)
    {
    }
}