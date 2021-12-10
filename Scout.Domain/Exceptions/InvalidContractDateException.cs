using Scout.Shared.Abstractions.Exceptions;

namespace Scout.Domain.Exceptions;

public class InvalidContractDateException : ScoutException
{
    public InvalidContractDateException(string message) : base(message)
    {
    }
}