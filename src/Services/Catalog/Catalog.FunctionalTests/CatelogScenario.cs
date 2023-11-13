using System.Net;

namespace Catalog.FunctionalTests;

public class CatelogScenario : CatalogScenarioBase
{
    [Fact]
    public async Task Get_get_all_catalogitems_and_response_ok_status_code()
    {
        using var server = CreateServer();
        var response = await server.CreateClient()
            .GetAsync(Get.Items());

        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task Get_get_catalogitem_by_id_and_response_ok_status_code()
    {
        var itemId = "602d2149e773f2a3990b47f5";

        using var server = CreateServer();
        var response = await server.CreateClient()
            .GetAsync(Get.ItemsById(itemId));

        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task Get_get_catalogitem_by_id_and_response_not_found_status_code()
    {
        var itemId = "992d2149e773f2a3990b47f5";

        using var server = CreateServer();
        var response = await server.CreateClient()
            .GetAsync(Get.ItemsById(itemId));

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

}
