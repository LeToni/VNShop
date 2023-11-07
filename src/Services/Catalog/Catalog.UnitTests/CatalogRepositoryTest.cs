using Castle.Core.Configuration;
using Catalog.API.Infrastructure;
using Catalog.API.Repositories;
using Catalog.API.ViewModel;
using MongoDB.Driver;
using Moq;

namespace Catalog.UnitTests;

public class CatalogRepositoryTest
{
    private readonly Mock<CatalogContext> _mockCatalogContext;
    public CatalogRepositoryTest() {

        _mockCatalogContext = new Mock<CatalogContext>();

        _mockCatalogContext.Setup(x => x.Items).Returns(GetFakeCatalog);
    }


    [Fact]
    public async Task Get_Catalog_Items_Success()
    {
        var pageSize = 4;
        var pageIndex = 1;

        var expectedItemsInPage = 2;
        var expectedTotalItems = 6;

        var catalogRepository = new CatalogRepository(_mockCatalogContext);

        var result = await catalogRepository.GetCatalogItemsAsync(pageIndex, pageSize);

        Assert.IsType<PaginatedItemsViewModel<CatalogItem>>(result);
    }

    private List<CatalogItem> GetFakeCatalog()
    {
        return new List<CatalogItem>()
        {
            new()
            {
                Id = "FakeIdA",
                Name = "Fake Name 1",
                Price = 10.00M,
                Description = "Fake Description 1",
                Category = "Fake Category 2",
                Image = "FakeImage1.jpg",
                rating = new(){
                    Rate = 1.0,
                    Count = 100
                } 
            },
            new()
            {
                Id = "FakeIdB",
                Name = "Fake Name 2",
                Price = 10.00M,
                Description = "Fake Description 2",
                Category = "Fake Category 2",
                Image = "FakeImage2.jpg",
                rating = new(){
                    Rate = 1.0,
                    Count = 100
                }
            },
            new()
            {
                Id = "FakeIdB3",
                Name = "Fake Name 3",
                Price = 20.00M,
                Description = "Fake Description 3",
                Category = "Fake Category 3",
                Image = "FakeImage3.jpg",
                rating = new(){
                    Rate = 1.0,
                    Count = 100
                }
            },
            new()
            {
                Id = "FakeId4",
                Name = "Fake Name 4",
                Price = 20.00M,
                Description = "Fake Description 4",
                Category = "Fake Category 4",
                Image = "FakeImage4.jpg",
                rating = new(){
                    Rate = 1.0,
                    Count = 100
                }
            },
            new()
            {
                Id = "FakeId5",
                Name = "Fake Name 5",
                Price = 20.00M,
                Description = "Fake Description 5",
                Category = "Fake Category 5",
                Image = "FakeImage5.jpg",
                rating = new(){
                    Rate = 1.0,
                    Count = 100
                }
            },
            new()
            {
                Id = "FakeId6",
                Name = "Fake Name 6",
                Price = 20.00M,
                Description = "Fake Description 6",
                Category = "Fake Category 6",
                Image = "FakeImage6.jpg",
                rating = new(){
                    Rate = 1.0,
                    Count = 100
                }
            }
        };
    }

    private List<CatalogCategory> GetFakeCategories()
    {
        return new List<CatalogCategory>()
        {
            new()
            {
                Id = "FakeIdA",
                Name = "Fake Category Name A"
            },
            new()
            {
                Id = "FakeIdB",
                Name = "Fake Category Name B"
            }
        };
    }
}
