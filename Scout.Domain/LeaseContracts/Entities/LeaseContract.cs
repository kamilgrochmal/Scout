using Scout.Domain.Common.Entities;
using Scout.Domain.LeaseContracts.Enums;
using Scout.Domain.ValueObjects;

namespace Scout.Domain.LeaseContracts.Entities;

public class LeaseContract
{
    public long Id { get; private set; }
    private ContractDate _contractDate;
    private DateTimeOffset? _dateOfTakeover;
    private ContractType _contractType;
    private DateTimeOffset? _alertDate;
    private Money _rent;
    private CurrencyType _currency;
    private DateTimeOffset? _paymentDeadline;
    private Valorization _valorization;
    private string _otherFees;

    private LeaseContract()
    {
        
    }
    
    internal LeaseContract(ContractDate contractDate, DateTimeOffset? dateOfTakeover, ContractType contractType, DateTimeOffset? alertDate, Money rent, CurrencyType currency, DateTimeOffset? paymentDeadline, Valorization valorization, string otherFees)
    {
        _contractDate = contractDate;
        _dateOfTakeover = dateOfTakeover;
        _contractType = contractType;
        _alertDate = alertDate;
        _rent = rent;
        _currency = currency;
        _paymentDeadline = paymentDeadline;
        _valorization = valorization;
        _otherFees = otherFees;
    }
}