namespace Catalog.API.Infrastructure;

public interface ICatalogContext
{
    IMongoCollection<CatalogItem> Items { get; }
    IMongoCollection<CatalogCategory> Categories { get; }
}
