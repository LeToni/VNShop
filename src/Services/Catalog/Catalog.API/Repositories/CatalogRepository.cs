namespace Catalog.API.Repositories;

public class CatalogRepository : ICatalogRepository
{
    private readonly ICatalogContext _catalogContext;

    public CatalogRepository(ICatalogContext catalogContext) {
        _catalogContext = catalogContext ?? throw new ArgumentNullException(nameof(catalogContext));
    }

    public async Task<CatalogItem> GetCatalogItem(string id)
    {
        return await _catalogContext.Items.Find(ci => ci.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<CatalogItem>> GetCatalogItems()
    {
        return await _catalogContext.Items.Find(ci => true).ToListAsync();
    }

    public async Task<IEnumerable<CatalogItem>> GetCatalogItemsByCategory(string categoryName)
    {
        FilterDefinition<CatalogItem> filter = Builders<CatalogItem>.Filter.Eq(ci => ci.Category.Name, categoryName);

        return await _catalogContext.Items.Find(filter).ToListAsync();
    }

    public async Task<IEnumerable<CatalogItem>> GetCatalogItemsByName(string name)
    {
        FilterDefinition<CatalogItem> filter = Builders<CatalogItem>.Filter.ElemMatch(ci => ci.Name, name);
       
       return await _catalogContext.Items.Find(filter).ToListAsync();
    }
}
