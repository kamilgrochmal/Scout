using Scout.Shared.Abstractions.Domain;

namespace Scout.Domain.ScoutObjects.Events;

public class AddedObjectOwner : IDomainEvent
{
    public long ObjectOwnerId { get; } // there should be ObejctOwnerId type instead of long
    public long ScoutObjectId { get; } // there should be ScoutObjectId type instead of long
    
    public AddedObjectOwner(long objectOwnerId, long scoutObjectId)
    {
        ObjectOwnerId = objectOwnerId;
        ScoutObjectId = scoutObjectId;
    }
}