namespace AliBazar.Domain.Entities
{
    public class Order
    {
        public long Id { get; set; }
        public required long UserId { get; set; }
        public DateTimeOffset? OrderDate { get; set; } = DateTimeOffset.UtcNow;
        public decimal? TotalAmount { get; set; }
        public string? Status { get; set; }

        // Order bilan bog'liq OrderItem ro'yxati
        public List<OrderItem> OrderItems { get; set; } = [];
    }
}
