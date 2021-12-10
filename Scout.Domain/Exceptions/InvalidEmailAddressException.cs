using Scout.Shared.Abstractions.Exceptions;

namespace Scout.Domain.Exceptions;

public class InvalidEmailAddressException : ScoutException
{
    public InvalidEmailAddressException() : base("Provided email address is invalid.")
    {
    }
}