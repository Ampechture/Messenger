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
                
                if (Model.ValidatePhoneNumber(_enteredPhoneNumber))
                {
                    if (Model.TrySignUpWithNumber(_enteredPhoneNumber))
                        SignedUp?.Invoke();
                }

                OnPropertyChanged();
            }
        }

        public event Action SignedUp;

        #region PrivatePart

        private string _enteredPhoneNumber;

        private SignUpPageModel Model { get; } = new();

        #endregion
    }
}