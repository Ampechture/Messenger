using System;
using System.Linq;
using MessengerMobile.Models;

namespace MessengerMobile.ViewModels
{
    internal class SignUpPageViewModel : BaseViewModel
    {
        public bool HaveError => !string.IsNullOrEmpty(ErrorString);
        public string ErrorString
        {
            get => _errorString;
            set
            {
                if (_errorString == value) return;
                _errorString = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(HaveError));
            }
        }
            

        public string EnteredPhoneNumber
        {
            get => _enteredPhoneNumber;
            set
            {
                if (_enteredPhoneNumber == value) return;
                _enteredPhoneNumber = value;

                StartValidatingAndSigningUp();

                OnPropertyChanged();
                OnPropertyChanged(nameof(HaveError));
            }
        }

        public event Action SignedUp;

        #region PrivatePart

        private string _enteredPhoneNumber;
        private string _errorString;

        private SignUpPageModel Model { get; } = new();

        private async void StartValidatingAndSigningUp()
        {
            var validatedPhoneNumber = Model.ValidatePhoneNumber(_enteredPhoneNumber);
            if (validatedPhoneNumber == null)
            {
                ErrorString = "Это не телефонный номер";
                return;
            }

            var isPhoneAlreadyUsed = await Model.IsPhoneNumberAlreadyUsed(validatedPhoneNumber);
            if (isPhoneAlreadyUsed)
            {
                ErrorString = "Этот номер уже существует";
                return;
            }

            var haveSignedUp = await Model.TrySignUpWithNumber(validatedPhoneNumber);
            if (haveSignedUp)
            {
                ErrorString = "";
                SignedUp?.Invoke();
            }
        }

        #endregion
    }
}