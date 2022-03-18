using MessengerMobile.Models;

namespace MessengerMobile.ViewModels;

internal class ConversationViewModel : BaseViewModel
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