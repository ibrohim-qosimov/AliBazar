using AliBazar.Application.Abstractions;
using AliBazar.Domain.Entities;
using AliBazar.Infrastructure.Persistance;

namespace AliBazar.Infrastructure.Repositories
{
    public class CateogryRepository : BaseRepository<Category>, ICateogryRepository
    {
        public CateogryRepository(AliBazarDbContext context)
            : base(context)
        {
        }
    }
}
