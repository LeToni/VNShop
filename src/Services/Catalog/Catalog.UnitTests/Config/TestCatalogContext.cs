namespace Catalog.UnitTests.Config;

public class TestCatalogContext : ICatalogContext
{
    public TestCatalogContext(TestConfig config)
    {
        var client = new MongoClient(config.ConnectionString);
        var database = client.GetDatabase(config.DatabaseName);

        Items = database.GetCollection<CatalogItem>("catalog_item_test");
        Categories = database.GetCollection<CatalogCategory>("catalog_category_test");


        bool CatalogItemsExists = Items.Find(_ => true).Any();
       
        if (CatalogItemsExists)
        {
            Items.DeleteMany(_ => true);
        }
        Items.InsertMany(GetFakeCatalog());

        bool CatalogCategoryExists = Items.Find(_ => true).Any();
        if (CatalogCategoryExists)
        {
            Categories.DeleteMany(_ => true);
        }
        Categories.InsertMany(GetFakeCategories());
    }

    public IMongoCollection<CatalogItem> Items { get; init; }

    public IMongoCollection<CatalogCategory> Categories { get; init; }

    private List<CatalogItem> GetFakeCatalog()
    {
        return new List<CatalogItem>()
        {
            new()
            {
                Id = "602d2149e773f2a3990b47f5",
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
                Id = "602d2149e773f2a3990b47f6",
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
                Id = "602d2149e773f2a3990b47f7",
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
                Id = "602d2149e773f2a3990b47f8",
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
                Id = "602d2149e773f2a3990b47f9",
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
                Id = "602d2149e773f2a3990b47fa",
                Name = "Fake Name 6",
                Price = 20.00M,
                Description = "Fake Description 6",
                Category = "Fake Category 5",
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
                Id = "602d2149e773f2a3990b47fb",
                Name = "Fake Category Name A"
            },
            new()
            {
                Id = "602d2149e773f2a3990b47fc",
                Name = "Fake Category Name B"
            }
        };
    }
}
