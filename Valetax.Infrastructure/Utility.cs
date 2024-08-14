using Microsoft.Extensions.Configuration;

namespace Valetax.Infrastructure;

public static class Utility
{
    public static string? GetConnectionString()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        var configuration = builder.Build();

        return configuration.GetConnectionString("DefaultConnection");
    }
}