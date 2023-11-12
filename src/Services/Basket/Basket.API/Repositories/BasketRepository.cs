namespace Basket.API.Repositories;

public class BasketRepository : IBasketRepository
{
    private readonly ConnectionMultiplexer _redisCache;

    public BasketRepository(ConnectionMultiplexer cache)
    {
        _redisCache = cache ?? throw new ArgumentNullException();
    }

    public Task<bool> DeleteBasketAsync(string customerId)
    {
        throw new NotImplementedException();
    }

    public Task<CustomerBasket> GetCustomerBasketAsync(string customerId)
    {
        throw new NotImplementedException();
    }

    public Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
    {
        throw new NotImplementedException();
    }
}