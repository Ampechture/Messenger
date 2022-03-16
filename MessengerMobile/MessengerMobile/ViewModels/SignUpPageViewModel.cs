namespace MessengerMobile.ViewModels
{
    public class SignUpPageViewModel : BaseViewModel
    {
        private string _enteredPhoneNumber;

        public string EnteredPhoneNumber
        {
            get => _enteredPhoneNumber;
            set
            {
                if (_enteredPhoneNumber == value) return;
                _enteredPhoneNumber = value;
                OnPropertyChanged();
            }
        }
    }
}