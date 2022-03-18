namespace MessengerCommon;

public class Name
{
    public string FirstName { get; set; }
    
    public string LastName { get; set; }

    public string FullName => string.IsNullOrWhiteSpace(LastName)
        ? FirstName
        : $"{FirstName} {LastName}";
}