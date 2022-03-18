using MessengerMobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MessengerMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
            if (BindingContext is not SignUpPageViewModel viewModel) return;
            viewModel.SignedUp += StartNavigatingToDialogList;
        }

        private async void StartNavigatingToDialogList()
        {
            if (Application.Current.MainPage is NavigationPage mainPage)
                await mainPage.PushAsync(new ConversationListPage());
        }
    }
}