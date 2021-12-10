using System.Text.RegularExpressions;
using Scout.Domain.Exceptions;

namespace Scout.Domain.ValueObjects;

public record IpAddress
{
    public string Value { get; }

    private IpAddress(string value)
    {
        Value = value;
    }
    public static IpAddress Create(string value)
    {
        if (value != null)
        {
            var regex = new Regex(@"^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){3}$");
            if (!regex.IsMatch(value))
            {
                throw new InvalidIpAddressException(value);
            }
        }
        
        return new IpAddress(value);
    }
}