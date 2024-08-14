using Valetax.Infrastructure;
using Valetax.Infrastructure.Services;

namespace Valetax.Test;

public class InfraUnitTest
{
    [Fact]
    public void IsConnectionStringPresentTest()
    {
        var connectionString = Utility.GetConnectionString();
        
        Assert.NotNull(connectionString);
    }
    
    [Fact]
    public void UserRememberMeTest()
    {
        var result = new UserRememberMe().RememberMe("");
        
        Assert.True(result);
    }
}