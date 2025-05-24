using HouseHoldCart.DataAccess.Interfaces;
using HouseHoldCart.Models.HouseHoldItems;

namespace HouseHoldCart.DataAccess.Orders
{
    public class OrderDataAccess(AppDbContext _context) : CrudOperation<HouseHoldItem>(_context), IOrderDataAccess
    {
       
    }
}
