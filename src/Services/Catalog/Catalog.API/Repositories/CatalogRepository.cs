using Catalog.API.ViewModel;

namespace Catalog.API.Repositories;

public class CatalogRepository : ICatalogRepository
{
    private readonly ICatalogContext _catalogContext;

    public CatalogRepository(ICatalogContext catalogContext) {
        _catalogContext = catalogContext ?? throw new ArgumentNullException(nameof(catalogContext));
    }

    public async Task<IEnumerable<CatalogCategory>> GetCatalogCategoriesAsync()
    {
        var categories = await _catalogContext.Categories.Find(_ => true).ToListAsync();

        return categories;
    }

    public async Task<CatalogItem> GetCatalogItemAsync(string id)
    {
        return await _catalogContext.Items
            .Find(ci => ci.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<PaginatedItemsViewModel<CatalogItem>> GetCatalogItemsAsync(int pageIndex,int pageSize)
    {
        var totalItems = await _catalogContext.Items
            .Find(_ => true)
            .CountDocumentsAsync();

        var itemsOnPage = await _catalogContext.Items
            .Find(_ => true)
            .Skip(pageIndex * pageSize)
            .Limit(pageSize)
            .ToListAsync();

        var pageItemModel = new PaginatedItemsViewModel<CatalogItem>(pageIndex, pageSize, totalItems, itemsOnPage);

        return pageItemModel;
    }

    public async Task<PaginatedItemsViewModel<CatalogItem>> GetCatalogItemsByCategoryAsync(string categoryName, int pageIndex, int pageSize)
    {
        var totalItems = await _catalogContext.Items
            .Find(x => x.Category == categoryName)
            .CountDocumentsAsync();

        var itemsOnPage = await _catalogContext.Items
            .Find(x => x.Category == categoryName)
            .Skip(pageIndex * pageSize)
            .Limit(pageSize)
            .ToListAsync();

        var pageItemModel = new PaginatedItemsViewModel<CatalogItem>(pageIndex, pageSize, totalItems, itemsOnPage);

        return pageItemModel;
    }

    public async Task<PaginatedItemsViewModel<CatalogItem>> GetCatalogItemsByNameAsync(string name, int pageIndex, int pageSize)
    {
        var totalItems = await _catalogContext.Items
            .Find(x => x.Name == name)
            .CountDocumentsAsync();

        var itemsOnPage = await _catalogContext.Items
            .Find(x => x.Name == name)
            .Skip(pageIndex * pageSize)
            .Limit(pageSize)
            .ToListAsync();

        var pageItemModel = new PaginatedItemsViewModel<CatalogItem>(pageIndex, pageSize, totalItems, itemsOnPage);

        return pageItemModel;
    }
}
