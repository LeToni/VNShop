using Catalog.API.ViewModel;

namespace Catalog.API.Repositories;

public interface ICatalogRepository
{
    Task<PaginatedItemsViewModel<CatalogItem>> GetCatalogItemsAsync(int pageIndex, int pageSize);
    Task<CatalogItem> GetCatalogItemAsync(string id);
    Task<PaginatedItemsViewModel<CatalogItem>> GetCatalogItemsByNameAsync(string name, int pageIndex, int pageSize);
    Task<PaginatedItemsViewModel<CatalogItem>> GetCatalogItemsByCategoryAsync(string categoryName, int pageIndex, int pageSize);

    Task<IEnumerable<CatalogCategory>> GetCatalogCategoriesAsync();
}
