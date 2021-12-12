using Scout.Shared.Abstractions.Domain;

namespace Scout.Domain.ScoutObjects.Events;

public class AddedContactPerson : IDomainEvent
{
    public long ContactPersonId { get; } // there should be ContactPersonId type instead of long
    public long ScoutObjectId { get; } // there should be ScoutObjectId type instead of long
    public AddedContactPerson(long contactPersonId, long scoutObjectId)
    {
        ContactPersonId = contactPersonId;
        ScoutObjectId = scoutObjectId;
    }
}