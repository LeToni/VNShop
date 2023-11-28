using Basket.API.Entities;
using Basket.API.Repositories;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace Basket.FunctionalTests;

public class BasketRepositoryTests : BasketScenarioBase
{


    BasketRepository BuildBasketRepository(IDistributedCache cache)
    {
        return new BasketRepository(cache);
    }

    [Fact]
    public async Task UpdateBasket_return_and_add_basket()
    {
        using (var server = CreateServer())
        { 
            var cache = server.Services.GetService<IDistributedCache>();

            var redisBasketRepository = BuildBasketRepository(cache);

            var basket = await redisBasketRepository.UpdateBasketAsync(new CustomerBasket("customerId")
            {
                BuyerId = "buyerId",
                BasketItems = BuildBasketItems()
            });

            Assert.NotNull(basket);
            Assert.Single(basket.BasketItems);
        }
    }

    [Fact]
    public async Task Delete_Basket_return_null()
    {

        using (var server = CreateServer())
        {
            var cache = server.Services.GetRequiredService<IDistributedCache>();

            var basketRepository = BuildBasketRepository(cache);

            var basket = await basketRepository.UpdateBasketAsync(new CustomerBasket("customerId")
            {
                BuyerId = "buyerId",
                BasketItems = BuildBasketItems()
            });

            await basketRepository.DeleteBasketAsync("buyerId");

            var result = await basketRepository.GetCustomerBasketAsync(basket.BuyerId);

            Assert.Null(result);
        }
    }

    List<BasketItem> BuildBasketItems()
    {
        return new List<BasketItem>()
            {
                new BasketItem()
                {
                    Id = "basketId",
                    PictureUrl = "pictureurl",
                    ProductId = 1,
                    ProductName = "productName",
                    Quantity = 1,
                    Price = 1
                }
            };
    }
}

