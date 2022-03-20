using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessengerCommon.DTOs;
using MessengerCommon.Interfaces;
using MessengerMobile.Services;

namespace MessengerMobile.Models;

public class ConversationModel : IGuided
{
    public ConversationModel(ConversationDto dto)
    {
        Guid = dto.Guid;
        Participants = dto.Participants.Select(p => new UserModel(p)).ToList();
        Name = IsGroup
            ? dto.Name
            : Participants.FirstOrDefault(p => p.Guid != DataStore.Instance.User.Guid)?.Name.FullName
              ?? "No name";
        LastMessage = new ProceededMessageModel(dto.LastMessage, Participants);
        UnreadCount = dto.UnreadCount;
    }


    public Guid Guid { get; }

    public List<UserModel> Participants { get; }

    public string Name { get; }

    public MessageModel LastMessage { get; set; }
    
    public int UnreadCount { get; set; }

    private bool IsGroup => Participants?.Count > 2;

    public async Task<List<MessageModel>> LoadMessages()
    {
        var dtos = await DataStore.Instance.WebClient.GetMessages(Guid);
        return dtos.Select(d => new ProceededMessageModel(d, Participants) as MessageModel).ToList();
    }
}