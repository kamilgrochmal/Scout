using Scout.Domain.Common.Entities;
using Scout.Domain.ContactPersons.Enums;
using Scout.Domain.Persons.Entities;
using Scout.Domain.ScoutObjects.Entities;

namespace Scout.Domain.ContactPersons.Entities;

public class ContactPerson
{
    public long Id { get; private set; }
    private ScoutObject _scoutObject;

    private Person _person;

    private string _duty;

    private DepartmentType _department;

    private ContactPerson()
    {
        
    }
    
    internal ContactPerson(ScoutObject scoutObject, Person person, string duty, DepartmentType department)
    {
        _scoutObject = scoutObject;
        _person = person;
        _duty = duty;
        _department = department;
    }
    
    //Should there be any methods? if yes then what for example? 
}