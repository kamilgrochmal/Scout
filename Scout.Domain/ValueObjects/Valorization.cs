using Ardalis.GuardClauses;
using Scout.Domain.Exceptions;

namespace Scout.Domain.ValueObjects;

public record Valorization
{
    public bool IsValorization { get; }
    public decimal? ValorizationStake { get; }
    public DateTimeOffset? ValorizationFrom { get; }

    private Valorization(DateTimeOffset? valorizationFrom, decimal? valorizationStake, bool isValorization)
    {
        ValorizationFrom = valorizationFrom;
        ValorizationStake = valorizationStake;
        IsValorization = isValorization;
    }

    // There is possibility to remove Create method and instead create by public constractor, there give validation and then make IsValorization init, and use with to copy it.
    public static Valorization Create(DateTimeOffset? valorizationFrom, decimal? valorizationStake, bool isValorization)
    {
        if (valorizationStake != null)
        {
            Guard.Against.NegativeOrZero((double)valorizationStake, nameof(valorizationStake));
        }

        if (valorizationFrom != null)
        {
            Guard.Against.Null(valorizationFrom, nameof(valorizationFrom));
        }


        if (!isValorization)
            throw new ValorizationException(
                "Date and stake of valorization can not be set if isValorization is not checked. ");

        return new Valorization(valorizationFrom, valorizationStake, isValorization);
    }
}