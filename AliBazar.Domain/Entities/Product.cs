namespace AliBazar.Domain.Entities;

public class Product
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public required string NameUz { get; set; }
    public required string NameRuss { get; set; }
    public string? Description { get; set; }
    public required decimal Price { get; set; }
    public required long CategoryId { get; set; }
    public bool IsDeleted { get; set; } = false;
    public string? ImageUrl { get; set; }
    public List<OrderItem> OrderItems { get; set; } = [];
}
