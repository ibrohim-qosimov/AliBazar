using System.Text.Json.Serialization;

namespace AliBazar.Domain.Entities;
public class ProductDetail
{
    public long Id { get; set; }
    public int ThisWeekPurchases { get; set; }
    public int StockCount { get; set; }

    public ICollection<ProductColor> ProductColors { get; set; } = new List<ProductColor>();
    public ICollection<ProductSize> ProductSizes { get; set; } = new List<ProductSize>();

    [JsonIgnore]
    public long ProductId { get; set; }

    [JsonIgnore]
    public Product Product { get; set; } = null!;

}
