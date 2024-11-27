namespace AliBazar.Domain.Entities;
    public class ProductColor
    {
    public long Id { get; set; }
    public string Color { get; set; }

    public long ProductDetailId { get; set; }
    public ProductDetail ProductDetail { get; set; }
}
