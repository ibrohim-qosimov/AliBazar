namespace AliBazar.Domain.Entities
{
    public class Admin
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public required string PhoneNumber { get; set; }
    }
}
