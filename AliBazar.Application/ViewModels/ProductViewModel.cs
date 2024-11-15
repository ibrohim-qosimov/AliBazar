using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliBazar.Application.ViewModels
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public string? ImageUrl { get; set; }

    }
}
