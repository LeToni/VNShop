using Amazon.SecurityToken.Model;

namespace Catalog.API.Infrastructure;

public class CatalogDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;
    
    public string DatabaseName { get; set; } = null!;
    
    public string CatalogItemsCollectionName { get; set; } = null!;

    public string CatalogCategoriesCollectionName { get; set; } = null!;
}