namespace Basket.API.Repositories;

public class BasketRepository : IBasketRepository
{
    private readonly IDistributedCache _cache;

    public BasketRepository(IDistributedCache cache)
    {
        _cache = cache ?? throw new ArgumentNullException();
    }

    public async Task DeleteBasketAsync(string customerId)
    {
        await _cache.RemoveAsync(customerId);
    }

    public async Task<CustomerBasket?> GetCustomerBasketAsync(string customerId)
    {
        var basket = await _cache.GetStringAsync(customerId);

        if (String.IsNullOrEmpty(basket))
        {
            return null;
        }

        return JsonConvert.DeserializeObject<CustomerBasket>(basket);
    }

    public async Task<CustomerBasket?> UpdateBasketAsync(CustomerBasket basket)
    {
        await _cache.SetStringAsync(basket.BuyerId, JsonConvert.SerializeObject(basket));

        return await GetCustomerBasketAsync(basket.BuyerId);
    }

}