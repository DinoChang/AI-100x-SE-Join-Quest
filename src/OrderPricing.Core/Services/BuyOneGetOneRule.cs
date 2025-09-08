using OrderPricing.Core.Entities;

namespace OrderPricing.Core.Services;

public class BuyOneGetOneRule : IDiscountRule
{
    private readonly string _category;

    public BuyOneGetOneRule(string category)
    {
        _category = category;
    }

    public void Apply(List<OrderItem> items, Order order)
    {
        foreach (var orderItem in order.Items)
        {
            if (orderItem.Product.Category == _category)
            {
                // 找到對應的原始項目
                var originalItem = items.Find(item => item.Product.Name == orderItem.Product.Name);
                if (originalItem != null)
                {
                    // 計算贈送數量：買 n 個，送 max(1, floor(n/2)) 個
                    int freeQuantity = Math.Max(1, originalItem.Quantity / 2);
                    orderItem.Quantity = originalItem.Quantity + freeQuantity;
                }
            }
        }
    }
}