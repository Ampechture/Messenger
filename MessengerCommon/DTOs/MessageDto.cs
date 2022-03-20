using MessengerCommon.Interfaces;

namespace MessengerCommon.DTOs;

public class MessageDto : IGuided
{
    public Guid SenderGuid { get; set; }
    
    public Guid ConversationGuid { get; set; }
    
    public string Text { get; set; }
    
    public Guid Guid { get; set; }
}