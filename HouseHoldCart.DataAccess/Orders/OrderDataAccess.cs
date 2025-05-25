using HouseHoldCart.DataAccess.Interfaces;
using HouseHoldCart.Models.Order;

namespace HouseHoldCart.DataAccess.Orders
{
    public class OrderDataAccess(AppDbContext _context) : CrudOperation<Order>(_context), IOrderDataAccess
    {
       
    }
}
