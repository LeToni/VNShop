namespace Basket.API.Entities;

public class CustomerBasket
{
    public string BuyerId { get; set; }
    public List<BasketItem> BasketItems { get; set; } = new();

    public CustomerBasket(string customerId)
    {
        BuyerId = customerId;
    }
}