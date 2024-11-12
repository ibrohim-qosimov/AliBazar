using AliBazar.Application.Abstractions;
using AliBazar.Application.ViewModels;
using AliBazar.Domain.Entities;
using AliBazar.Domain.ViewModels;

namespace AliBazar.Application.Services.OrderServices
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<ResponseModel> CreateOrder(OrderCreteDTO orderDTO)
        {
            var order = new Order()
            {
                TotalAmount = orderDTO.TotalAmount,
                Status = orderDTO.Status,
                UserId = orderDTO.UserId
            };

            var result = await _orderRepository.Create(order);

            if (result == null)
            {
                return new ResponseModel()
                {
                    Note = "Exception while saving order.",
                    IsSuccess = false
                };
            }

            return new ResponseModel()
            {
                Note = "Category created successfully!",
                IsSuccess = true
            };
        }

        public async Task<bool> DeleteOrderById(long id)
        {
            var result = await _orderRepository.Delete(x => x.Id == id);
            return result;
        }

        public Task<IEnumerable<Order>> GetAllOrders()
        {
            return _orderRepository.GetAll();
        }

        public async Task<Order> GetOrderById(long id)
        {
            var result = await _orderRepository.GetByAny(x => x.Id == id);
            return result;
        }

        public async Task<ResponseModel> UpdateOrderById(long id, OrderUpdateDTO orderDTO)
        {
            var order = await _orderRepository.GetByAny(x => x.Id == id);

            if (order == null)
            {

                return new ResponseModel()
                {
                    IsSuccess = false,
                    Note = "Order not found!"
                };
            }

            order.Id = id;
            order.Status = orderDTO.Status;

            var result = await _orderRepository.Update(order);

            return new ResponseModel()
            {
                IsSuccess = true,
                Note = "Order updated successfuly!"
            };
        }
    }
}
