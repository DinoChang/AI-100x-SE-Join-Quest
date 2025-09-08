using OrderPricing.Core.Entities;

namespace OrderPricing.Core.Services;

public class ThresholdDiscountRule : IDiscountRule
{
    private readonly decimal _thresholdAmount;
    private readonly decimal _discount;

    public ThresholdDiscountRule(decimal thresholdAmount, decimal discount)
    {
        _thresholdAmount = thresholdAmount;
        _discount = discount;
    }

    public void Apply(List<OrderItem> items, Order order)
    {
        if (_thresholdAmount > 0 && order.OriginalAmount >= _thresholdAmount)
        {
            order.Discount += _discount;
        }
    }
}