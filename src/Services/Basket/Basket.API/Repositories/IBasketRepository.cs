namespace Basket.API.Repositories;

public interface IBasketRepository
{
    Task<CustomerBasket> GetCustomerBasketAsync(string customerId);
    Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket);
    Task<bool> DeleteBasketAsync(string customerId);
}