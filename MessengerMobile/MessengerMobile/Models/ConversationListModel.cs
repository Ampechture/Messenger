using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessengerMobile.Services;

namespace MessengerMobile.Models;

internal class ConversationListModel
{
    public List<ConversationModel> Conversations { get; } = new();

    public async Task LoadConversations()
    {
        Conversations.Clear();
        var conversationDtos = await DataStore.Instance.WebClient.GetConversations(DataStore.Instance.User.Guid);
        Conversations.AddRange(conversationDtos.Select(c => new ConversationModel(c)));
    }
}