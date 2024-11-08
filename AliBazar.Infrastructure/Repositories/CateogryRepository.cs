using AliBazar.Application.Abstractions;
using AliBazar.Application.Services.CategoryServices;
using AliBazar.Domain.Entities;
using AliBazar.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
