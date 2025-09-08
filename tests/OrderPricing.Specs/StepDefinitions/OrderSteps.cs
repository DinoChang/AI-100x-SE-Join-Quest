using OrderPricing.Core.Entities;
using OrderPricing.Core.Services;
using TechTalk.SpecFlow;
using Xunit;

namespace OrderPricing.Specs.StepDefinitions;

[Binding]
public class OrderSteps
{
    private readonly ScenarioContext _scenarioContext;
    private readonly List<OrderItem> _orderItems = [];
    private Order _resultOrder = new();
    private decimal _thresholdAmount;
    private decimal _thresholdDiscount;
    private bool _buyOneGetOneActive;

    public OrderSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    private OrderService GetOrderService()
    {
        // 如果 ScenarioContext 中沒有 OrderService，則創建一個新的
        if (!_scenarioContext.ContainsKey("OrderService"))
        {
            _scenarioContext["OrderService"] = new OrderService();
        }
        return (OrderService)_scenarioContext["OrderService"];
    }

    [Given(@"no promotions are applied")]
    public static void GivenNoPromotionsAreApplied()
    {
        // Walking skeleton: 不做任何事
    }

    [Given(@"the threshold discount promotion is configured:")]
    public void GivenTheThresholdDiscountPromotionIsConfigured(Table table)
    {
        var row = table.Rows[0];
        _thresholdAmount = decimal.Parse(row["threshold"]);
        _thresholdDiscount = decimal.Parse(row["discount"]);
        GetOrderService().SetThresholdDiscount(_thresholdAmount, _thresholdDiscount);
    }

    [Given(@"the buy one get one promotion for cosmetics is active")]
    public void GivenTheBuyOneGetOnePromotionForCosmeticsIsActive()
    {
        _buyOneGetOneActive = true;
        GetOrderService().SetBuyOneGetOnePromotion(_buyOneGetOneActive);
    }

    [When(@"a customer places an order with:")]
    public void WhenACustomerPlacesAnOrderWith(Table table)
    {
        foreach (var row in table.Rows)
        {
            var product = new Product
            {
                Name = row["productName"],
                UnitPrice = decimal.Parse(row["unitPrice"]),
                Category = row.ContainsKey("category") ? row["category"] : "default"
            };

            var orderItem = new OrderItem
            {
                Product = product,
                Quantity = int.Parse(row["quantity"])
            };

            _orderItems.Add(orderItem);
        }

        _resultOrder = GetOrderService().Checkout(_orderItems);
    }

    [Then(@"the order summary should be:")]
    public void ThenTheOrderSummaryShouldBe(Table table)
    {
        var expectedRow = table.Rows[0];
        
        if (expectedRow.ContainsKey("totalAmount"))
        {
            var expectedTotal = decimal.Parse(expectedRow["totalAmount"]);
            Assert.Equal(expectedTotal, _resultOrder.TotalAmount);
        }
        
        if (expectedRow.ContainsKey("originalAmount"))
        {
            var expectedOriginal = decimal.Parse(expectedRow["originalAmount"]);
            Assert.Equal(expectedOriginal, _resultOrder.OriginalAmount);
        }
        
        if (expectedRow.ContainsKey("discount"))
        {
            var expectedDiscount = decimal.Parse(expectedRow["discount"]);
            Assert.Equal(expectedDiscount, _resultOrder.Discount);
        }
    }

    [Then(@"the customer should receive:")]
    public void ThenTheCustomerShouldReceive(Table table)
    {
        foreach (var row in table.Rows)
        {
            var expectedProductName = row["productName"];
            var expectedQuantity = int.Parse(row["quantity"]);

            var actualItem = _resultOrder.Items.Find(item => item.Product.Name == expectedProductName);
            
            Assert.NotNull(actualItem);
            Assert.Equal(expectedQuantity, actualItem.Quantity);
        }
    }
}