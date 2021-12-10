using Scout.Shared.Abstractions.Exceptions;

namespace Scout.Domain.Exceptions;

public class InvalidCoordinatesException : ScoutException
{
    public InvalidCoordinatesException() : base("Provided coordinates are invalid.")
    {
        
    }
}