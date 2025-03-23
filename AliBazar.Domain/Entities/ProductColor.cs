namespace AliBazar.Domain.Entities;
public class ProductColor
{
    public long Id { get; set; }
    public string ColorUz { get; set; }
    public string ColorRu { get; set; }

    public long ProductDetailId { get; set; }
    public ProductDetail ProductDetail { get; set; }
}
