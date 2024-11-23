namespace AliBazar.Domain.Entities;

public class Product
{
    public long Id { get; set; }
    public required string NameUz { get; set; }
    public required string NameRuss { get; set; }
    public string? DescriptionUz { get; set; }
    public string? DescriptionRuss { get; set; }
    public required decimal Price { get; set; }
    public required long CategoryId { get; set; }
    public bool IsDeleted { get; set; } = false;
    public List<string>? ImageUrl { get; set; } = new List<string>();
    public List<OrderItem> OrderItems { get; set; } = [];
}
