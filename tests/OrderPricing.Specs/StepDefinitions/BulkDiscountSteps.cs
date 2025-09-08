using OrderPricing.Core.Entities;
using OrderPricing.Core.Services;
using TechTalk.SpecFlow;
using Xunit;

namespace OrderPricing.Specs.StepDefinitions;

[Binding]
public class BulkDiscountSteps
{
    private readonly ScenarioContext _scenarioContext;

    public BulkDiscountSteps(ScenarioContext scenarioContext)
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

    [Given(@"the bulk discount promotion is active with:")]
    public void GivenTheBulkDiscountPromotionIsActiveWith(Table table)
    {
        var row = table.Rows[0];
        var minimumQuantity = int.Parse(row["minimumQuantity"]);
        var discountPercentage = decimal.Parse(row["discountPercentage"]);
        GetOrderService().SetBulkDiscount(minimumQuantity, discountPercentage);
    }

    [Then(@"the discount calculation should be:")]
    public void ThenTheDiscountCalculationShouldBe(Table table)
    {
        // Walking skeleton - 暫時不實作
    }

    [Then(@"no bulk discount should be applied because the products are different")]
    public void ThenNoBulkDiscountShouldBeAppliedBecauseTheProductsAreDifferent()
    {
        // Walking skeleton - 暫時不實作
    }
}