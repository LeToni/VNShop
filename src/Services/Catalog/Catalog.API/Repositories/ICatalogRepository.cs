namespace Catalog.API.Repositories;

public interface ICatalogRepository
{
    Task<IEnumerable<CatalogItem>> GetCatalogItems();
    Task<CatalogItem> GetCatalogItem(string id);
    Task<IEnumerable<CatalogItem>> GetCatalogItemsByName(string name);
    Task<IEnumerable<CatalogItem>> GetCatalogItemsByCategory(string categoryName);
}
