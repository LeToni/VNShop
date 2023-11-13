namespace Catalog.API.Infrastructure;

public interface ICatalogContext
{
    public IMongoCollection<CatalogItem> Items { get; }
    public IMongoCollection<CatalogCategory> Categories { get; }
}
