using Scout.Shared.Abstractions.Exceptions;

namespace Scout.Domain.Exceptions;

public class InvalidPhoneNumberException : ScoutException
{
    public InvalidPhoneNumberException() : base("Provided phone number is invalid.")
    {
    }
}