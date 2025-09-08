using OrderPricing.Core.Entities;

namespace OrderPricing.Core.Services;

public class OrderService
{
    private readonly List<IDiscountRule> _discountRules = new();

    public void SetThresholdDiscount(decimal thresholdAmount, decimal discount)
    {
        // 移除舊的門檻折扣規則
        _discountRules.RemoveAll(rule => rule is ThresholdDiscountRule);
        
        // 加入新的門檻折扣規則
        if (thresholdAmount > 0)
        {
            _discountRules.Add(new ThresholdDiscountRule(thresholdAmount, discount));
        }
    }

    public void SetBuyOneGetOnePromotion(bool active)
    {
        // 移除舊的買一送一規則
        _discountRules.RemoveAll(rule => rule is BuyOneGetOneRule);
        
        // 加入新的買一送一規則
        if (active)
        {
            _discountRules.Add(new BuyOneGetOneRule("cosmetics"));
        }
    }
    
    public Order Checkout(List<OrderItem> items)
    {
        var order = new Order();
        
        // 初始化訂單項目（基於原始輸入）
        var processedItems = new List<OrderItem>();
        foreach (var item in items)
        {
            processedItems.Add(new OrderItem
            {
                Product = item.Product,
                Quantity = item.Quantity
            });
        }
        
        order.Items = processedItems;
        
        // 計算原始金額（基於原始數量）
        decimal originalTotal = 0;
        foreach (var item in items)
        {
            originalTotal += item.Product.UnitPrice * item.Quantity;
        }
        
        order.OriginalAmount = originalTotal;
        order.Discount = 0;
        
        // 套用所有折扣規則
        foreach (var rule in _discountRules)
        {
            rule.Apply(items, order);
        }
        
        order.TotalAmount = order.OriginalAmount - order.Discount;
        
        return order;
    }
}