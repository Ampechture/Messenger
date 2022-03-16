using System;
using System.Linq;
using MessengerMobile.Models;

namespace MessengerMobile.ViewModels
{
    internal class SignUpPageViewModel : BaseViewModel
    {
        public string EnteredPhoneNumber
        {
            get => _enteredPhoneNumber;
            set
            {
                if (_enteredPhoneNumber == value) return;
                _enteredPhoneNumber = value;

                StartValidatingAndSigningUp();

                OnPropertyChanged();
            }
        }

        public event Action SignedUp;

        #region PrivatePart

        private string _enteredPhoneNumber;

        private SignUpPageModel Model { get; } = new();

        private async void StartValidatingAndSigningUp()
        {
            var validatedPhoneNumber = Model.ValidatePhoneNumber(_enteredPhoneNumber);
            if (validatedPhoneNumber == null) return;

            var isPhoneAlreadyUsed = await Model.IsPhoneNumberAlreadyUsed(validatedPhoneNumber);
            if (isPhoneAlreadyUsed) return;

            var haveSignedUp = await Model.TrySignUpWithNumber(validatedPhoneNumber);
            if (haveSignedUp)
                SignedUp?.Invoke();
        }

        #endregion
    }
}