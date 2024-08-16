using Valetax.Infrastructure.Contracts;

namespace Valetax.Infrastructure.Services;

public class UserRememberMe : IUSerRememberMe
{
    public bool RememberMe(string code)
    { 
        // for test internal errors
        if(code == "0") throw new Exception("Сode must not be zero.");
        return true;
    }
}