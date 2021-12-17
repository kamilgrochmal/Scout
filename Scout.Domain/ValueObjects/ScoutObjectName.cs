using Scout.Domain.Exceptions;

namespace Scout.Domain.ValueObjects;

public record ScoutObjectName
{
    public string Value { get; }

    public ScoutObjectName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new EmptyScoutObjectNameException();
        }

        Value = value;
    }

    
    // convertions 

    public static implicit operator string(ScoutObjectName name)
        => name.Value;
    
    public static implicit operator ScoutObjectName(string name)
        => new(name);
}