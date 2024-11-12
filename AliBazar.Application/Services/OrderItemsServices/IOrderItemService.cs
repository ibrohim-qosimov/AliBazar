using AliBazar.Application.ViewModels;
using AliBazar.Domain.Entities;
using AliBazar.Domain.ViewModels;

namespace AliBazar.Application.Services.OrderItemsServices
{
    public interface IOrderItemService
    {
        public Task<ResponseModel> CreateOrderItem(OderIdemCreateDTO orderDTO);
        public Task<ResponseModel> UpdateOrderItemById(long id, OderIdemUpdateDTO orderDTO);
        public Task<bool> DeleteOrderItemById(long id);
        public Task<OrderItem> GetOrderItemById(long id);
        public Task<IEnumerable<OrderItem>> GetAllOrderItems();
    }
}
