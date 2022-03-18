using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MessengerCommon;
using MessengerCommon.DTOs;

namespace MessengerMobile.Services;

internal class MockWebClient : IWebClient
{
    public async Task<bool> IsPhoneNumberAlreadyUsed(PhoneNumber number)
    {
        await Task.Delay(RequestSimulatedDelayMs);
        return number.ToString().EndsWith("81");
    }

    public async Task<UserDto> SignUpUser(SignUpNewUserDto signUpUserDto)
    {
        var isPhoneNumberAlreadyUsed = await IsPhoneNumberAlreadyUsed(signUpUserDto.PhoneNumber);
        if (isPhoneNumberAlreadyUsed)
            throw new Exception("Number already used");

        return new UserDto
        {
            Guid = DataStore.Instance.DebugUserGuid,
            PhoneNumber = signUpUserDto.PhoneNumber,
            Name = new Name
            {
                FirstName = "Valera"
            }
        };
    }

    public async Task<List<ConversationDto>> GetConversations(Guid userGuid)
    {
        await Task.Delay(RequestSimulatedDelayMs);
        if (userGuid != DataStore.Instance.DebugUserGuid) return null;
        
        var user = DataStore.Instance.User;
        var interlocutor = new UserDto
        {
            Guid = Guid.Parse("2D03357D-1D99-4C70-90E7-BA547589B5CA"),
            Name = new Name { FirstName = "Denis" }
        };

        return new List<ConversationDto>
        {
            new()
            {
                Guid = Guid.Parse("9CDD4857-2433-48F7-AC35-E8CBCFF0E8AA"),
                Name = $"{user.Name.FullName}, {interlocutor.Name.FullName}",
                Participants = new List<UserDto>
                {
                    user.ToDto(),
                    interlocutor
                }
            }
        };
    }

    #region PrivatePart

    private const int RequestSimulatedDelayMs = 200;

    #endregion
}