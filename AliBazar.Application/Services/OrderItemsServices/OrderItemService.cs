using AliBazar.Application.Abstractions;
using AliBazar.Application.ViewModels;
using AliBazar.Domain.Entities;
using AliBazar.Domain.ViewModels;

namespace AliBazar.Application.Services.OrderItemsServices
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public OrderItemService(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public async Task<ResponseModel> CreateOrderItem(OderIdemCreateDTO orderDTO)
        {
            var orderItem = new OrderItem()
            {
                OrderId = orderDTO.OrderId,
                Price = orderDTO.Price,
                ProductId = orderDTO.ProductId,
                Quantity = orderDTO.Quantity,
            };

            var result = await _orderItemRepository.Create(orderItem);

            if (result == null)
            {
                return new ResponseModel()
                {
                    Note = "Exception while saving order item.",
                    IsSuccess = false
                };
            }

            return new ResponseModel()
            {
                Note = "Order item created successfully!",
                IsSuccess = true
            };
        }

        public async Task<bool> DeleteOrderItemById(long id)
        {
            var result = await _orderItemRepository.Delete(x => x.Id == id);
            return result;
        }

        public Task<IEnumerable<OrderItem>> GetAllOrderItems()
        {
            return _orderItemRepository.GetAll();
        }

        public Task<OrderItem> GetOrderItemById(long id)
        {
            return _orderItemRepository.GetByAny(x => x.Id == id);
        }

        public async Task<ResponseModel> UpdateOrderItemById(long id, OderIdemUpdateDTO orderDTO)
        {
            var orderItem = await _orderItemRepository.GetByAny(x => x.Id == id);

            if (orderItem == null)
            {

                return new ResponseModel()
                {
                    IsSuccess = false,
                    Note = "Order not found!"
                };
            }

            orderItem.Id = id;
            orderItem.Price = orderDTO.Price;
            orderItem.OrderId = orderDTO.OrderId;
            orderItem.ProductId = orderDTO.ProductId;
            orderItem.Quantity = orderDTO.Quantity;

            var result = await _orderItemRepository.Update(orderItem);

            return new ResponseModel()
            {
                IsSuccess = true,
                Note = "Order Item updated successfuly!"
            };
        }
    }
}
