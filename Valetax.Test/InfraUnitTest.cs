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

        var result = await service.GetTree("Root-TEST");

        Assert.NotNull(result);
    }

    [Fact]
    public async void CreateNodeTest()
    {
        var service = new TreeNodeService();

        await service.CreateNode("Root1", 9, "XXX");
    }

    [Fact]
    public async void DeleteNodeTest()
    {
        var service = new TreeNodeService();

        await service.DeleteNode("Root1", 18);
    }

    [Fact]
    public async void RenameNodeTest()
    {
        var service = new TreeNodeService();

        await service.RenameNode("Root1", 18, "N-XYX");
    }
}