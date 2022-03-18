using System;
using MessengerMobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MessengerMobile.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class ConversationListPage : ContentPage
{
    public ConversationListPage()
    {
        InitializeComponent();
    }

    private void OnConversationTapped(object sender, EventArgs e)
    {
        if (e is not TappedEventArgs {Parameter: ConversationViewModel viewModel}) return;
        var conversationPage = new ConversationPage(viewModel);
        (Application.Current.MainPage as NavigationPage)?.PushAsync(conversationPage);
    }
} 