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
    
    [Fact]
    public async void CreateTreeTest()
    {
        var service = new TreeService();
        
        var result = await service.CreateTree("Root3");
        
        Assert.NotNull(result);
    }
    
    [Fact]
    public async void GetTreeTest()
    {
        var service = new TreeService();
        
        var result = await service.GetTree("Root1");
        
        Assert.NotNull(result);
    }
}