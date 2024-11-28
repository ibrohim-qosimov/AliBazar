using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliBazar.Domain.Entities
{
    public class Admin
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public required string PhoneNumber { get; set; }
    }
}
