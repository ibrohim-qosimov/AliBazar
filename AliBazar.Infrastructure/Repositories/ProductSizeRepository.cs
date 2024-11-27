using AliBazar.Application.Abstractions;
using AliBazar.Domain.Entities;
using AliBazar.Infrastructure.Persistance;

namespace AliBazar.Infrastructure.Repositories;
public class ProductSizeRepository : BaseRepository<ProductSize>, IProductSizeRepository
{
    public ProductSizeRepository(AliBazarDbContext context) : base(context)
    {
    }
}
