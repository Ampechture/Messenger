using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MessengerCommon;
using MessengerCommon.DTOs;

namespace MessengerMobile.Services;

internal interface IWebClient
{
    public Task<bool> IsPhoneNumberAlreadyUsed(PhoneNumber number);
    
    public Task<UserDto> SignUpUser(SignUpNewUserDto signUpUserDto);

    public Task<List<ConversationDto>> GetConversations(Guid userGuid);
}