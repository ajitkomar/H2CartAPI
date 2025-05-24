using MediatR;
using HouseHoldCart.Models.Order;

namespace HouseHoldCart.Application.Orders.Commands
{
    public class CreateOrderCommand(Order order) : IRequest<Order>
    {
        public Order Order { get; set; } = order;
    }
}
