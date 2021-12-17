using MediatR;
using Scout.Application.Common.Exceptions;
using Scout.Domain.ObjectOwners.Entities;
using Scout.Domain.Persons.Entities;
using Scout.Domain.Repositories;
using Scout.Domain.ScoutObjects.Enums;
using Scout.Domain.ValueObjects;

namespace Scout.Application.Commands.Handlers;

public class AddScoutObjectOwnerHandler : IRequestHandler<AddScoutObjectOwner>
{
    private readonly IScoutObjectRepository _scoutObjectRepository;

    public AddScoutObjectOwnerHandler(IScoutObjectRepository scoutObjectRepository)
    {
        _scoutObjectRepository = scoutObjectRepository;
    }
    
    public async Task<Unit> Handle(AddScoutObjectOwner request, CancellationToken cancellationToken)
    {
        var (scoutObjectId, firstName, lastName, postalCode, city, street, companyName, email, phone, urlSite) = request;

        var @object = await _scoutObjectRepository.GetAsync(scoutObjectId) ??
                      throw new NotFoundException($"Object with id: '{scoutObjectId}' could not be found.");

        
        var phoneNumber = PhoneNumber.Create(phone);
        var emailAddress = Email.Create(email);
        var address = Address.Create(street, postalCode, city);
        var person = Person.Create(firstName, lastName, phoneNumber, emailAddress);

        var objectOwner = ObjectOwner.Create(companyName, address, person, urlSite);
        
        @object.AddObjectOwner(objectOwner);

        await _scoutObjectRepository.AddAsync(@object);
        return Unit.Value;
    }
}