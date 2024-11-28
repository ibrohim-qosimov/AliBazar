using AliBazar.Domain.DTOs;
using AliBazar.Domain.Entities;
using AliBazar.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliBazar.Application.Services.ProductColorServices
{
    public interface IProductColorService
    {
        public Task<ResponseModel> CreateProductColor(ProductColorDTO color);
        public Task<bool> DeleteProductColor(int id);
        public Task<ResponseModel> UpdateProducColor(int id , ProductColorDTO color);
        public Task<IEnumerable<ProductColor>> GetAllProductColor();
        public Task<ProductColor> GetProductColorById(int id);
    }
}
