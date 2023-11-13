namespace Catalog.UnitTests;

public class BaseTest
{
    protected readonly TestConfig _testConfig;
    protected readonly TestCatalogContext _context;

    public BaseTest()
    {
        _testConfig = TestConfigHelper.GetTestConfiguration();
        _context = new TestCatalogContext(_testConfig);

    }


}
