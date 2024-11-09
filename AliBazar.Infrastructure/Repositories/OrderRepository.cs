using AliBazar.Application.Abstractions;
using AliBazar.Domain.Entities;
using AliBazar.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliBazar.Infrastructure.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(AliBazarDbContext context) : base(context)
        {
        }
    }
}
