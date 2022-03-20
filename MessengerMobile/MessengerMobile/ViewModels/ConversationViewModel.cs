using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MessengerMobile.Models;

namespace MessengerMobile.ViewModels;

public class ConversationViewModel : BaseViewModel
{
    public void Initialize(ConversationModel model)
    {
        Model = model;
    }

    public async Task LoadMessages()
    {
        var messages = await Model.LoadMessages();
        Messages.Clear();
        foreach (var message in messages)
        {
            Messages.Add(new MessageViewModel(message));
        }

        AreMessagesLoaded = true;
    }

    public string Name => Model?.Name;

    public ObservableCollection<MessageViewModel> Messages { get; } = new();
    
    public bool AreMessagesLoaded { get; private set; }

    #region PrivatePart

    private ConversationModel Model { get; set; }

    #endregion
}