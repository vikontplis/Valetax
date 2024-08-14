using Valetax.Infrastructure.Contracts;

namespace Valetax.Infrastructure.Services;

public class USerRememberMe : IUSerRememberMe
{
    public bool RememberMe(string code)
    {
        return true;
    }
}