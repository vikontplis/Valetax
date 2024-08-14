using Valetax.Infrastructure;

namespace Valetax.Test;

public class InfraUnitTest
{
    [Fact]
    public void IsConnectionStringPresentTest()
    {
        var connectionString = Utility.GetConnectionString();
        
        Assert.NotNull(connectionString);
    }
}