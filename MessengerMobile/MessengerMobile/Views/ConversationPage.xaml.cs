using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessengerMobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MessengerMobile.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class ConversationPage : ContentPage
{
    public ConversationPage(ConversationViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}