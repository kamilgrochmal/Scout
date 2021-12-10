using Scout.Domain.Common.Entities;
using Scout.Domain.ContactPersons.Entities;
using Scout.Domain.ObjectKeepers.Entities;
using Scout.Domain.ObjectOwners.Entities;
using Scout.Domain.ValueObjects;

namespace Scout.Domain.Persons.Entities;

public class Person : AuditableEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public PhoneNumber PhoneNumberOne { get; set; }
    public Email Email { get; set; }


    public ICollection<ContactPerson> ContactPersons { get; set; } = new List<ContactPerson>();
    public ICollection<ObjectKeeper> ObjectKeepers { get; set; } = new List<ObjectKeeper>();
    public ICollection<ObjectOwner> ObjectOwners { get; set; } = new List<ObjectOwner>();


}