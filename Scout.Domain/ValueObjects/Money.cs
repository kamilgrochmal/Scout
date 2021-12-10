using Ardalis.GuardClauses;

namespace Scout.Domain.ValueObjects;

public record Money
{
    public decimal Value { get; }

    private Money(decimal value)
    {
        Value = value;
    }

    public static Money Create(decimal value)
    {
        Guard.Against.NegativeOrZero(value, nameof(value));

        return new Money(value);
    }
}