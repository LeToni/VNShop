using Catalog.API.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CatalogController : ControllerBase
{
    private readonly ICatalogRepository _catalogRepository;

    public CatalogController(ICatalogRepository catalogRepository)
    {
        _catalogRepository = catalogRepository ?? throw new ArgumentNullException(nameof(catalogRepository));
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<PaginatedItemsViewModel<CatalogItem>>> CatalogItems([FromQuery] int pageIndex = 0, [FromQuery] int pageSize = 10)
    {
        var catalogItems = await _catalogRepository.GetCatalogItemsAsync(pageIndex, pageSize);

        return catalogItems;
    }

    [HttpGet("items/id")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CatalogItem>> CatalogItemById(string id)
    {
        var catalogItem = await _catalogRepository.GetCatalogItemAsync(id);

        if (catalogItem == null)
        {
            return NotFound();
        }

        return catalogItem;
    }

    [HttpGet]
    [Route("items/withname/{name:minlength(1)}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<PaginatedItemsViewModel<CatalogItem>>> CatalogItemsWithNameAsync(string name, [FromQuery] int pageIndex = 0, [FromQuery] int pageSize = 10)
    {
        var itemsVM = await _catalogRepository.GetCatalogItemsByNameAsync(name, pageIndex, pageSize);

        return itemsVM;
    }

    [HttpGet]
    [Route("items/category/{name:minlength(1)}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<PaginatedItemsViewModel<CatalogItem>>> CatalogItemsByCategoryAsync(string name, [FromQuery] int pageIndex = 0, [FromQuery] int pageSize = 10)
    {
        var itemsVM = await _catalogRepository.GetCatalogItemsByCategoryAsync(name, pageIndex, pageSize);

        return itemsVM;
    }

    [HttpGet]
    [Route("categories")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<CatalogCategory>>> CatalogCategoriesAsync()
    {
        var categories = await _catalogRepository.GetCatalogCategoriesAsync();

        return Ok(categories);
    }
}
