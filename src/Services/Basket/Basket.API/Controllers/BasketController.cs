namespace Basket.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class BasketController : ControllerBase
{
    private readonly IBasketRepository _basketRepository;

    public BasketController(IBasketRepository basketRepository)
    {
        _basketRepository = basketRepository ?? throw new ArgumentNullException(nameof(basketRepository));
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<CustomerBasket>> GetBasket(string customerId)
    {
        var basket = await _basketRepository.GetCustomerBasketAsync(customerId);

        if (basket == null)
        {
            return new CustomerBasket(customerId);
        }

        return Ok(basket);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<CustomerBasket>> UpdateBasket([FromBody] CustomerBasket basket)
    {
        return Ok(await _basketRepository.UpdateBasketAsync(basket));
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteBasket(string customerId)
    {
        await _basketRepository.DeleteBasketAsync(customerId);

        return Ok();
    }
}