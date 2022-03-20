using System.Collections.Generic;
using System.Linq;
using MessengerCommon.DTOs;

namespace MessengerMobile.Models;

public class ProceededMessageModel : MessageModel
{
    public ProceededMessageModel(MessageDto dto, List<UserModel> possibleSenders)
    {
        Guid = dto.Guid;
        Text = dto.Text;
        ConversationGuid = dto.ConversationGuid;
        Sender = possibleSenders.FirstOrDefault(u => u.Guid == dto.SenderGuid);
    }
}