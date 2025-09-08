namespace OrderPricing.Core.Entities;

public class Order
{
    public List<OrderItem> Items { get; set; } = new();
    public decimal TotalAmount { get; set; }
    public decimal OriginalAmount { get; set; }
    public decimal Discount { get; set; }
}