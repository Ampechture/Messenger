using System.Threading.Tasks;
using MessengerCommon;
using MessengerCommon.DTOs;
using MessengerMobile.Services;

namespace MessengerMobile.Models
{
    internal class SignUpPageModel
    {
        public PhoneNumber ValidatePhoneNumber(string phoneNumber)
        {
            return PhoneNumber.IsStringPhoneNumber(phoneNumber)
                ? new PhoneNumber(phoneNumber)
                : null;
        }

        public async Task<bool> IsPhoneNumberAlreadyUsed(PhoneNumber phoneNumber)
        {
            return await DataStore.Instance.WebClient.IsPhoneNumberAlreadyUsed(phoneNumber);
        }
        
        public async Task<bool> TrySignUpWithNumber(PhoneNumber phoneNumber)
        {
            await DataStore.Instance.WebClient.SignUpUser(new SignUpNewUserDto { PhoneNumber = phoneNumber });
            DataStore.Instance.UserGuid = DataStore.Instance.DebugUserGuid;
            return true;
        }
    }
}