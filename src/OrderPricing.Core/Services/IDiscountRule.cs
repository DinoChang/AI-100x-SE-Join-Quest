using OrderPricing.Core.Entities;

namespace OrderPricing.Core.Services;

public interface IDiscountRule
{
    void Apply(List<OrderItem> items, Order order);
}