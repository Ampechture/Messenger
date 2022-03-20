using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MessengerMobile.Models;

namespace MessengerMobile.ViewModels;

public class ConversationListViewModel : BaseViewModel
{
    public ConversationListViewModel()
    {
        StartLoadingConversations();
    }
    
    public ObservableCollection<ConversationViewModel> Conversations { get; } = new();

    #region PrivatePart

    private ConversationListModel Model { get; } = new();

    private async Task LoadConversations()
    {
        await Model.LoadConversations();
        
        Conversations.Clear();
        foreach (var conversationModel in Model.Conversations)
        {
            var conversationViewModel = new ConversationViewModel();
            conversationViewModel.Initialize(conversationModel);
            Conversations.Add(conversationViewModel);
        }
    }

    private async void StartLoadingConversations()
    {
        await LoadConversations();
    }

    #endregion
}