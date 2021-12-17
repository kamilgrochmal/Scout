using Scout.Domain.Common.Entities;
using Scout.Domain.Persons.Entities;
using Scout.Domain.ScoutObjects.Entities;
using Scout.Domain.ValueObjects;

namespace Scout.Domain.ObjectOwners.Entities;

public class ObjectOwner
{
    public long Id { get; private set; }
    private string _companyName;
    private Address _address;
    private string _urlSite;
    private Person _person;

    private ObjectOwner()
    {
    }

    internal ObjectOwner(string companyName, Address address, Person person, string urlSite)
    {
        _companyName = companyName;
        _address = address;
        _urlSite = urlSite;
        _person = person;
    }

    public static ObjectOwner Create(string companyName, Address address, Person person, string urlSite)
    {
        return new ObjectOwner(companyName, address, person, urlSite);
    }
}