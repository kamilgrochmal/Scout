using Scout.Domain.Common.Entities;
using Scout.Domain.Persons.Entities;
using Scout.Domain.ScoutObjects.Entities;
using Scout.Domain.ValueObjects;

namespace Scout.Domain.ObjectOwners.Entities;

public class ObjectOwner : AuditableEntity
{
    public string CompanyName { get; set; }
    public Address Address { get; set; }
    public string UrlSite { get; set; }
    
    public Person Person { get; set; }
    public long PersonId { get; set; }

    public ICollection<ScoutObject> ScoutObject { get; set; }

}