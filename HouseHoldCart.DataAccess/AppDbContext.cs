using Microsoft.EntityFrameworkCore;
using HouseHoldCart.Models.HouseHoldItems;
using HouseHoldCart.Models.Order;
using HouseHoldCart.Models.Logistics;
using HouseHoldCart.Models.Authentication;

namespace HouseHoldCart.DataAccess
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<HouseHoldItem> HouseHoldItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<LogisticsInfo> LogisticsInfos { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OtpCode> OtpCodes { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}
