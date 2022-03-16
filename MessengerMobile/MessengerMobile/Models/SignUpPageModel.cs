using System;
using System.Text.RegularExpressions;
using MessengerMobile.Services;

namespace MessengerMobile.Models
{
    internal class SignUpPageModel
    {
        private static readonly Regex PhoneNumberRegex = new Regex(@"^\+\d\d\d\d\d\d\d\d\d\d\d$");  // TODO: Refactor

        public bool ValidatePhoneNumber(string enteredPhoneNumber)
        {
            return PhoneNumberRegex.IsMatch(enteredPhoneNumber);
        }

        public bool TrySignUpWithNumber(string enteredPhoneNumber)
        {
            if (!enteredPhoneNumber.EndsWith("81")) return false;
            
            DataStore.Instance.UserGuid = DataStore.Instance.DebugUserGuid;
            return true;
        }
    }
}