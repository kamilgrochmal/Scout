using MediatR;
using Scout.Domain.Repositories;
using Scout.Domain.ScoutObjects.Entities;
using Scout.Domain.ValueObjects;

namespace Scout.Application.Commands.Handlers;

public class CreateScoutObjectHandler : IRequestHandler<CreateScoutObject>
{
    private readonly IScoutObjectRepository _scoutObjectRepository;

    public CreateScoutObjectHandler(IScoutObjectRepository scoutObjectRepository)
    {
        _scoutObjectRepository = scoutObjectRepository;
    }

    public async Task<Unit> Handle(CreateScoutObject request, CancellationToken cancellationToken)
    {
        var (name, postalCode, city, street, plotNumber, objectStatus, objectType) = request;

        var objectName = new ScoutObjectName(name);
        var address = Address.Create(street, postalCode, city, plotNumber);
        var scoutObject = ScoutObject.Create(objectName, address, objectStatus, objectType);

        await _scoutObjectRepository.AddAsync(scoutObject);

        return Unit.Value;
    }
}