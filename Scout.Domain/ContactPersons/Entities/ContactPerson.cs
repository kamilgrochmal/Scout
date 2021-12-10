using Scout.Domain.Common.Entities;
using Scout.Domain.ContactPersons.Enums;
using Scout.Domain.Persons.Entities;
using Scout.Domain.ScoutObjects.Entities;

namespace Scout.Domain.ContactPersons.Entities;

public class ContactPerson : AuditableEntity
{
    public long ScoutObjectId { get; set; }
    public ScoutObject ScoutObject { get; set; }

    public long PersonId { get; set; }
    public Person Person { get; set; }

    public string Duty { get; set; }

    public DepartmentType Department { get; set; }
}