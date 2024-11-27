namespace AliBazar.Domain.Entities;

public class User
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Password { get; set; }
    public string Salt { get; set; }
    public string? ImageUrl { get; set; }
    public List<Order>? OrderHistory { get; set; } = []; // crud da tegilmaydi
    public required string Role { get; set; }
}
