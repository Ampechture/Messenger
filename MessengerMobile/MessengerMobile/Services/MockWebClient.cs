using System;
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

        return new UserDto()
        {
            Guid = DataStore.Instance.DebugUserGuid,
            PhoneNumber = signUpUserDto.PhoneNumber
        };
    }

    #region PrivatePart

    private const int RequestSimulatedDelayMs = 100;

    #endregion
}