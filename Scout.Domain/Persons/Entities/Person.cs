using Scout.Domain.Common.Entities;
using Scout.Domain.ContactPersons.Entities;
using Scout.Domain.ObjectKeepers.Entities;
using Scout.Domain.ObjectOwners.Entities;
using Scout.Domain.ValueObjects;

namespace Scout.Domain.Persons.Entities;

public class Person
{
    public long Id { get; private set; }
    private string _firstName;
    private string _lastName;
    private PhoneNumber _phoneNumberOne;
    private Email _email;

    private Person()
    {
        
    }
    internal Person(string firstName, string lastName, PhoneNumber phoneNumberOne, Email email)
    {
        _firstName = firstName;
        _lastName = lastName;
        _phoneNumberOne = phoneNumberOne;
        _email = email;
    }
    
}