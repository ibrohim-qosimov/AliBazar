using AliBazar.Application.ViewModels;
using AliBazar.Domain.Entities;
using AliBazar.Domain.ViewModels;

namespace AliBazar.Application.Services.OrderServices
{
    public interface IOrderService
    {
        public Task<ResponseModel> CreateOrder(OrderCreteDTO orderDTO);
        public Task<ResponseModel> UpdateOrderById(long id, OrderUpdateDTO orderDTO);
        public Task<bool> DeleteOrderById(long id);
        public Task<Order> GetOrderById(long id);
        public Task<IEnumerable<Order>> GetAllOrders();
    }
}
