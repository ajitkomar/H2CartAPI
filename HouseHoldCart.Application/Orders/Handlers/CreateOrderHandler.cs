using MediatR;
using HouseHoldCart.Application.Orders.Commands;
using HouseHoldCart.Models.Order;

namespace HouseHoldCart.Application.Orders.Handlers
{
    public class CreateOrderHandler(AppDbContext context) : IRequestHandler<CreateOrderCommand, Order>
    {
        private readonly AppDbContext _context = context;

        public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            _context.Orders.Add(request.Order);
            await _context.SaveChangesAsync(cancellationToken);
            return request.Order;
        }
    }
}
