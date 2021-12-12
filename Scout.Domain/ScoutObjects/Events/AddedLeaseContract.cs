using Scout.Shared.Abstractions.Domain;

namespace Scout.Domain.ScoutObjects.Events;

public class AddedLeaseContract : IDomainEvent
{
    public long ObjectOwnerId { get; } // there should be ObejctOwnerId type instead of long
    public long ScoutObjectId { get; } // there should be ScoutObjectId type instead of long
    public long LeaseContractId { get; } // there should be ScoutObjectId type instead of long
    public AddedLeaseContract(long objectOwnerId, long scoutObjectId, long leaseContractId)
    {
        ObjectOwnerId = objectOwnerId;
        ScoutObjectId = scoutObjectId;
        LeaseContractId = leaseContractId;
    }
}