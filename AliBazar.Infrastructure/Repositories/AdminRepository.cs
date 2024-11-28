using AliBazar.Domain.Entities;
using AliBazar.Infrastructure.Persistance;
using AliBazar.Application.Abstractions;

namespace AliBazar.Infrastructure.Repositories
{
    public class AdminRepository : BaseRepository<Admin>, IAdminRepository
    {
        public AdminRepository(AliBazarDbContext context) : base(context)
        {
        }
    }
}
