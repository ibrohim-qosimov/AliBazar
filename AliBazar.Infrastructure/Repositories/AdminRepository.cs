using AliBazar.Application.Abstractions;
using AliBazar.Domain.Entities;
using AliBazar.Infrastructure.Persistance;

namespace AliBazar.Infrastructure.Repositories
{
    public class AdminRepository : BaseRepository<Admin>, IAdminRepository
    {
        public AdminRepository(AliBazarDbContext context) : base(context)
        {
        }
    }
}
