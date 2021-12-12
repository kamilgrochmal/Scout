using Scout.Shared.Abstractions.Domain;

namespace Scout.Domain.ScoutObjects.Events;

public class AddedObjectKeeper : IDomainEvent
{
    public long ObjectKeeperId { get; }  // there should be ObjectKeeperId type instead of long
    public long ScoutObjectId { get; } // there should be ScoutObjectId type instead of long
    public AddedObjectKeeper(long objectKeeperId, long scoutObjectId)
    {
        ObjectKeeperId = objectKeeperId;
        ScoutObjectId = scoutObjectId;
    }
}