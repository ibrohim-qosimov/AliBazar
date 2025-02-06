using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliBazar.Domain.DTOs
{
    public class ProductColorDTO
    {
        public string ColorUz { get; set; }
        public string ColorRu { get; set; }

        public long ProductDetailId { get; set; }
    }
}
