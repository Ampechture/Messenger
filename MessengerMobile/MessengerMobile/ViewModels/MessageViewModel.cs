using MessengerMobile.Models;
using MessengerMobile.Services;

namespace MessengerMobile.ViewModels;

public class MessageViewModel : BaseViewModel
{
    public MessageViewModel(MessageModel model)
    {
        Model = model;
    }
    
    public string Text => Model.Text;

    public string SenderName => !IsIncoming
        ? "Вы"
        : Model.Sender.Name.FullName;


    public string HorizontalOption => IsIncoming ? "Start" : "End";

    #region PrivatePart

    private MessageModel Model { get; }

    private bool IsIncoming => Model.Sender.Guid != DataStore.Instance.User.Guid;

    #endregion
}