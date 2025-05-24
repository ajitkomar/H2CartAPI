namespace HouseHoldCart.Models.Authentication
{
    public class User
    {
        public int Id { get; set; }
        public string MobileNumber { get; set; } = null!;
        public string? Name { get; set; }
        public bool IsSeller { get; set; } = false;
        public ICollection<RefreshToken> RefreshTokens { get; set; } = [];
    }
}
