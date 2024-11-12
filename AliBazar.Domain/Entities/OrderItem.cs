namespace AliBazar.Domain.Entities;

public class OrderItem
{
    public long Id { get; set; }
    public required long OrderId { get; set; }
    public required long ProductId { get; set; }
    public required long Quantity { get; set; }
    public required decimal Price { get; set; } // Mahsulotning buyurtma paytidagi narxi

    // Order va Product bilan bog'lanish
    public Order Order { get; set; }
    public Product Product { get; set; }
}
