using Scout.Domain.Common.Entities;
using Scout.Domain.Persons.Entities;
using Scout.Domain.ScoutObjects.Entities;
using Scout.Domain.ValueObjects;

namespace Scout.Domain.ObjectKeepers.Entities;

public class ObjectKeeper 
{
    public long Id { get; private set; }
    private ScoutObject _scoutObject; 
    private Person _person; 
    private string _duty; 
    private string _placeToPickUpTheKeys; 
    private PhoneNumber _phoneNumberToPickUpTheKeys;

    private ObjectKeeper()
    {
        
    }
    internal ObjectKeeper(ScoutObject scoutObject, Person person, string duty, string placeToPickUpTheKeys, PhoneNumber phoneNumberToPickUpTheKeys)
    {
        _scoutObject = scoutObject;
        _person = person;
        _duty = duty;
        _placeToPickUpTheKeys = placeToPickUpTheKeys;
        _phoneNumberToPickUpTheKeys = phoneNumberToPickUpTheKeys;
    }
}