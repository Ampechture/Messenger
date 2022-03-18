using System;
using System.Collections.Generic;
using System.Linq;
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
    }


    public Guid Guid { get; }

    public List<UserModel> Participants { get; }

    public string Name { get; }
    
    private bool IsGroup => Participants?.Count > 2;
}