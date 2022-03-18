using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MessengerMobile.Models;

namespace MessengerMobile.ViewModels;

internal class ConversationListViewModel : BaseViewModel
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
            Conversations.Add(new ConversationViewModel(conversationModel));
    }

    private async void StartLoadingConversations()
    {
        await LoadConversations();
    }

    #endregion
}