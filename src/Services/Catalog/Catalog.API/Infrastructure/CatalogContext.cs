namespace Catalog.API.Infrastructure;

public class CatalogContext : ICatalogContext
{
    public CatalogContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

        Items = database.GetCollection<CatalogItem>(configuration.GetValue<string>("DatabaseSettings:catalog_items"));
        Categories = database.GetCollection<CatalogCategory>(configuration.GetValue<string>("DatabaseSettings:catalog_category"));

    }

    public IMongoCollection<CatalogItem> Items { get; }

    public IMongoCollection<CatalogCategory> Categories { get; }
}
