using AliBazar.Application.Abstractions;
using AliBazar.Domain.Entities;
using AliBazar.Infrastructure.Persistance;

namespace AliBazar.Infrastructure.Repositories
{
    public class ProductDetailRepository : BaseRepository<ProductDetail>, IProductDetailRepository
    {
        public ProductDetailRepository(AliBazarDbContext context) : base(context)
        {
        }
    }
}
