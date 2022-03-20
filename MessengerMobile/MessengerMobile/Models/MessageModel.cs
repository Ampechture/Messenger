using System;
using MessengerCommon.Interfaces;

namespace MessengerMobile.Models;

public abstract class MessageModel : IGuided
{
    public Guid ConversationGuid { get; set; }
    
    public string Text { get; set; }
    
    public Guid Guid { get; set; }
    
    public UserModel Sender { get; set; }
}