namespace HouseHoldCart.Application.Authentication.Interfaces
{
    public interface IOtpService
    {
        Task<string> GenerateOtpAsync(string mobileNumber);
        Task<bool> ValidateOtpAsync(string mobileNumber, string otp);
    }
}
