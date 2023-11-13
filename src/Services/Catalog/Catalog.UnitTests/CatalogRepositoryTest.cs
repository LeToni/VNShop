namespace Catalog.UnitTests;

public class CatalogRepositoryTest : BaseTest
{
    private readonly CatalogRepository repository;

    public CatalogRepositoryTest() {
        repository = new CatalogRepository(_context);
    }

    
    [Fact]
    public async Task Get_All_Catalog_Items_Success()
    {
        var pageSize = 4;
        var pageIndex = 1;

        var expectedItemsInPage = 2;
        var expectedTotalItems = 6;

        var result = await repository.GetCatalogItemsAsync(pageIndex, pageSize);

        var page = Assert.IsAssignableFrom<PaginatedItemsViewModel<CatalogItem>>(result);

        Assert.Equal(expectedTotalItems, page.Count);
        Assert.Equal(pageIndex, page.PageIndex);
        Assert.Equal(pageSize, page.PageSize);
        Assert.Equal(expectedItemsInPage, page.Data.Count());
    }

    [Fact]
    public async Task Get_Specific_Catalog_Items_Success()
    {

        var catalogId = "602d2149e773f2a3990b47f8";
        var expectedCatalogName = "Fake Name 4";

        var result = await repository.GetCatalogItemAsync(catalogId);

        var actualItem = Assert.IsAssignableFrom<CatalogItem>(result);

        Assert.Equal(catalogId, actualItem.Id);
        Assert.Equal(expectedCatalogName, actualItem.Name);
    }

    [Fact]
    public async Task Get_Catalog_Items_By_Category_Success()
    {
        var pageSize = 4;
        var pageIndex = 0;

        var category = "Fake Category 5";

        var expectedItemsInPage = 2;
        var expectedTotalItems = 2;

        var result = await repository.GetCatalogItemsByCategoryAsync(category, pageIndex, pageSize);

        var page = Assert.IsAssignableFrom<PaginatedItemsViewModel<CatalogItem>>(result);

        Assert.Equal(expectedTotalItems, page.Count);
        Assert.Equal(pageIndex, page.PageIndex);
        Assert.Equal(pageSize, page.PageSize);
        Assert.Equal(expectedItemsInPage, page.Data.Count());
    }
}
