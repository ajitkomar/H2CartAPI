using MediatR;
using HouseHoldCart.Application.Orders.Commands;
using HouseHoldCart.Models.Order;
using HouseHoldCart.DataAccess.Interfaces;

namespace HouseHoldCart.Application.Orders.Handlers
{
    public class CreateOrderHandler(IOrderDataAccess _orderDataAccess) : IRequestHandler<CreateOrderCommand, Order>
    {
        public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            return await _orderDataAccess.CreateAsync(request.Order);    
        }
    }
}
