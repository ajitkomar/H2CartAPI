using HouseHoldCart.Application.Authentication.Interfaces;
using HouseHoldCart.DataAccess.Interfaces;
using HouseHoldCart.Models.Authentication;

namespace HouseHoldCart.Application.Authentication
{
    public class OtpService(IOtpCodesDataAccess _otpCodesDataAccess) : IOtpService
    {
        private readonly TimeSpan _otpValidity = TimeSpan.FromMinutes(2);

        public async Task<string> GenerateOtpAsync(string mobileNumber)
        {
            var otp = new Random().Next(100000, 999999).ToString();

            var otpEntry = new OtpCode
            {
                MobileNumber = mobileNumber,
                Code = otp,
                ExpirationTime = DateTime.UtcNow.Add(_otpValidity),
                IsUsed = false
            };

            await _otpCodesDataAccess.CreateAsync(otpEntry);
            return otp;
        }

        public async Task<bool> ValidateOtpAsync(string mobileNumber, string otp)
        {
            var otpCodes = await _otpCodesDataAccess.SearchAsync("");

            var otpEntry = otpCodes?
                .Where(x => x.MobileNumber == mobileNumber && x.Code == otp && !x.IsUsed && x.ExpirationTime > DateTime.UtcNow)
                .FirstOrDefault();

            if (otpEntry == null)
                return false;

            otpEntry.IsUsed = true;

            await _otpCodesDataAccess.UpdateAsync(otpEntry);
            return true;
        }
    }
}
