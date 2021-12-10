using Scout.Domain.Common.Entities;
using Scout.Domain.Persons.Entities;
using Scout.Domain.ScoutObjects.Entities;
using Scout.Domain.ValueObjects;

namespace Scout.Domain.ObjectKeepers.Entities;

public class ObjectKeeper : AuditableEntity
{
    public long ScoutObjectId { get; set; }
    public ScoutObject ScoutObject { get; set; }

    public long PersonId { get; set; }
    public Person Person { get; set; }
    
    public string Duty { get; set; }
    public string PlaceToPickUpTheKeys { get; set; }
    public PhoneNumber PhoneNumberToPickUpTheKeys { get; set; }
}