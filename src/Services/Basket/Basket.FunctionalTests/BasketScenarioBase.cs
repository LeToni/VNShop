using Microsoft.AspNetCore.Hosting;

namespace Basket.FunctionalTests;
public class BasketScenarioBase
{
    private const string baseUrl = "api/v1/basket";


    private class BasketApplication : WebApplicationFactory<Program>
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.ConfigureAppConfiguration(c =>
            {
                var directory = Path.GetDirectoryName(typeof(BasketScenarioBase).Assembly.Location)!;
                c.AddJsonFile(Path.Combine(directory, "appsettings.test.json"), optional: false);
            });

            return base.CreateHost(builder);
        }
    }

    public TestServer CreateServer()
    {
        var factory = new BasketApplication();
        return factory.Server;
    }

    public static class Get
    {
        public static string GetBasket(int id)
        {
            return $"{baseUrl}/{id}";
        }
    }

    public static class Post
    {
        public static string Basket = $"{baseUrl}/";
    }
}
