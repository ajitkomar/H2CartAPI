namespace HouseHoldCart.Models.Authentication
{
    public class OtpCode
    {
        public int Id { get; set; }
        public string MobileNumber { get; set; } = null!;
        public string Code { get; set; } = null!;
        public DateTime ExpirationTime { get; set; }
        public bool IsUsed { get; set; } = false;
    }
}
