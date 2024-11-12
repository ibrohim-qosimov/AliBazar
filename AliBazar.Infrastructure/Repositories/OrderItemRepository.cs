using AliBazar.Application.Abstractions;
using AliBazar.Domain.Entities;
using AliBazar.Infrastructure.Persistance;

namespace AliBazar.Infrastructure.Repositories
{
    public class OrderItemRepository : BaseRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(AliBazarDbContext context) : base(context)
        {
        }
    }
}
