using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliBazar.Application.ViewModels
{
    public class ProductDetailDTO
    {
        public int ThisWeekPurchases { get; set; }
        public int StockCount { get; set; }
        public long ProductId { get; set; }
    }
}
