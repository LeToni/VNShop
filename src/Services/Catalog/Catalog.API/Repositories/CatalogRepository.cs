namespace Catalog.API.Repositories;

public class CatalogRepository : ICatalogRepository
{
    public Task<CatalogItem> GetCatalogItem(string id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CatalogItem>> GetCatalogItems()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CatalogItem>> GetCatalogItemsByCategory(string categoryName)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CatalogItem>> GetCatalogItemsByName(string name)
    {
        throw new NotImplementedException();
    }
}
