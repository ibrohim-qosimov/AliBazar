using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliBazar.Domain.Entities
{
    public class ProductColor
    {
        public int Id { get; set; }
        public string Color { get; set; } // 6 talik harf bolip keladi #FFFF
    }
}
