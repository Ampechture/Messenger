namespace MessengerCommon.DTOs;

public class UserDto
{
    public Guid Guid { get; set; }
        
    public PhoneNumber PhoneNumber { get; set; }
    
    public Name Name { get; set; }
}