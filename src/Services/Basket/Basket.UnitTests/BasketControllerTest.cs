namespace Basket.UnitTests;

public class BasketControllerTest
{
    private readonly Mock<IBasketRepository> _basketRepositoryMock;

    public BasketControllerTest() {

        _basketRepositoryMock = new();
    }

    [Fact]
    public async Task Get_customer_basket_success()
    {
        var fakeCustomerId = "1";
        var fakeCustomerBasket = GetCustomerBasketFake(fakeCustomerId);

        _basketRepositoryMock.Setup(x => x.GetCustomerBasketAsync(It.IsAny<string>())).Returns(Task.FromResult(fakeCustomerBasket));


        var basketController = new BasketController(_basketRepositoryMock.Object);

        var actionResult = await basketController.GetBasket(fakeCustomerId);

        Assert.Equal((actionResult.Result as OkObjectResult).StatusCode, (int)System.Net.HttpStatusCode.OK);
        Assert.Equal((((ObjectResult)actionResult.Result).Value as CustomerBasket).BuyerId, fakeCustomerId);
    }

    [Fact]
    public async Task Post_customer_basket_success()
    {
        var fakeCustomerId = "1";
        var fakeCustomerBasket = GetCustomerBasketFake(fakeCustomerId);

        _basketRepositoryMock.Setup(x => x.UpdateBasketAsync(It.IsAny<CustomerBasket>()))
                .Returns(Task.FromResult(fakeCustomerBasket));

        var basketController = new BasketController(_basketRepositoryMock.Object);

        var actionResult = await basketController.UpdateBasket(fakeCustomerBasket);

        Assert.Equal((actionResult.Result as OkObjectResult).StatusCode, (int)System.Net.HttpStatusCode.OK);
        Assert.Equal((((ObjectResult)actionResult.Result).Value as CustomerBasket).BuyerId, fakeCustomerId);
    }

    private CustomerBasket GetCustomerBasketFake(string fakeCustomerId)
    {
        return new CustomerBasket(fakeCustomerId)
        {
            BasketItems = new List<BasketItem>()
            {
                new BasketItem()
            }
        };
    }
}