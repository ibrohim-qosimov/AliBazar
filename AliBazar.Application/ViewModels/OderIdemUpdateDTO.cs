namespace AliBazar.Application.ViewModels
{
    public class OderIdemUpdateDTO
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public long Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
