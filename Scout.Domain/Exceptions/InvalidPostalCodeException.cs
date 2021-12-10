using Scout.Shared.Abstractions.Exceptions;

namespace Scout.Domain.Exceptions;

public class InvalidPostalCodeException : ScoutException
{
    public InvalidPostalCodeException() : base("Provided postal code is invalid.")
    {
    }
}