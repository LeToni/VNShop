namespace Catalog.FunctionalTests;

public class CatalogScenarioBase
{
    private class CatalogApplication : WebApplicationFactory<Program>
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.ConfigureAppConfiguration(c =>
            {
                var directory = Path.GetDirectoryName(typeof(CatalogScenarioBase).Assembly.Location)!;
                c.AddJsonFile(Path.Combine(directory, "appsettings.test.json"), optional: false);
            });

            return base.CreateHost(builder);
        }
    }

    public TestServer CreateServer()
    {
        var factory = new CatalogApplication();
        return factory.Server;
    }

    public static class Get
    {
        private const int PageIndex = 0;
        private const int PageCount = 6;

        public static string Items()
        {
            return "api/v1/catalog/items" + Paginated(PageIndex, PageCount);
        }

        public static string ItemsById(string id) 
        {
            return $"api/v1/catalog/items/{id}";
        }

        public static string ItemByName(string name)
        {
            return $"api/v1/catalog/items/withname/{name}" + Paginated(PageIndex, PageCount);
        }

        private static string Paginated(int pageIndex, int pageCount)
        {
            return $"?pageIndex={pageIndex}&pageSize={pageCount}";
        }
    }
}
