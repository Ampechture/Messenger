using MessengerCommon.Interfaces;

namespace MessengerCommon.DTOs;

public class UserDto : IGuided
{
    public Guid Guid { get; set; }
        
    public PhoneNumber PhoneNumber { get; set; }
    
    public Name Name { get; set; }
}