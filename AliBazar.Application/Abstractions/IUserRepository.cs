using AliBazar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliBazar.Application.Abstractions
{
    public interface IUserRepository : IBaseRepository<User>
    {
    }
}
