using Scout.Domain.Exceptions;

namespace Scout.Domain.ValueObjects;

public record ScoutObjectName
{
    public string Value { get; }

    private ScoutObjectName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new EmptyScoutObjectNameException();
        }

        Value = value;
    }

    public static ScoutObjectName Create(string value) => new ScoutObjectName(value);
    
    
    
    // convertions 

    public static implicit operator string(ScoutObjectName name)
        => name.Value;
    
    public static implicit operator ScoutObjectName(string name)
        => new(name);
}