namespace AliBazar.Domain.Entities;

public class Category
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public string? ImageUrl {  get; set; }
}
