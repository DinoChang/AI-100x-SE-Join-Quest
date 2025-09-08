namespace OrderPricing.Core.Entities;

public class OrderItem
{
    public Product Product { get; set; } = new();
    public int Quantity { get; set; }
}