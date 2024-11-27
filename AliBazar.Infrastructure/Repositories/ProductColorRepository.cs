using AliBazar.Application.Abstractions;
using AliBazar.Domain.Entities;
using AliBazar.Infrastructure.Persistance;

namespace AliBazar.Infrastructure.Repositories;
public class ProductColorRepository : BaseRepository<ProductColor>, IProductColorRepository
{
    public ProductColorRepository(AliBazarDbContext context) : base(context)
    {
    }
}
