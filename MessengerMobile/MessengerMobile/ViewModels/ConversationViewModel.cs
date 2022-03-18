using MessengerMobile.Models;

namespace MessengerMobile.ViewModels;

public class ConversationViewModel : BaseViewModel
{
    public ConversationViewModel(ConversationModel model)
    {
        Model = model;
    }

    public string Name => Model.Name;

    #region PrivatePart

    private ConversationModel Model { get; }

    #endregion
}