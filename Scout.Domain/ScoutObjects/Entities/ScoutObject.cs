using Scout.Domain.Common.Entities;
using Scout.Domain.ContactPersons.Entities;
using Scout.Domain.LeaseContracts.Entities;
using Scout.Domain.ObjectKeepers.Entities;
using Scout.Domain.ObjectOwners.Entities;
using Scout.Domain.ScoutObjects.Enums;
using Scout.Domain.ValueObjects;

namespace Scout.Domain.ScoutObjects.Entities;

public class ScoutObject : AuditableEntity
{
    public string Name { get; set; }
    public Address Address { get; set; }
    public WGSGeoLocalization WgsGeoLocalization { get; set; }
    public ObjectSpecification ObjectSpecification { get; set; }
    
    public ObjectStatus ObjectStatus { get; set; }
    public ObjectType ObjectType { get; set; }
    public IpAddress IpAddress { get; set; }
    public string UrlToObject { get; set; }

    public LeaseContract LeaseContract { get; set; }
    public long? LeaseContractId { get; set; }

    public ObjectOwner ObjectOwner { get; set; }
    public long? ObjectOwnerId { get; set; }

    public ICollection<ContactPerson> ContactPersons { get; set; } = new List<ContactPerson>();
    public ICollection<ObjectKeeper> ObjectKeepers { get; set; } = new List<ObjectKeeper>();


    
}