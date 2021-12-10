using Scout.Shared.Abstractions.Exceptions;

namespace Scout.Domain.Exceptions;

public class ValorizationException : ScoutException
{
    public ValorizationException(string message) : base(message)
    {
    }
}