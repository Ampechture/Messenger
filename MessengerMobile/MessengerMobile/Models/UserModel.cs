using System;
using MessengerCommon;
using MessengerCommon.DTOs;
using MessengerCommon.Interfaces;

namespace MessengerMobile.Models;

public class UserModel : IGuided
{
    public UserModel(UserDto dto)
    {
        Guid = dto.Guid;
        PhoneNumber = dto.PhoneNumber;
        Name = dto.Name;
    }
    
    public Guid Guid { get; set; }
        
    public PhoneNumber PhoneNumber { get; set; }
    
    public Name Name { get; set; }

    public UserDto ToDto()
    {
        return new UserDto
        {
            Guid = Guid,
            Name = Name,
            PhoneNumber = PhoneNumber
        };
    }
}