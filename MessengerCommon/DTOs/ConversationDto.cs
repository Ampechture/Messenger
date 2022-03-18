﻿using MessengerCommon.Interfaces;

namespace MessengerCommon.DTOs;

public class ConversationDto : IGuided
{
    public Guid Guid { get; set; }
    
    public List<UserDto> Participants { get; set; }
    
    public string Name { get; set; }
}