using Valetax.Infrastructure.Contracts;

namespace Valetax.Infrastructure.Services;

public class UserRememberMe : IUSerRememberMe
{
    public bool RememberMe(string code)
    {
        throw new Exception("Test except");
        return true;
    }
}