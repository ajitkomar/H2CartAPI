using Microsoft.EntityFrameworkCore;
using HouseHoldCart.Models.HouseHoldItems;
using HouseHoldCart.Models.Order;
using HouseHoldCart.Models.Logistics;

namespace HouseHoldCart
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<HouseHoldItem> HouseholdItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<LogisticsInfo> LogisticsInfos { get; set; }
    }
}
