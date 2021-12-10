using Scout.Shared.Abstractions.Exceptions;

namespace Scout.Application.Common.Exceptions;
public class NotFoundException : ScoutException
{
    public NotFoundException(string message) : base(message)
    {
    }
}