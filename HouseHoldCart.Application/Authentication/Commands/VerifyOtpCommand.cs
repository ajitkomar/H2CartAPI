namespace HouseHoldCart.Application.Authentication.Commands
{
    public class VerifyOtpCommand
    {
        public string MobileNumber { get; set; }
        public string Otp { get; set; }
    }
}
