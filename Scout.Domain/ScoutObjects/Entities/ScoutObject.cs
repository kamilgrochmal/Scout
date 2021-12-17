using JetBrains.Annotations;
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
    private ObjectStatus _objectStatus;
    private ObjectType _objectType;
    private List<ObjectOwner> _objectOwners = new();

    private ScoutObject() // for EF Core purposes
    {
    }

    internal ScoutObject(ScoutObjectName name, Address address,
        ObjectStatus objectStatus, ObjectType objectType)
    {
        _name = name;
        _address = address;
        _objectStatus = objectStatus;
        _objectType = objectType;
    }

    public static ScoutObject Create(ScoutObjectName name, Address address, ObjectStatus objectStatus, ObjectType objectType)
        => new(name, address, objectStatus, objectType);


    public void AddObjectOwner(ObjectOwner objectOwner)
    {
        _objectOwners.Add(objectOwner);
        AddDomainEvent(new AddedObjectOwner(objectOwner.Id, this.Id));
    }
}