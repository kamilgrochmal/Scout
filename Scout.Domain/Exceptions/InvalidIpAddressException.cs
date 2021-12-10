using Scout.Shared.Abstractions.Exceptions;

namespace Scout.Domain.Exceptions;

public class InvalidIpAddressException : ScoutException
{
    public string IpAddress { get; }

    public InvalidIpAddressException(string ipAddress) : base($"Provided Ip Address: {ipAddress} in not valid.")
    {
        IpAddress = ipAddress;
    }
}