using Microsoft.Extensions.Options;

namespace Catalog.API.Infrastructure;

public class CatalogContext : ICatalogContext
{
    public CatalogContext(IOptions<CatalogDatabaseSettings> catalogDatabaseSettings)
    {
        var client = new MongoClient(catalogDatabaseSettings.Value.ConnectionString);
        var database = client.GetDatabase(catalogDatabaseSettings.Value.DatabaseName);

        Items = database.GetCollection<CatalogItem>(catalogDatabaseSettings.Value.CatalogItemsCollectionName);
        Categories = database.GetCollection<CatalogCategory>(catalogDatabaseSettings.Value.CatalogCategoriesCollectionName);

    }

    public IMongoCollection<CatalogItem> Items { get; init; }

    public IMongoCollection<CatalogCategory> Categories { get; init; }
}
