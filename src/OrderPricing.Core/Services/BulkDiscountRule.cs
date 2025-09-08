using OrderPricing.Core.Entities;

namespace OrderPricing.Core.Services;

public class BulkDiscountRule(int minimumQuantity, decimal discountPercentage) : IDiscountRule
{
    private readonly int _minimumQuantity = minimumQuantity;
    private readonly decimal _discountPercentage = discountPercentage;

    public void Apply(List<OrderItem> items, Order order)
    {
        decimal totalDiscount = 0;

        foreach (var item in items)
        {
            totalDiscount += CalculateItemDiscount(item);
        }

        order.Discount += totalDiscount;
    }

    private decimal CalculateItemDiscount(OrderItem item)
    {
        if (item.Quantity < _minimumQuantity)
        {
            return 0;
        }

        var discountGroups = item.Quantity / _minimumQuantity;
        var discountedQuantity = discountGroups * _minimumQuantity;
        var discountPerUnit = CalculateDiscountPerUnit(item.Product.UnitPrice);
        
        return discountedQuantity * discountPerUnit;
    }

    private decimal CalculateDiscountPerUnit(decimal unitPrice)
    {
        return unitPrice * (_discountPercentage / 100m);
    }
}