using Scout.Domain.Common.Entities;
using Scout.Domain.ContactPersons.Entities;
using Scout.Domain.LeaseContracts.Entities;
using Scout.Domain.ObjectKeepers.Entities;
using Scout.Domain.ObjectOwners.Entities;
using Scout.Domain.ScoutObjects.Enums;
using Scout.Domain.ScoutObjects.Events;
using Scout.Domain.ValueObjects;
using Scout.Shared.Abstractions.Domain;

namespace Scout.Domain.ScoutObjects.Entities;

public class ScoutObject : AggregateRoot<long>
{
    private ScoutObjectName _name;
    private Address _address;
    private WGSGeoLocalization _wgsGeoLocalization;
    private ObjectSpecification _objectSpecification;

    private ObjectStatus _objectStatus;
    private ObjectType _objectType;
    private IpAddress _ipAddress;
    private string _urlToObject;

    private LeaseContract _leaseContract;
    private ObjectOwner _objectOwner;

    private ICollection<ContactPerson> _contactPersons = new List<ContactPerson>();
    private ICollection<ObjectKeeper> _objectKeepers = new List<ObjectKeeper>();

    private ScoutObject() // for EF Core purposes
    {
    }

    internal ScoutObject(ScoutObjectName name, Address address, WGSGeoLocalization wgsGeoLocalization,
        ObjectSpecification objectSpecification, ObjectStatus objectStatus, ObjectType objectType, IpAddress ipAddress, string urlToObject)
    {
        _name = name;
        _address = address;
        _wgsGeoLocalization = wgsGeoLocalization;
        _objectSpecification = objectSpecification;
        _objectStatus = objectStatus;
        _objectType = objectType;
        _ipAddress = ipAddress;
        _urlToObject = urlToObject;
    }

    public void AddObjectOwner(ObjectOwner objectOwner)
    {
        _objectOwner = objectOwner;
        AddDomainEvent(new AddedObjectOwner(_objectOwner.Id, this.Id));
    }
    
    public void AddLeaseContract(LeaseContract leaseContract)
    {
        _leaseContract = leaseContract;
        AddDomainEvent(new AddedLeaseContract(_objectOwner.Id, this.Id, _leaseContract.Id));
    }

    public void AddContactPerson(ContactPerson contactPerson)
    {
        // there could be rule that checks if for example ScoutObject doesn't have more than 3 ContactPersons
        
        _contactPersons.Add(contactPerson);
        AddDomainEvent(new AddedContactPerson(contactPerson.Id, this.Id));
        
    }
    
    public void AddObjectKeeper(ObjectKeeper objectKeeper)
    {
        // there could be rule that checks if for example ScoutObject doesn't have more than 3 ObjectKeepers
        
        _objectKeepers.Add(objectKeeper);
        AddDomainEvent(new AddedObjectKeeper(objectKeeper.Id, this.Id));
        
    }
    
    
    
}