using Scout.Domain.Common.Entities;
using Scout.Domain.LeaseContracts.Enums;
using Scout.Domain.ValueObjects;

namespace Scout.Domain.LeaseContracts.Entities;

public class LeaseContract : AuditableEntity
{
    public ContractDate ContractDate { get; set; }
    public DateTimeOffset? DateOfTakeover { get; set; }
    public ContractType ContractType { get; set; }
    public DateTimeOffset? AlertDate { get; set; }
    public Money Rent { get; set; }
    public CurrencyType Currency { get; set; }
    public DateTimeOffset? PaymentDeadline { get; set; }
    public Valorization Valorization { get; set; }
    public string OtherFees { get; set; }
    
}