namespace AliBazar.Application.ViewModels
{
    public class OrderCreteDTO
    {
        public required long UserId { get; set; }
        public decimal? TotalAmount { get; set; }
        public string? Status { get; set; }
    }
}
