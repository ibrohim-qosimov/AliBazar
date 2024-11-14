namespace AliBazar.Domain.Entities;

public class Category
{
    public long Id { get; set; }
    public required string NameUz { get; set; }
    public required string NameRuss { get; set; }
    public string? ImageUrl { get; set; }
}
