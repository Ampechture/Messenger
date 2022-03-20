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
        if (userGuid != DataStore.Instance.DebugUserGuid)
            throw new Exception("User was not found");
        
        var user = DataStore.Instance.User;
        var interlocutor = new UserDto
        {
            Guid = _interlocutorGuid,
            Name = new Name { FirstName = "Denis" }
        };

        return new List<ConversationDto>
        {
            new()
            {
                Guid = _conversationGuid,
                Name = $"{user.Name.FullName}, {interlocutor.Name.FullName}",
                Participants = new List<UserDto>
                {
                    user.ToDto(),
                    interlocutor
                },
                LastMessage = new MessageDto
                {
                    Guid = Guid.Parse("C3012820-3BAC-4A3A-9F9C-171C7D00D121"),
                    Text = "ну привет",
                    ConversationGuid = _conversationGuid,
                    SenderGuid = DataStore.Instance.DebugUserGuid
                },
                UnreadCount = 0
            }
        };
    }

    public async Task<List<MessageDto>> GetMessages(Guid conversationGuid)
    {
        await Task.Delay(RequestSimulatedDelayMs);
        if (conversationGuid == _conversationGuid)
        {
            return new List<MessageDto>
            {
                new()
                {
                    Guid = Guid.Parse("05A2BABC-91BD-49F1-92F1-3464F24C8C39"),
                    Text = "Привет!",
                    ConversationGuid = _conversationGuid,
                    SenderGuid = DataStore.Instance.DebugUserGuid
                },
                new()
                {
                    Guid = Guid.Parse("C3012820-3BAC-4A3A-9F9C-171C7D00D121"),
                    Text = "ну привет",
                    ConversationGuid = _conversationGuid,
                    SenderGuid = DataStore.Instance.DebugUserGuid
                }
            };
        }

        throw new Exception("Conversation was not found");
    }

    #region PrivatePart

    private const int RequestSimulatedDelayMs = 200;
    
    private readonly Guid _conversationGuid = Guid.Parse("9CDD4857-2433-48F7-AC35-E8CBCFF0E8AA");
    private readonly Guid _interlocutorGuid = Guid.Parse("2D03357D-1D99-4C70-90E7-BA547589B5CA");

    #endregion
}