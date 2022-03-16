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
            var signUpNewUserDto = new SignUpNewUserDto
            {
                PhoneNumber = phoneNumber,
                Name = new Name
                {
                    FirstName = "Jonn",
                    LastName = "Doe"
                }
            };
            await DataStore.Instance.WebClient.SignUpUser(signUpNewUserDto);
            DataStore.Instance.UserGuid = DataStore.Instance.DebugUserGuid;
            return true;
        }
    }
}