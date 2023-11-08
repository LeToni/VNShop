using Catalog.API.Infrastructure;
using MongoDB.Driver;
using Moq;

namespace Catalog.UnitTests;

public class CatalogRepositoryTest
{
    private Mock<ICatalogContext> _mockCatalogContext;
    private Mock<IMongoCollection<CatalogItem>> _mockCatalogItemCollection;
    private Mock<IAsyncCursor<CatalogItem>> _mockAsyncCursor;


    public CatalogRepositoryTest() {

        _mockCatalogContext = new();

        _mockCatalogItemCollection = new();

        // Mock IAsyncCursor
        _mockAsyncCursor = new();
        _mockAsyncCursor.Setup(_ => _.Current).Returns(GetFakeCatalog);
        _mockAsyncCursor.SetupSequence(x => x.MoveNext(It.IsAny<CancellationToken>())).Returns(true).Returns(false);
        _mockAsyncCursor.SetupSequence(x => x.MoveNextAsync(It.IsAny<CancellationToken>())).Returns(Task.Run(()=>true)).Returns(Task.Run(() => false));

        _mockCatalogItemCollection.Setup(x => x.AggregateAsync(It.IsAny<PipelineDefinition<CatalogItem,CatalogItem>>(), It.IsAny<AggregateOptions>(), It.IsAny<CancellationToken>())).ReturnsAsync(_mockAsyncCursor.Object);

        _mockCatalogContext.Setup(x => x.Items).Returns(_mockCatalogItemCollection.Object);
    }

    
    [Fact]
    public async Task Get_All_Catalog_Items_Success()
    {
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
