using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.UnitTests.Config;

public class TestConfigHelper
{
    public static IConfigurationRoot GetIConfigurationRoot()
    {
        return new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();
    }

    public static TestConfig GetTestConfiguration()
    {
        var configuration = new TestConfig();
        GetIConfigurationRoot().Bind("TestConfig", configuration);
        return configuration;
    }
}
