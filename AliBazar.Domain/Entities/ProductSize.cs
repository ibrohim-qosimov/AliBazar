namespace AliBazar.Domain.Entities;
public class ProductSize
{
    public long Id { get; set; }
    public string Size { get; set; }
    public long ProductDetailId { get; set; }
    public ProductDetail ProductDetail { get; set; }
}
