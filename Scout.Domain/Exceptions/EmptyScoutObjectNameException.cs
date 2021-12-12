using Scout.Shared.Abstractions.Exceptions;

namespace Scout.Domain.Exceptions;

public class EmptyScoutObjectNameException : ScoutException
{
    public EmptyScoutObjectNameException() : base($"ScoutObject name can not be empty.")
    {
    }
}