using Ardalis.GuardClauses;
using Scout.Domain.Exceptions;

namespace Scout.Domain.ValueObjects;

public record ContractDate
{
    public DateTimeOffset? ContractConclusionDate { get; }
    public DateTimeOffset? ContractValidFrom { get; }
    public DateTimeOffset? ContractValidTo { get; }
    public string PeriodOfNotice { get; }


    private ContractDate(DateTimeOffset? contractConclusionDate, DateTimeOffset? contractValidFrom,
        DateTimeOffset? contractValidTo, string periodOfNotice)
    {
        ContractConclusionDate = contractConclusionDate;
        ContractValidFrom = contractValidFrom;
        ContractValidTo = contractValidTo;
        PeriodOfNotice = periodOfNotice;
    }

    public static ContractDate Create(DateTimeOffset? contractConclusionDate, DateTimeOffset? contractValidFrom,
        DateTimeOffset? contractValidTo, string periodOfNotice)
    {
        Guard.Against.Null(contractConclusionDate, nameof(contractConclusionDate));
        Guard.Against.Null(contractValidFrom, nameof(contractValidFrom));
        Guard.Against.Null(contractValidTo, nameof(contractValidTo));
        Guard.Against.NullOrWhiteSpace(periodOfNotice, nameof(periodOfNotice));
        
        if (contractValidFrom > contractValidTo)
            throw new InvalidContractDateException("ContractValidFrom can not be older than contractValidTo. ");

        return new ContractDate(contractConclusionDate, contractValidFrom,
            contractValidTo, periodOfNotice);
    }
}