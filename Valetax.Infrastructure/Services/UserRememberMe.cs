using Valetax.Infrastructure.Contracts;

namespace Valetax.Infrastructure.Services;

public class UserRememberMe : IUSerRememberMe
{
    public bool RememberMe(string code)
    {
        return true;
    }
}