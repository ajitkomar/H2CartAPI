using HouseHoldCart.DataAccess.Interfaces;
using HouseHoldCart.Models.HouseHoldItems;

namespace HouseHoldCart.DataAccess.HouseHoldItems
{
    internal class HouseHoldItemDataAccess(AppDbContext _context) : CrudOperation<HouseHoldItem>(_context), IHouseHoldItemDataAccess
    {
        
    }
}
