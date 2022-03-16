using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace MessengerCommon;

[DataContract]
public class PhoneNumber
{
    public PhoneNumber(string phoneNumber)
    {
        if (!IsStringPhoneNumber(phoneNumber))
            throw new ArgumentException("String is not a valid number");
        _phoneNumber = phoneNumber;
    }

    public static bool IsStringPhoneNumber(string phoneNumber) => PhoneNumberRegex.IsMatch(phoneNumber);

    public override string ToString() => _phoneNumber;

    #region PrivatePart

    [DataMember]
    private readonly string _phoneNumber;
        
    private static readonly Regex PhoneNumberRegex = new Regex(@"^\+\d\d\d\d\d\d\d\d\d\d\d$");  // TODO: Refactor

    #endregion
}